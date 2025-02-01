using EEMC2.Commands;
using EEMC2.Models;
using EEMC2.Services.Models;
using EEMC2.Services.Services.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EEMC2.ViewModels
{
    public class AddThemeVM : ViewModelBase
    {
        private readonly AppState _appState;
        private readonly IThemeService _themeService;
        private readonly Guid _courseId;
        private readonly Guid _sectionId;

        public string ThemeName { get; set; }

        public AddThemeVM(AppState appState, IThemeService themeService, Guid courseId, Guid sectionId) 
        {
            _appState = appState;
            _themeService = themeService;
            _courseId = courseId;
            _sectionId = sectionId;

            AddTheme = new ActionCommand(OnAddTheme);
        }

        private void OnAddTheme(object param)
        {
            Theme theme = new Theme()
            {
                Name = ThemeName,
                SectionId = _sectionId,
            };

            _themeService.Add(theme);

            _appState
                .CourseFulls
                .First(courseFull => courseFull.Course.Id == _courseId)
                .SectionFulls
                .First(sectionFull => sectionFull.Section.Id == _sectionId)
                .Themes
                .Add(theme);

            _appState.FireThemesListChanged(CollectionChangeType.Added, theme);
        }
        public ICommand AddTheme { get; private set; }
    }
}
