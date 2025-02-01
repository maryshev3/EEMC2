using EEMC2.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.Services.Services.SectionFull
{
    public interface ISectionFullService
    {
        public IEnumerable<Models.SectionFull> Get();
        public Models.SectionFull Add(Models.Section section);
    }
}
