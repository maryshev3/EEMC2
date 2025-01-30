using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThemeFromModel = EEMC2.Services.Models.Theme;

namespace EEMC2.Services.Repositories.Theme
{
    public interface IThemeRepository : IRepository<ThemeFromModel>
    {
    }
}
