using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        private ViewModelBase _selectedViewModel;

        public ViewModelBase SelectedViewModel 
        {
            get => _selectedViewModel;
            set => SetProperty(ref _selectedViewModel, value);
        }
    }
}
