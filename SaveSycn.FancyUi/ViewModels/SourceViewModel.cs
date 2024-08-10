using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ReactiveUI;

namespace SaveSycn.FancyUi.ViewModels
{
    public class SourceViewModel : ReactiveObject
    {
        private ObservableCollection<SaveViewModel> saves = [];
        private string name = string.Empty;

        public ObservableCollection<SaveViewModel> Saves
        {
            get => saves;
            set => this.RaiseAndSetIfChanged(ref this.saves, value);
        }

        public string Name
        {
            get => name;
            set => this.RaiseAndSetIfChanged(ref this.name, value);
        }
    }
}
