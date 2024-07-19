using loginAuth.Models;
using Microsoft.EntityFrameworkCore;
using loginAuth.Models;

namespace loginAuth.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Email = "admin1@gmail.com", Password = "admin1", RoleId = 1,FirstName="john",LastName="Mary" },
            new User { Id = 2, Email = "admin2@gmail.com", Password = "admin2", RoleId = 1 , FirstName = "jim", LastName = "Mary" },
            new User { Id = 3, Email = "manager1@gmail.com", Password = "manager1", RoleId = 2 , FirstName = "john", LastName = "josephy" },
            new User { Id = 4, Email = "manager2@gmail.com", Password = "manager2", RoleId = 2, FirstName = "jin", LastName = "tom" },
            new User { Id = 5, Email = "employee1@gmail.com", Password = "employee1", RoleId = 3 , FirstName = "tim", LastName = "Mary" },
            new User { Id = 6, Email = "employee2@gmail.com", Password = "employee2", RoleId = 3 ,FirstName = "josh", LastName = "Mary" }
        );
            modelBuilder.Entity<Role>().HasData(
           new Role { Id = 1, Name = "Admin" },
           new Role { Id = 2, Name = "Manager" },
           new Role { Id = 3, Name = "Employee" }
       );
        }
        

    }
}
