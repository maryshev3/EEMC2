using EEMC2.Services.Models;
using EEMC2.Services.Services.CourseFull;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2
{
    public class AppState
    {
        private readonly ICourseFullService _courseFullService;

        public AppState(ICourseFullService courseFullService) 
        {
            _courseFullService = courseFullService;

            CourseFulls = new ObservableCollection<CourseFull>(_courseFullService.Get());
        }

        public ObservableCollection<CourseFull> CourseFulls { get; set; }
    }
}
