namespace EntertainmentBooking.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EntertainmentDbContext : DbContext
    {
        public EntertainmentDbContext()
            : base("name=EntertainmentDbContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<agent> agents { get; set; }
        public virtual DbSet<arrangement> arrangements { get; set; }
        public virtual DbSet<band> bands { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<genre> genres { get; set; }
        public virtual DbSet<member> members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<agent>()
                .HasMany(e => e.bands)
                .WithOptional(e => e.agent)
                .HasForeignKey(e => e.agent_id);

            modelBuilder.Entity<arrangement>()
                .HasMany(e => e.bands)
                .WithMany(e => e.arrangements)
                .Map(m => m.ToTable("band_arrangement"));

            modelBuilder.Entity<arrangement>()
                .HasMany(e => e.customers)
                .WithMany(e => e.arrangements)
                .Map(m => m.ToTable("customer_arrangement"));

            modelBuilder.Entity<band>()
                .HasMany(e => e.members)
                .WithRequired(e => e.band)
                .HasForeignKey(e => e.band_id);

            modelBuilder.Entity<band>()
                .HasMany(e => e.genres)
                .WithMany(e => e.bands)
                .Map(m => m.ToTable("genre_band"));
        }
    }
}
