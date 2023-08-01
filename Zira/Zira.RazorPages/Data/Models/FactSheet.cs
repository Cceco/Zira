namespace Zira.RazorPages.Data.Models
{
    public class FactSheet
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public string DocumentSlimFilePath { get; set; }
        public string Frequency { get; set; }
        public string OutputType { get; set; }
        public string SerialNumber { get; set; }
        public List<InitialRPDImplementation> InitialRPDImplementation { get; set; }
        public string? MultiLanguage { get; set; }
        public string? CustomFont { get; set; }
        public string? CustomColorScheme { get; set; }
        public List<Account>? Accounts { get; set; }
        public string? Notes { get; set; }
        public List<ExampleOutput>? ExampleOutputs { get; set; }
        public List<CustomComponent>? CustomComponents { get; set; }
        public List<UDF>? UDFs { get; set; }
        public string HardcodedSection { get; set; }
        public string NarrativeManager { get; set; }
        public List<PRBProductionJob>? PRBProductionJobs { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
