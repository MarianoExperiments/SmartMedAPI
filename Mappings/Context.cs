using Microsoft.EntityFrameworkCore;
using smartMedRestApi.Models;

namespace smartMedRestApi.Mappings
{
    public class Context : DbContext
    {
        public DbSet<Medication> Medication { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder builder){
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new MedicationMap());
        }
    }
}