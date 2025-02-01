using CommunityToolkit.Mvvm.ComponentModel;
using EEMC2.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.Models
{
    public class ObservableTheme : ObservableObject
    {
        public Theme Theme { get; private set; }

        public ObservableTheme(Theme theme)
        {
            Theme = theme;
        }

        public string ThemeName
        {
            get => Theme.Name;
            set => SetProperty(
                Theme.Name,
                value,
                Theme,
                (theme, themeName) => theme.Name = themeName
            );
        }
    }
}
