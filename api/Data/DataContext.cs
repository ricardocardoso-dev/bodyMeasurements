using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Person> Persons {get; set;}

        public DbSet<MeasurementEntry> MeasurementEntries { get; set; }
    }
}
