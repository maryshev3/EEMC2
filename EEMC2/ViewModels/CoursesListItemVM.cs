using EEMC2.Commands;
using EEMC2.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EEMC2.ViewModels
{
    public class CoursesListItemVM : ViewModelBase
    {
        private readonly AppState _appState;

        private CourseFull _courseFull;
        public CourseFull CourseFull
        {
            get => _courseFull;
            set => SetProperty(ref _courseFull, value);
        }

        public CoursesListItemVM(CourseFull courseFull, AppState appState)
        {
            _courseFull = courseFull;
            _appState = appState;

            OpenCourse = new ActionCommand(OnOpenCourse);
        }

        public ICommand OpenCourse { get; private set; }
        private void OnOpenCourse(object param)
        {
            if (_appState.CurrentVMOnMainWindow is CourseVM openedCourseVM
                && openedCourseVM.ObservableCourseFull.CourseFull == CourseFull)
            {
                return;
            }

            _appState.CurrentVMOnMainWindow = new CourseVM(CourseFull);
        }
    }
}
