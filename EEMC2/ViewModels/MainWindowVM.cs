using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        private readonly AppState _appState;

        public ViewModelBase SelectedViewModel => _appState.CurrentVMOnMainWindow;

        public MainWindowVM(AppState appState)
        {
            _appState = appState;

            _appState.CurrentVMOnMainWindowChanged += newViewModel => OnPropertyChanged(nameof(SelectedViewModel));
        }
    }
}
