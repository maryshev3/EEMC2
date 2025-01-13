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
        private readonly CourseFull _courseFull;

        public ICommand OpenCourse { get; private set; }

        public CoursesListItemVM(CourseFull courseFull)
        {
            _courseFull = courseFull;

            OpenCourse = new ActionCommand(OnOpenCourse);
        }

        private void OnOpenCourse(object param)
        {

        }
    }
}
