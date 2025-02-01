using EEMC2.Commands;
using EEMC2.Extensions;
using EEMC2.Models;
using EEMC2.Services.Models;
using EEMC2.Services.Services.Theme;
using EEMC2.Utils;
using EEMC2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EEMC2.ViewModels
{
    public class ThemesListVM : ViewModelBase
    {
        private readonly AppState _appState;
        private readonly IThemeService _themeService;
        private readonly WindowService _windowService;
        private readonly Guid _courseId;
        private readonly Guid _sectionId;

        private ObservableCollection<ThemesListItemVM> _observableThemesListItemVM;
        public ObservableCollection<ThemesListItemVM> ObservableThemesListItemVM
        {
            get => _observableThemesListItemVM;
            private set => SetProperty(ref _observableThemesListItemVM, value);
        }

        public ThemesListVM(AppState appState, IThemeService themeService, WindowService windowService, Guid courseId, Guid sectionId)
        {
            _appState = appState;
            _themeService = themeService;
            _windowService = windowService;
            _courseId = courseId;
            _sectionId = sectionId;

            ObservableThemesListItemVM = new ObservableCollection<ThemesListItemVM>(
                _appState
                    .CourseFulls
                    .First(courseFull => courseFull.Course.Id == _courseId)
                    .SectionFulls
                    .First(sectionFull => sectionFull.Section.Id == _sectionId)
                    .Themes
                    .Select(theme => new ThemesListItemVM(theme))
            );

            _appState.ThemesListChanged += OnThemesListChanged;

            AddTheme = new ActionCommand(OnAddTheme);
        }

        ~ThemesListVM() 
        {
            _appState.ThemesListChanged -= OnThemesListChanged;
        }

        private void OnThemesListChanged(CollectionChangeType collectionChangeType, Theme trigeredItem)
        {
            if (trigeredItem.SectionId != _sectionId) 
            {
                return;
            }

            switch(collectionChangeType)
            {
                case CollectionChangeType.Added:
                    ObservableThemesListItemVM.Add(new ThemesListItemVM(trigeredItem));
                    break;
                case CollectionChangeType.Removed:
                    ObservableThemesListItemVM.RemoveFirst(item => item.ObservableTheme.Theme ==  trigeredItem);
                    break;
            }
        }

        private void OnAddTheme(object param)
        {
            _windowService.OpenUserControl(
                typeof(AddTheme),
                new AddThemeVM(
                    appState: _appState,
                    themeService: _themeService,
                    courseId: _courseId,
                    sectionId: _sectionId
                )
            );
        }
        public ICommand AddTheme { get; private set; }
    }
}
