using CommonLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var assignment = new Assignment { StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1) };

            // Using EF8
            using (var context = new CommonLibrary.ApplicationDbContext())
            {
                context.Database.EnsureCreated();
                var efService = new EFService();
                var efQuery = efService.GetQueryString(context, assignment);
                Console.WriteLine("EF 9 Query:");
                Console.WriteLine(efQuery);
            }
        }
    }
}
