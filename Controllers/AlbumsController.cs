// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using MusicManager.Data;
// using MusicManager.Data.ORM;

// [ApiController]
// [Route("api/[controller]")]
// public class AlbumsController : ControllerBase
// {
//     private readonly DatabaseService _DatabaseService;

//     public AlbumsController(DatabaseService databaseService)
//     {
//         _DatabaseService = databaseService;
//     }

//     // GET api/albums
//     [HttpGet]
//     public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
//     {
//         var albums = await _DatabaseService.Albums.FromSqlRaw("SELECT * FROM album").ToListAsync();
//     }

// }