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
}