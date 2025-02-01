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
        private readonly Theme _theme;

        public ObservableTheme(Theme theme)
        {
            _theme = theme;
        }

        public string ThemeName
        {
            get => _theme.Name;
            set => SetProperty(
                _theme.Name,
                value,
                _theme,
                (theme, themeName) => theme.Name = themeName
            );
        }
    }
}
