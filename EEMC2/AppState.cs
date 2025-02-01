using EEMC2.Models;
using EEMC2.Services.Models;
using EEMC2.Services.Services.CourseFull;
using EEMC2.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2
{
    public delegate void CurrentVMOnMainWindowHandler(ViewModelBase newViewModel);
    public delegate void CoursesListHandler(CollectionChangeType collectionChangeType, CourseFull trigeredItem);
    public delegate void SectionsListHandler(CollectionChangeType collectionChangeType, SectionFull trigeredItem);
    public delegate void ThemesListHandler(CollectionChangeType collectionChangeType, Theme trigeredItem);

    public class AppState
    {
        private readonly ICourseFullService _courseFullService;

        public AppState(ICourseFullService courseFullService)
        {
            _courseFullService = courseFullService;

            CourseFulls = new ObservableCollection<CourseFull>(_courseFullService.Get());
        }

        public ObservableCollection<CourseFull> CourseFulls { get; set; }

        public event CurrentVMOnMainWindowHandler? CurrentVMOnMainWindowChanged;
        private ViewModelBase _currentVMOnMainWindow;

        public ViewModelBase CurrentVMOnMainWindow 
        {
            get => _currentVMOnMainWindow;
            set
            {
                _currentVMOnMainWindow = value;

                CurrentVMOnMainWindowChanged?.Invoke(value);
            }
        }

        public event CoursesListHandler? CoursesListChanged;
        public void FireCoursesListChanged(CollectionChangeType collectionChangeType, CourseFull trigeredItem) =>
            CoursesListChanged?.Invoke(collectionChangeType, trigeredItem);

        public event SectionsListHandler? SectionsListChanged;
        public void FireSectionsListChanged(CollectionChangeType collectionChangeType, SectionFull trigeredItem) =>
            SectionsListChanged?.Invoke(collectionChangeType, trigeredItem);

        public event ThemesListHandler? ThemesListChanged;
        public void FireThemesListChanged(CollectionChangeType collectionChangeType, Theme trigeredItem) =>
            ThemesListChanged?.Invoke(collectionChangeType, trigeredItem);
    }
}
