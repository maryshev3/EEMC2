using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.Services.Models
{
    public class CourseImage
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CourseName { get; set; }
        public string ImagePath { get; set; }
    }
}
