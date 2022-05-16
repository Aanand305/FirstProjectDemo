using Microsoft.EntityFrameworkCore;

namespace FirstProjectDemo.Models
{
    public class ProjectDbContext:DbContext
    {
        public DbSet<Tbl_User> Tbl_Users { get; set; }
        public DbSet<VarifyAccount> VarifyAccount { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Author> Author { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConnection.Connectionstr);
        }
    }
}
