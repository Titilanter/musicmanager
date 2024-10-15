namespace MusicManager.Data.ORM;

public class Album{
    public long idAlbum {get; set;}
    public string nom {get; set;}
    public string artiste {get; set;}
    public DateTime? releaseDate {get; set;}
    public DateTime? deadline {get; set;}
    public bool? fini {get; set;}
    public string? coverUri {get; set;}

    public override string ToString()
    {
        return nom + " par " + artiste;
    }
}