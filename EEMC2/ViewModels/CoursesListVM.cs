using EEMC2.Commands;
using EEMC2.Services.Models;
using EEMC2.Services.Services.CourseFull;
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
        private readonly ICourseFullService _courseFullService;

        private ObservableCollection<CoursesListItemVM> _courses;
        public ObservableCollection<CoursesListItemVM> Courses
        {
            get => _courses;
            set => SetProperty(ref _courses, value);
        }

        public CoursesListVM(AppState appState, ICourseFullService courseFullService) 
        {
            _appState = appState;
            _courseFullService = courseFullService;

            Courses = new ObservableCollection<CoursesListItemVM>(
                _appState.CourseFulls.Select(x => new CoursesListItemVM(x))
            );

            AddCourse = new ActionCommand(OnAddCourse);
        }

        private void OnAddCourse(object param)
        {

        }

        public ICommand AddCourse { get; private set; }
    }
}
