namespace MusicManager.Data.ORM;

public class Song{
    public long idSong {get; set;}
    public long idAlbum {get; set;}
    public string nom {get; set;}
    public DateTime? releaseDate {get; set;}
    public DateTime? deadline {get; set;}
    public bool fini {get; set;}
    public string? featurings {get; set;}
    public string? BeatUri {get; set;}
    public string? MockupUri {get; set;}
    public string? Notes {get; set;}
    public string? Paroles {get; set;}
    public long order {get; set;}

    public override string ToString()
    {
        return nom + " dans l'album numéro : " + idAlbum;
    }
}