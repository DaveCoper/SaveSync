using NUnit.Framework;

using SaveSycn.Core;

namespace SaveSycn.Factorio.Tests
{
    [TestFixture]
    public class SaveBrowserTests
    {

        [Test]
        public async Task FindSaves()
        {
            var cts = new CancellationTokenSource();
            var gameFinder = new GameFinder();
            var dir = gameFinder.FindLocalSaveDirectoryPath();
            if (dir == null)
            {
                throw new Exception("Factorio not found!");
            }

            var storage = new LocalFileBrowser(dir);
            var saveBrowser = new SaveBrowser();

            await foreach (var save in saveBrowser.BrowseSavesAsync(storage, cts.Token))
            {

            }
        }
    }
}
