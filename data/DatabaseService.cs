using MusicManager.Data.ORM;
using Npgsql;

namespace MusicManager.Data;
public class DatabaseService : IDatabaseService
{
    private readonly string _connectionString;

    public DatabaseService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<Album>> GetAllAlbumsAsync()
    {
       var albums = new List<Album>();

        // Créer une connexion à la base de données
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        // Définir la commande SQL pour récupérer toutes les colonnes de la table Consultant
        var sql = "SELECT * FROM album;";

        await using var command = new NpgsqlCommand(sql, connection);
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            // Créer un objet Album pour chaque ligne de résultats
            var album = new Album
            {
                idAlbum = reader.GetInt64(0),
                nom = reader.GetString(1),
                artiste = !reader.IsDBNull(2) ? reader.GetString(2) : null,
                releaseDate = !reader.IsDBNull(3) ? reader.GetDateTime(3) : null,
                deadline = !reader.IsDBNull(4) ? reader.GetDateTime(4) : null,
                fini = reader.GetBoolean(5),
                coverUri = !reader.IsDBNull(6) ? reader.GetString(6) : null
            };

            // Ajouter l'objet consultant à la liste
            albums.Add(album);
        }

        return albums;
    }

    public async Task<string> getAlbumNameByIdAsync(int albumId){
        var nomAlbum = string.Empty;

        // Créer une connexion à la base de données
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        // Définir la commande SQL pour récupérer toutes les colonnes de la table Consultant
        var sql = "SELECT a.nom FROM album AS a WHERE a.idalbum = " + albumId.ToString();
        await using var command = new NpgsqlCommand(sql, connection);
        await using var reader = await command.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            // Récupérer le nom de l'album depuis le résultat de la requête
            nomAlbum = reader.GetString(0); // La première colonne contient le nom de l'album
        }

        return nomAlbum;
    }

    public async Task<IEnumerable<Song>> GetSongsByAlbumIdAsync(long albumId){
        var songs = new List<Song>();

        // Créer une connexion à la base de données
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        // Définir la commande SQL pour récupérer toutes les colonnes de la table Consultant
        var sql = "SELECT * FROM song as s WHERE s.idalbum =" + albumId;
        await using var command = new NpgsqlCommand(sql, connection);
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            // Créer un objet Album pour chaque ligne de résultats
            var song = new Song
            {
                idSong = reader.GetInt64(0),
                idAlbum = reader.GetInt64(1),
                nom = reader.GetString(2),
                releaseDate = !reader.IsDBNull(3) ? reader.GetDateTime(3) : null,
                deadline = !reader.IsDBNull(4) ? reader.GetDateTime(4) : null,
                fini = reader.GetBoolean(5),
                featurings = !reader.IsDBNull(6) ? reader.GetString(6) : null,
                BeatUri = !reader.IsDBNull(7) ? reader.GetString(7) : null,
                MockupUri = !reader.IsDBNull(8) ? reader.GetString(8) : null,
                Notes = !reader.IsDBNull(9) ? reader.GetString(9) : null,
                Paroles = !reader.IsDBNull(10) ? reader.GetString(10) : null,
                order = reader.GetInt64(11)
            };

            // Ajouter l'objet consultant à la liste
            songs.Add(song);
        }
        return songs;
    }

    public async Task<Album> GetAlbumByIdAsync(int albumId){
        Album album = new Album();

        // Créer une connexion à la base de données
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        // Définir la commande SQL pour récupérer toutes les colonnes de la table Consultant
        var sql = "SELECT * FROM album AS a WHERE a.idalbum = " + albumId.ToString();
        await using var command = new NpgsqlCommand(sql, connection);
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            // Créer un objet Album pour chaque ligne de résultats
            album = new Album
            {
                idAlbum = reader.GetInt64(0),
                nom = reader.GetString(1),
                artiste = !reader.IsDBNull(2) ? reader.GetString(2) : null,
                releaseDate = !reader.IsDBNull(3) ? reader.GetDateTime(3) : null,
                deadline = !reader.IsDBNull(4) ? reader.GetDateTime(4) : null,
                fini = reader.GetBoolean(5),
                coverUri = !reader.IsDBNull(6) ? reader.GetString(6) : null
            };
        }

        return album;
    }

    public async Task AddAlbumAsync(Album album)
    {
        // Créer la connexion à la base de données
        await using var connection = new NpgsqlConnection(_connectionString);
        await connection.OpenAsync();

        // Définir la commande SQL pour insérer un nouvel album
        var sql = @"
        INSERT INTO album (nom, artiste, releasedate, deadline, fini, coveruri)
        VALUES (@Nom, @Artiste, @ReleaseDate, @Deadline, @Fini, @CoverUri);
        ";

        // Créer la commande avec les paramètres
        await using var command = new NpgsqlCommand(sql, connection);
        command.Parameters.AddWithValue("Nom", album.nom);
        command.Parameters.AddWithValue("Artiste", (object?)album.artiste ?? DBNull.Value);
        command.Parameters.AddWithValue("ReleaseDate", (object?)album.releaseDate ?? DBNull.Value);
        command.Parameters.AddWithValue("Deadline", (object?)album.deadline ?? DBNull.Value);
        command.Parameters.AddWithValue("Fini", false);
        command.Parameters.AddWithValue("CoverUri", (object?)album.coverUri ?? DBNull.Value);

        // Exécuter la commande
        await command.ExecuteNonQueryAsync();
    }
}