using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreTutorial.Data.Context
{
    public class ApplicationDbContextDesingTimeFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var context = new ApplicationDbContext();

            

            return context;
        }
    }
}
