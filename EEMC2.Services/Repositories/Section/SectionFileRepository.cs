using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SectionFromModel = EEMC2.Services.Models.Section;

namespace EEMC2.Services.Repositories.Section
{
    public class SectionFileRepository : FileRepositoryBase<SectionFromModel>, ISectionRepository
    {
        public SectionFileRepository(string baseFilePath, string sectionFileName) : base(baseFilePath, sectionFileName)
        {
        }

        public override void Add(SectionFromModel section)
        {
            List<SectionFromModel> currentSectionsList = Get();

            if (currentSectionsList.Any(currentSection => currentSection.Id == section.Id))
            {
                throw new ArgumentException($"При добавлении раздела курса произошла ошибка. В файле с разделами курса \"{section.Id}\" уже существует. Сохранение невозможно.");
            }

            Save(currentSectionsList.Append(section));
        }

        public override void Remove(SectionFromModel section)
        {
            List<SectionFromModel> currentSectionsList = Get();

            if (!currentSectionsList.Any(currentSection => currentSection.Id == section.Id))
            {
                throw new ArgumentException($"При удалении раздела курса произошла ошибка. В файле с разделами курса \"{section.Id}\" не существует. Сохранение невозможно.");
            }

            Save(currentSectionsList.Where(currentSection => currentSection.Id != section.Id));
        }

        public override void Update(SectionFromModel section)
        {
            List<SectionFromModel> currentSectionsList = Get();

            SectionFromModel currentSectionForUpdate = currentSectionsList.FirstOrDefault(currentSection => currentSection.Id == section.Id);

            if (currentSectionForUpdate == default)
            {
                throw new ArgumentException($"При обновлении раздела курса произошла ошибка. В файле с разделами курса \"{section.Id}\" не существует. Сохранение невозможно.");
            }

            Save(currentSectionsList.Where(currentSection => currentSection != currentSectionForUpdate).Append(section));
        }
    }
}
