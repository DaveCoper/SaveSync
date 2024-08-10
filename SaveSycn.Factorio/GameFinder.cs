namespace SaveSycn.Factorio
{
    public class GameFinder
    {
        public string? FindLocalSaveDirectoryPath()
        {
            var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            if (!string.IsNullOrEmpty(appDataFolder))
            {
                var path = Path.Combine(appDataFolder, "Factorio", "saves");
                if (Directory.Exists(path))
                {
                    return path;
                }
            }

            throw new NotImplementedException();
        }
    }
}
