using EEMC2.Services.Repositories.Theme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.Services.Services.Theme
{
    public class ThemeService : IThemeService
    {
        private readonly IThemeRepository _themeRepository;

        public ThemeService(IThemeRepository themeRepository) 
        {
            _themeRepository = themeRepository;
        }

        public void Add(Models.Theme theme)
        {
            _themeRepository.Add(theme);
        }

        public IEnumerable<Models.Theme> Get()
        {
            return _themeRepository.Get();
        }

        public void Remove(Models.Theme theme)
        {
            _themeRepository.Remove(theme);
        }

        public void Update(Models.Theme theme)
        {
            _themeRepository.Update(theme);
        }
    }
}
