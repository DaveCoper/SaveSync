using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ReactiveUI;

using SaveSycn.Core;
using SaveSycn.Factorio;

namespace SaveSycn.FancyUi.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private ObservableCollection<SourceViewModel> sources = new ObservableCollection<SourceViewModel>();
        private SourceViewModel? selectedSource;

        public ObservableCollection<SourceViewModel> Sources
        {
            get => sources;
            set => this.RaiseAndSetIfChanged(ref sources, value);
        }

        public SourceViewModel? SelectedSource
        {
            get => selectedSource;
            set => this.RaiseAndSetIfChanged(ref selectedSource, value);
        }

        public MainWindowViewModel()
        {
            LoadSaves();
        }

        private async Task LoadSaves()
        {
            var cts = new CancellationTokenSource();
            var gameFinder = new GameFinder();
            var dir = gameFinder.FindLocalSaveDirectoryPath();
            if (dir == null)
            {
                throw new Exception("Factorio not found!");
            }

            var storage = new LocalFileBrowser(dir, "*.zip");
            var saveBrowser = new SaveBrowser();

            var saves = saveBrowser.BrowseSavesAsync(storage, cts.Token);
            var source = new SourceViewModel
            {
                Name = "Local files"
            };

            await foreach (var save in saves)
            {
                source.Saves.Add(new SaveViewModel
                {
                    Name = save.Name,
                    LastChange = save.LastChange,
                    SaveSize = save.SaveSize / 1048576.0,
                });
            }

            this.Sources.Add(source);
            this.SelectedSource = source;
        }
    }
}
