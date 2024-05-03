using EDTLBS.Common.Model;
using Microsoft.EntityFrameworkCore;

namespace EDTLBS.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
