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

        private ViewModelBase _selectedViewModel;

        public ViewModelBase SelectedViewModel 
        {
            get => _selectedViewModel;
            set => SetProperty(ref _selectedViewModel, value);
        }

        public MainWindowVM(AppState appState, IServiceProvider serviceProvider)
        {
            _appState = appState;

            _appState.CurrentVMOnMainWindow = serviceProvider.GetService<CoursesListVM>();

            SelectedViewModel = _appState.CurrentVMOnMainWindow;

            _appState.CurrentVMOnMainWindowChanged += newViewModel => SelectedViewModel = newViewModel;
        }
    }
}
