using EEMC2.Commands;
using EEMC2.Extensions;
using EEMC2.Models;
using EEMC2.Services.Models;
using EEMC2.Services.Services.CourseFull;
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
    public class CoursesListVM : ViewModelBase
    {
        private readonly AppState _appState;
        private readonly WindowService _windowService;
        private readonly IServiceProvider _serviceProvider;

        private ObservableCollection<CoursesListItemVM> _courses;
        public ObservableCollection<CoursesListItemVM> Courses
        {
            get => _courses;
            set => SetProperty(ref _courses, value);
        }

        public CoursesListVM(AppState appState, WindowService windowService, IServiceProvider serviceProvider) 
        {
            _appState = appState;
            _windowService = windowService;
            _serviceProvider = serviceProvider;

            Courses = new ObservableCollection<CoursesListItemVM>(
                _appState.CourseFulls.Select(x => new CoursesListItemVM(x, _appState, _serviceProvider))
            );

            _appState.CoursesListChanged += OnCoursesChanged;

            AddCourse = new ActionCommand(OnAddCourse);
        }

        private void OnCoursesChanged(CollectionChangeType collectionChangeType, CourseFull courseFull)
        {
            switch (collectionChangeType)
            {
                case CollectionChangeType.Added:
                    Courses.Add(new CoursesListItemVM(courseFull, _appState, _serviceProvider));
                    break;
                case CollectionChangeType.Removed:
                    Courses.RemoveFirst(item => item.ObservableCourseFull.CourseFull == courseFull);
                    break;
            }
        }

        private void OnAddCourse(object param)
        {
            _windowService.OpenUserControl(typeof(AddCourse), typeof(AddCourseVM));
        }
        public ICommand AddCourse { get; private set; }
    }
}
