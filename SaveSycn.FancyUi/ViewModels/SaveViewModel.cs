namespace SaveSycn.FancyUi.ViewModels
{
    public enum Status
    {
        Ignored,
        Synchronized,
        Changed,
    }

    public class SaveViewModel
    {
        public required string Name { get; set; }

        public required DateTime LastChange { get; set; }
        
        public double? SaveSize { get; set; }

        public Status Status { get; set; }
    }
}