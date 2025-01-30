using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThemeFromModel = EEMC2.Services.Models.Theme;

namespace EEMC2.Services.Services.Theme
{
    public interface IThemeService
    {
        public IEnumerable<ThemeFromModel> Get();
        public void Add(ThemeFromModel theme);
        public void Remove(ThemeFromModel theme);
        public void Update(ThemeFromModel theme);
    }
}
