
namespace SaveSycn.Core
{
    public class FileHeader
    {
        public required string Name { get; set; }

        public required string FullName { get; set; }

        public required DateTime LastWriteTimeUtc { get; set; }

        public required DateTime LastWriteTime { get; set; }
        
        public long? SaveSize { get; set; }
    }
}