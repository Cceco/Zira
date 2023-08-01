namespace Zira.RazorPages.Data.Models
{
    public class PRBProductionJob
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FrequencyType Frequency { get; set; }
    }

    public enum FrequencyType
    {
        Daily,
        Weekly,
        Monthly,
    }
}
