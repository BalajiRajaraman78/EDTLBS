using Castle.Components.DictionaryAdapter.Xml;
using EDTLBS.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Xunit;

namespace EDTLBS.TestProject
{
    public class BaseTest
    {
        protected ApplicationDbContext ctx;
        public BaseTest(ApplicationDbContext ctx = null)
        {
            this.ctx = ctx ?? GetInMemoryDBContext();
        }
        protected ApplicationDbContext GetInMemoryDBContext()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var options = builder.UseInMemoryDatabase("test").UseInternalServiceProvider(serviceProvider).Options;
            ApplicationDbContext dbContext = new ApplicationDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}
