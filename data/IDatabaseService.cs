using MusicManager.Data.ORM;

namespace MusicManager.Data;
public interface IDatabaseService
{
    /// <summary>
    /// Fonction qui récupère tous les enregistrements de la table "albums"
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Album>> GetAllAlbumsAsync();
    Task AddAlbumAsync(Album album); // Ajouter la définition de la méthode

}