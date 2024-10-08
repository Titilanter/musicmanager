using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using MusicManager.Data.ORM;

namespace MusicManager.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }


        public DbSet<Album> Albums {get; set;}
        public DbSet<Song> Songs {get; set;}
    }
}