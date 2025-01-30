using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThemeFromModel = EEMC2.Services.Models.Theme;

namespace EEMC2.Services.Repositories.Theme
{
    public class ThemeFileRepository : FileRepositoryBase<ThemeFromModel>, IThemeRepository
    {
        public ThemeFileRepository(string baseFilePath, string themeFileName) : base(baseFilePath, themeFileName)
        {
        }

        public override void Add(ThemeFromModel theme)
        {
            List<ThemeFromModel> currentThemesList = Get();

            if (currentThemesList.Any(currentTheme => currentTheme.Id == theme.Id))
            {
                throw new ArgumentException($"При добавлении темы раздела произошла ошибка. В файле с темами раздела \"{theme.Id}\" уже существует. Сохранение невозможно.");
            }

            Save(currentThemesList.Append(theme));
        }

        public override void Remove(ThemeFromModel theme)
        {
            List<ThemeFromModel> currentThemesList = Get();

            if (!currentThemesList.Any(currentTheme => currentTheme.Id == theme.Id))
            {
                throw new ArgumentException($"При удалении темы раздела произошла ошибка. В файле с темами раздела \"{theme.Id}\" не существует. Сохранение невозможно.");
            }

            Save(currentThemesList.Where(currentTheme => currentTheme.Id != theme.Id));
        }

        public override void Update(ThemeFromModel theme)
        {
            List<ThemeFromModel> currentThemesList = Get();

            ThemeFromModel currentThemeForUpdate = currentThemesList.FirstOrDefault(currentTheme => currentTheme.Id == theme.Id);

            if (currentThemeForUpdate == default)
            {
                throw new ArgumentException($"При обновлении раздела курса произошла ошибка. В файле с разделами курса \"{theme.Id}\" не существует. Сохранение невозможно.");
            }

            Save(currentThemesList.Where(currentTheme => currentTheme != currentThemeForUpdate).Append(theme));
        }
    }
}
