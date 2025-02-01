using EEMC2.Services.Services.Section;
using EEMC2.Services.Services.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.Services.Services.SectionFull
{
    public class SectionFullService : ISectionFullService
    {
        private readonly ISectionService _sectionService;
        private readonly IThemeService _themeService;

        public SectionFullService(
            ISectionService sectionService,
            IThemeService themeService
        )
        {
            _sectionService = sectionService;
            _themeService = themeService;
        }

        public IEnumerable<Models.SectionFull> Get()
        {
            var sections = _sectionService.Get();

            var sectionToThemes = _themeService
                .Get()
                .ToLookup(theme => theme.SectionId);

            return sections.Select(section => new Models.SectionFull()
            {
                Section = section,
                Themes = sectionToThemes
                    .Where(sectionToThemesItem => sectionToThemesItem.Key == section.Id)
                    .SelectMany(sectionToThemesItem => sectionToThemesItem)
                    .ToList()
            }).ToList();
        }

        public Models.SectionFull Add(Models.Section section)
        {
            Models.SectionFull sectionFull = new Models.SectionFull
            {
                Section = section,
                Themes = new List<Models.Theme>()
            };

            _sectionService.Add(section);

            return sectionFull;
        }
    }
}
