namespace Zira.RazorPages.Data.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public ContactType Type { get; set; }
        public string Name { get; set; }
    }

    public enum ContactType
    {   
        ImplementationTeam,
        User,
        Client,
        CurrentAccoutTeam
    }
}
