using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RoomTracker.Model
{
    public partial class roomTrackingContext : DbContext
    {
        public roomTrackingContext()
        {
        }

        public roomTrackingContext(DbContextOptions<roomTrackingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Wardrobe> Wardrobe { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:nzmsaroomtracker.database.windows.net,1433;Initial Catalog=RoomTrackerDB;Persist Security Info=False;User ID=nkmu576;Password=NZMSAR00mTracker;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Wardrobe>(entity =>
            {
                entity.Property(e => e.Category).IsUnicode(false);

                entity.Property(e => e.Colour).IsUnicode(false);

                entity.Property(e => e.Condition).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Situation).IsUnicode(false);

                entity.Property(e => e.Value).IsUnicode(false);
            });
        }
    }
}
