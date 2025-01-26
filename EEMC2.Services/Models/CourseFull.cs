using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.Services.Models
{
    public class CourseFull
    {
        public Course Course { get; set; }
        public CourseImage CourseImage { get; set; }
        public IEnumerable<SectionFull> SectionFulls { get; set; }
    }
}
