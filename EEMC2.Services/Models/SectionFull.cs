using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.Services.Models
{
    public class SectionFull
    {
        public Section Section { get; set; }
        public IEnumerable<Theme> Themes { get; set; }
    }
}
