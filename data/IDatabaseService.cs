using MusicManager.Data.ORM;

namespace MusicManager.Data;
public interface IDatabaseService
{
    /// <summary>
    /// Fonction qui récupère tous les enregistrements de la table "albums"
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Album>> GetAllAlbumsAsync();

    Task<string> getAlbumNameByIdAsync(int albumId);

    Task<IEnumerable<Song>> GetSongsByAlbumIdAsync(long albumId);

    Task<Album> GetAlbumByIdAsync(int albumId);
    
}