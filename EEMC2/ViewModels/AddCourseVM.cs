using EEMC2.Commands;
using EEMC2.Services.Models;
using EEMC2.Services.Services.CourseFull;
using EEMC2.Utils;
using EEMC2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EEMC2.ViewModels
{
    public class AddCourseVM : ViewModelBase
    {
        private readonly ICourseFullService _courseFullService;
        private readonly AppState _appState;

        public AddCourseVM(ICourseFullService courseFullService, AppState appState) 
        {
            _courseFullService = courseFullService;
            _appState = appState;

            AddCourse = new ActionCommand(OnAddCourse);
        }

        private void OnAddCourse(object obj)
        {
            string courseName = (string)obj;

            Course course = new()
            {
                Name = courseName,
            };

            CourseFull addedCourse = _courseFullService.Add(course);
            _appState.CourseFulls.Add(addedCourse);
        }

        public ICommand AddCourse { get; private set; }
    }
}
