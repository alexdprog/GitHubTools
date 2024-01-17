using Microsoft.EntityFrameworkCore;
using GitHubTools.Domain.Entities;

namespace GitHubTools.Infrastructure.Contexts
{
    public class ToolsBaseContext : DbContext
    {
        public DbSet<RepositoryDb> Repositories { get; set; }

        public DbSet<OwnerDb> Owners { get; set; }

        public ToolsBaseContext()
        {
            try
            {
                Database.Migrate();
            }
            catch (Exception e)
            {
                // Log
            }
        }

        /// <summary>
        /// Configure.
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "GitHubTools.db3");
                options.UseSqlite($"Filename={dbPath}");
                SQLitePCL.Batteries.Init();
            }
            catch
            {
                // Log
            }
        }
    }
}
