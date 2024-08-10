using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveSycn.Core
{
    public interface IFileBrowser
    {
        IAsyncEnumerable<FileHeader> EnumerateFilesAsync(CancellationToken cancellationToken);
        
        Task<Stream> ReadFileStreamAsync(FileHeader file, CancellationToken cancellationToken);
    }
}
