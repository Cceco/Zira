#nullable disable
    
namespace Zira.RazorPages.Data.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public Details Details { get; set; }
        public List<ServiceType> ServicesUsed { get; set; }

        public Client()
        {
            ServicesUsed = new List<ServiceType>();
            Details = new Details();
        }
    }
}
