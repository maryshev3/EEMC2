using EEMC2.Commands;
using EEMC2.Models;
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
        private readonly IServiceProvider _serviceProvider;

        private ObservableCourseFull _observableCourseFull;
        public ObservableCourseFull ObservableCourseFull
        {
            get => _observableCourseFull;
            set => SetProperty(ref _observableCourseFull, value);
        }

        public CoursesListItemVM(CourseFull courseFull, AppState appState, IServiceProvider serviceProvider)
        {
            _observableCourseFull = new ObservableCourseFull(courseFull);
            _appState = appState;
            _serviceProvider = serviceProvider;

            OpenCourse = new ActionCommand(OnOpenCourse);
        }

        public ICommand OpenCourse { get; private set; }
        private void OnOpenCourse(object param)
        {
            if (_appState.CurrentVMOnMainWindow is CourseVM openedCourseVM
                && openedCourseVM.ObservableCourseFull.CourseFull == ObservableCourseFull.CourseFull)
            {
                return;
            }

            _appState.CurrentVMOnMainWindow = new CourseVM(ObservableCourseFull, _appState, _serviceProvider);
        }
    }
}
