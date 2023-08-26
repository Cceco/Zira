using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zira.RazorPages.Data.Models;

namespace Zira.RazorPages.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
          
        }
        public DbSet<Client> Clients { get; set; }

        public DbSet<SeedFlag> SeedFlag { get; set; }

        public DbSet<Details> Details { get; set; }

        public DbSet<FactSheet> FactSheet { get; set; }
    }

    public static class ApplicationDbContextExtensions
    {
        public static void SeedDatabase(this ApplicationDbContext context)
        {
            if (!context.SeedFlag.Any())
            {
                // Seed database
                context.Clients.AddRange(
                    new Client 
                    { 
                        Name = "Acme Corp", 
                        Region = "USA",
                        Details = new Details
                        {
                            FactSheets = new List<FactSheet>
                       {
                           new FactSheet
                           {
                               DocumentName = "BMIS Monthly",
                               DocumentSlimFilePath = "Publisher\\BMIS Monthly",
                               Accounts = new List<Account>{ new Account { Path = "SDASFA" } },
                               Frequency = "Monthly",
                               OutputType = "PDF",
                               SerialNumber = "11059",
                               InitialRPDImplementation = new List<InitialRPDImplementation>
                               { new InitialRPDImplementation { TicketNumber="234324"} } ,
                               MultiLanguage = "No",
                               CustomFont = "Yes",
                               CustomColorScheme = "Yes",
                               Notes ="Test",
                               ExampleOutputs =  new List<ExampleOutput>
                               { new ExampleOutput{FilePath = "asdasda" } },
                               CustomComponents = new List<CustomComponent>
                               { new CustomComponent { Path = "Page1\\3\asd", Notes ="Used for many things"} },
                               UDFs=new List<UDF>{ new UDF { Description = "ASD", ExampleAccount="a21124", Name = "AWARD", Value = "3"} },
                               HardcodedSection = "No",
                               NarrativeManager = "No",
                               PRBProductionJobs = new List<PRBProductionJob>
                               { new PRBProductionJob { Frequency = FrequencyType.Daily, Name = "BMIS Monthly Job" } },
                               Contacts = new List<Contact>
                               { new Contact { Name = "Gosho", Type = ContactType.ImplementationTeam } }
                           }
                       }
                        }
                    },

                    new Client { Name = "Globex Corp", Region = "USA" },
                    new Client { Name = "Foo Industries", Region = "Canada" },
                    new Client { Name = "Bar Enterprises", Region = "Canada" },
                    new Client { Name = "Brooks MacDonald", Region = "EMEA"}
                );

                // Set seed flag
                context.SeedFlag.Add(new SeedFlag { HasSeeded = true });

                context.SaveChanges();
            }
        }
    }
}