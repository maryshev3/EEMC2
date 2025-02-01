using EEMC2.Models;
using EEMC2.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.ViewModels
{
    public class CourseVM : ViewModelBase
    {
        private ObservableCourseFull _observableCourseFull;
        public ObservableCourseFull ObservableCourseFull
        {
            get => _observableCourseFull;
            private set => SetProperty(ref _observableCourseFull, value);
        }

        public CourseVM(CourseFull courseFull) 
        {
            ObservableCourseFull = new ObservableCourseFull(courseFull);
        }
    }
}
