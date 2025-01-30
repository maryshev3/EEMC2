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
        private readonly IServiceProvider _serviceProvider;

        private ViewModelBase _selectedViewModel;

        public ViewModelBase SelectedViewModel 
        {
            get => _selectedViewModel;
            set => SetProperty(ref _selectedViewModel, value);
        }

        public MainWindowVM(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            SelectedViewModel = _serviceProvider.GetRequiredService<CoursesListVM>();
        }
    }
}
