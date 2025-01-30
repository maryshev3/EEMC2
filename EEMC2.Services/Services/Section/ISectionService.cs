using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SectionFromModel = EEMC2.Services.Models.Section;

namespace EEMC2.Services.Services.Section
{
    public interface ISectionService
    {
        public IEnumerable<SectionFromModel> Get();
        public void Add(SectionFromModel section);
        public void Remove(SectionFromModel section);
        public void Update(SectionFromModel section);
    }
}
