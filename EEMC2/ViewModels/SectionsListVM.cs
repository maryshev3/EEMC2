using EEMC2.Commands;
using EEMC2.Extensions;
using EEMC2.Models;
using EEMC2.Services.Models;
using EEMC2.Services.Services.SectionFull;
using EEMC2.Services.Services.Theme;
using EEMC2.Utils;
using EEMC2.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EEMC2.ViewModels
{
    public class SectionsListVM : ViewModelBase
    {
        private readonly AppState _appState;
        private readonly WindowService _windowService;
        private readonly ISectionFullService _sectionFullService;
        private readonly IThemeService _themeService;
        private readonly Guid _courseId;

        private ThemesListVM _selectedSection;
        public ThemesListVM SelectedSection
        {
            get => _selectedSection;
            set => SetProperty(ref _selectedSection, value);
        }

        private ObservableCollection<ObservableSectionFull> _observableSectionsFull;
        public ObservableCollection<ObservableSectionFull> ObservableSectionsFull 
        {
            get => _observableSectionsFull;
            private set => SetProperty(ref _observableSectionsFull, value);
        }

        public SectionsListVM(
            AppState appState,
            WindowService windowService,
            ISectionFullService sectionFullService,
            IThemeService themeService,
            Guid courseId
        ) 
        {
            _appState = appState;
            _windowService = windowService;
            _sectionFullService = sectionFullService;
            _themeService = themeService;
            _courseId = courseId;

            ObservableSectionsFull = new ObservableCollection<ObservableSectionFull>(
                _appState
                    .CourseFulls
                    .First(courseFull => courseFull.Course.Id == _courseId)
                    .SectionFulls
                    .Select(section => new ObservableSectionFull(section))
            );

            _appState.SectionsListChanged += OnSectionsListChanged;

            var firstSection = ObservableSectionsFull.FirstOrDefault();
            if (firstSection != null)
            {
                SelectedSection = new ThemesListVM(
                    _appState,
                    _themeService,
                    _windowService,
                    _courseId,
                    firstSection.SectionFull.Section.Id
                );
            }

            AddSection = new ActionCommand(OnAddSection);
            OpenSection = new ActionCommand(OnOpenSection);
        }

        ~SectionsListVM()
        {
            _appState.SectionsListChanged -= OnSectionsListChanged;
        }

        private void OnSectionsListChanged(CollectionChangeType collectionChangeType, SectionFull trigeredItem)
        {
            if (trigeredItem.Section.CourseId != _courseId)
            {
                return;
            }

            switch (collectionChangeType)
            {
                case CollectionChangeType.Added:
                    ObservableSectionsFull.Add(new ObservableSectionFull(trigeredItem));
                    break;
                case CollectionChangeType.Removed:
                    ObservableSectionsFull.RemoveFirst(item => item.SectionFull == trigeredItem);
                    break;
            }
        }

        public ICommand AddSection { get; private set; }
        private void OnAddSection(object param)
        {
            _windowService.OpenUserControl(
                typeof(AddSection),
                new AddSectionVM(
                    appState: _appState,
                    sectionFullService: _sectionFullService,
                    courseId: _courseId
                )
            );
        }

        public ICommand OpenSection { get; private set; }
        private void OnOpenSection(object param)
        {
            var chosenSection = (ObservableSectionFull)param;

            SelectedSection = new ThemesListVM(
                _appState,
                _themeService,
                _windowService,
                _courseId,
                chosenSection.SectionFull.Section.Id
            );
        }
    }
}
