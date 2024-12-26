using Microsoft.EntityFrameworkCore;
using CommonLibrary;

namespace CommonLibrary
{

    public class ApplicationDbContext : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=AssignmentsTest.db");
        }
    }

    public class EFService
    {
        public string GetQueryString(ApplicationDbContext context, Assignment assignment)
        {
            var query = context.Assignments
                .Where(x =>
                      !(x.StartDate < assignment.StartDate
                       && x.EndDate != null
                       && x.EndDate < assignment.StartDate)
                    && !(assignment.StartDate < x.EndDate
                       && assignment.EndDate != null
                       && assignment.EndDate < x.StartDate))
                .ToQueryString();

            return query;
        }
    }
}
