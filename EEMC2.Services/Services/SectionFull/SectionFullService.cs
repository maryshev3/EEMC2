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

            var themes = _themeService.Get();

            return sections
                .Join(
                    themes,
                    section => section.Id,
                    theme => theme.SectionId,
                    (section, theme) => new
                    {
                        Section = section,
                        Theme = theme
                    })
                .GroupBy(tuple => tuple.Section)
                .Select(tuple => new Models.SectionFull()
                    {
                        Section = tuple.Key,
                        Themes = tuple.Select(subTuple => subTuple.Theme).ToArray()
                    })
                .ToArray();
        }
    }
}
