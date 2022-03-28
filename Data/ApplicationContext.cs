using Hotel.Models;
using Microsoft.EntityFrameworkCore;
using static System.Configuration.ConfigurationManager;

namespace Hotel.Data
{
    /// <summary>
    /// Строка подключения записана в app.config
    /// </summary>
    public partial class HotelContext : DbContext
    {
        public HotelContext() { }
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        public virtual DbSet<Room> Room { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString =
                    $"Data Source={AppSettings["DatabaseServer"]};" +
                    $"Initial Catalog={AppSettings["DefaultCatalog"]};" +
                    "Integrated Security=True";

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.RoomIdentifier);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
