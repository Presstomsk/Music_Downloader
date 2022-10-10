using Microsoft.EntityFrameworkCore;
using Music_Downloader.Models;


namespace Music_Downloader.Database
{
    public class MainContext : DbContext
    {
        public DbSet<Song> Songs { get; set; }       

        public MainContext(DbContextOptions options) : base(options)
        {
        }

    }
}
