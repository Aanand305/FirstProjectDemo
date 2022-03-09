using Microsoft.EntityFrameworkCore;

namespace FirstProjectDemo.Models
{
    public class ProjectDbContext:DbContext
    {
        public DbSet<Tbl_Users> Tbl_Users { get; set; }
        public DbSet<VarifyAccount> VarifyAccount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DbConnection.Connectionstr);
        }
    }
}
