using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using SaveSycn.Core;

namespace SaveSycn.Factorio
{
    public class SaveBrowser
    {
        public async IAsyncEnumerable<FactorioSaveInfo> BrowseSavesAsync(IFileBrowser fileBrowser, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var files = fileBrowser.EnumerateFilesAsync(cancellationToken);
            await foreach (var file in files)
            {
                cancellationToken.ThrowIfCancellationRequested();

                using var stream = await fileBrowser.ReadFileStreamAsync(file, cancellationToken);
                using var zipArchive = new ZipArchive(stream, ZipArchiveMode.Read, true);
                var previewImage = zipArchive.Entries.FirstOrDefault(x => x.Name.EndsWith("preview.jpg"));

                byte[]? imageBuffer = null;
                if (previewImage != null)
                {
                    imageBuffer = new byte[previewImage.Length];
                    var memoryStream = new MemoryStream(imageBuffer);
                    using var preview = previewImage.Open();
                    await preview.CopyToAsync(memoryStream);
                }

                yield return new FactorioSaveInfo
                {
                    Name = Path.GetFileNameWithoutExtension(file.Name),
                    LastChange = file.LastWriteTime,
                    LastChangeUtc = file.LastWriteTimeUtc,
                    SaveSize = file.SaveSize,
                    PreviewImage = imageBuffer,
                };
            }
        }
    }
}
