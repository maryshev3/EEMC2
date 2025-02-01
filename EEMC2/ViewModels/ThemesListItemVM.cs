using EEMC2.Models;
using EEMC2.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.ViewModels
{
    public class ThemesListItemVM : ViewModelBase
    {
        private ObservableTheme _observabletheme;
        public ObservableTheme ObservableTheme
        {
            get => _observabletheme;
            set => SetProperty(ref _observabletheme, value);
        }

        public ThemesListItemVM(Theme theme) 
        {
            ObservableTheme = new ObservableTheme(theme);
        }
    }
}
