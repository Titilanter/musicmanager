using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicManager.Data;
using MusicManager.Data.ORM;

[ApiController]
[Route("api/[controller]")]
public class AlbumsController : ControllerBase
{
    private readonly DataContext _context;

    public AlbumsController(DataContext context)
    {
        _context = context;
    }

    // GET api/albums
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
    {
        return await _context.Albums.ToListAsync();
    }

    // POST api/albums
    [HttpPost]
    public async Task<List<Album>> CreateAlbum(Album album)
    {
        var albums = await _context.Albums.FromSqlRaw("SELECT * FROM album").ToListAsync();

        return albums;
    }

    // Autres méthodes PUT, DELETE...
}