using MusicManager.Data.ORM;

namespace MusicManager.Data;
public interface IDatabaseService
{
    /// <summary>
    /// Fonction qui récupère tous les enregistrements de la table "albums"
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Album>> GetAllAlbumsAsync();

    Task AddAlbumAsync(Album album);

    Task<string> getAlbumNameByIdAsync(int albumId);

    Task<string> getSongNameByIdAsync(int songId);

    Task<IEnumerable<Song>> GetSongsByAlbumIdAsync(long albumId);

    Task<Album> GetAlbumByIdAsync(int albumId);
    Task<Song> GetSongByIdAsync(int songId);

    Task<bool> CheckClipWithSongId(int songId);

    Task<bool> CheckPlanComByAlbumId(int albumId);

    Task AddSongAsync(Song song);

    Task<List<Song>> GetAllSongsAsync();

}