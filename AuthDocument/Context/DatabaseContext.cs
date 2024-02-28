using AuthDocument.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthDocument.Context
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var conn = string.Format(@"Data Source=DESKTOP-0RKH9KJ;Initial Catalog=DocumentDB;Persist Security Info=True;User ID=sa;Password=141186;Encrypt=False");
            options.UseSqlServer(conn);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
