using System.Data.Entity;

namespace ResponseTimeCheck
{
    public class DataBaseManager : DbContext
    {
        public DbSet<Entity> Entities { get; set; }
    }
}
