using EEMC2.Services.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.ViewModels
{
    public class CoursesListVM : ViewModelBase
    {
        private readonly AppState _appState;

        private ObservableCollection<CoursesListItemVM> _courses;
        public ObservableCollection<CoursesListItemVM> Courses
        {
            get => _courses;
            set => SetProperty(ref _courses, value);
        }

        public CoursesListVM(AppState appState) 
        {
            _appState = appState;

            Courses = new ObservableCollection<CoursesListItemVM>(
                _appState.CourseFulls.Select(x => new CoursesListItemVM(x))
            );
        }
    }
}
