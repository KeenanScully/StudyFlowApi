using Microsoft.EntityFrameworkCore;
using StudyFlowApi.Models;

namespace StudyFlowApi.Data
{
    
        public class StudyFlowDbContext : DbContext
        {
            public StudyFlowDbContext(
                DbContextOptions<StudyFlowDbContext> options)
                : base(options)
            {
            }

            protected StudyFlowDbContext()
            {
            }

            //Represents the Modules table in PostgreSQL.
            public DbSet<Module> Modules { get; set; }
        }
}

