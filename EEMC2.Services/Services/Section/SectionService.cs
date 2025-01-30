using EEMC2.Services.Repositories.Section;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.Services.Services.Section
{
    public class SectionService : ISectionService
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionService(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public void Add(Models.Section section)
        {
            _sectionRepository.Add(section);
        }

        public IEnumerable<Models.Section> Get()
        {
            return _sectionRepository.Get();
        }

        public void Remove(Models.Section section)
        {
            _sectionRepository.Remove(section);
        }

        public void Update(Models.Section section)
        {
            _sectionRepository.Update(section);
        }
    }
}
