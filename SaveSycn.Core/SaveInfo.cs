namespace SaveSycn.Core
{
    public class SaveInfo
    {
        public required string Name { get; set; }

        public required DateTime LastChange { get; set; }
        
        public required DateTime LastChangeUtc { get; set; }

        public long? SaveSize { get; set; }
    }
}
