using Microsoft.EntityFrameworkCore;
using BasicAPI.Models;

namespace BasicAPI.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Product> Product { get; set; }
        public DbSet<Post> Post { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //modelBuilder.Entity<Job>(e => e.Property(a => a.Aciklama).HasColumnName("Description"));
        }


    }
}
