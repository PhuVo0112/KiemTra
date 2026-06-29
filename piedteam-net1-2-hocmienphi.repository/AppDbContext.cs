using Microsoft.EntityFrameworkCore;
using piedteam_net1_2_hocmienphi.repository.entity;

namespace piedteam_net1_2_hocmienphi.repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<MentorCategory> MentorCategories { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(builder =>
            {
                var categoryData = new List<Category>()
                {
                    new Category()
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000001"),
                        Name = "Programming",
                        ParentId = null
                    },
                    new Category()
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000002"),
                        Name = "Economy",
                        ParentId = null
                    },
                    new Category()
                    {
                        Id = Guid.Parse("00000000-0000-0000-0000-000000000003"),
                        Name = "Design",
                        ParentId = null
                    },
                };
                
                builder.HasData(categoryData);
            });

            modelBuilder.Entity<User>(builder =>
            {
                builder
                    .HasOne(x => x.Mentor)
                    .WithOne(x => x.User)
                    .HasForeignKey<Mentor>(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                
            });

            modelBuilder.Entity<Mentor>(builder =>
            {
                builder
                    .HasMany(x => x.MentorCategories)
                    .WithOne(x => x.Mentor) //thuộc về 1 mentor
                    .HasForeignKey(x => x.MentorId)
                    .OnDelete(DeleteBehavior.Cascade);
                    
            });
        }
    }
}