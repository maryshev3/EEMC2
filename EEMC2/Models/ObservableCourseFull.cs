using CommunityToolkit.Mvvm.ComponentModel;
using EEMC2.Services.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.Models
{
    public class ObservableCourseFull : ObservableObject
    {
        private readonly CourseFull _courseFull;

        public ObservableCourseFull(CourseFull courseFull)
        {
            _courseFull = courseFull;
        }

        public string CourseName
        {
            get => _courseFull.Course.Name;
            set => SetProperty(
                _courseFull.Course.Name,
                value,
                _courseFull,
                (courseFull, courseName) => courseFull.Course.Name = courseName
            );
        }
    }
}
