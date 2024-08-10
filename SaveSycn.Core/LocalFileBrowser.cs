using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SaveSycn.Core
{
    public class LocalFileBrowser : IFileBrowser
    {
        private readonly string basePath;
        private readonly string? fileFilter;

        public LocalFileBrowser(string basePath)
        {
            this.basePath = basePath;
        }
        public LocalFileBrowser(string basePath, string fileFilter)
            : this(basePath)
        {
            this.fileFilter = fileFilter;
        }

        public async IAsyncEnumerable<FileHeader> EnumerateFilesAsync([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var files = string.IsNullOrWhiteSpace(fileFilter) ?
                Directory.EnumerateFiles(basePath) :
                Directory.EnumerateFiles(basePath, fileFilter);

            foreach (var file in files)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var fileInfo = new FileInfo(file);
                yield return new FileHeader
                {
                    Name = fileInfo.Name,
                    FullName = fileInfo.FullName,
                    LastWriteTime = fileInfo.LastWriteTime,
                    LastWriteTimeUtc = fileInfo.LastWriteTimeUtc,
                    SaveSize = fileInfo.Length,
                };
            }
        }

        public Task<Stream> ReadFileStreamAsync(FileHeader file, CancellationToken cancellationToken)
        {
            return Task.FromResult<Stream>(File.Open(file.FullName, FileMode.Open, FileAccess.Read));
        }
    }
}
