using Microsoft.EntityFrameworkCore;

namespace GS.data.Models
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        public DbSet<GitProject> GitProjects { get; set; }
    }
}
