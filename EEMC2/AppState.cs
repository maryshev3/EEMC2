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
    }
}
