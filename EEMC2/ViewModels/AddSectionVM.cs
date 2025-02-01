using EEMC2.Commands;
using EEMC2.Models;
using EEMC2.Services.Models;
using EEMC2.Services.Services.SectionFull;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EEMC2.ViewModels
{
    public class AddSectionVM : ViewModelBase
    {
        private readonly AppState _appState;
        private readonly ISectionFullService _sectionFullService;
        private readonly Guid _courseId;

        public string SectionName { get; set; }

        public AddSectionVM(AppState appState, ISectionFullService sectionFullService, Guid courseId) 
        {
            _appState = appState;
            _sectionFullService = sectionFullService;
            _courseId = courseId;

            AddSection = new ActionCommand(OnAddSection);
        }

        public ICommand AddSection { get; private set; }
        private void OnAddSection(object param)
        {
            var section = new Section()
            {
                CourseId = _courseId,
                Name = SectionName
            };

            var sectionFull = _sectionFullService.Add(section);

            var courseFull = _appState
                .CourseFulls
                .First(courseFull => courseFull.Course.Id == _courseId);

            courseFull.SectionFulls.Add(sectionFull);

            _appState.FireSectionsListChanged(CollectionChangeType.Added, sectionFull);
        }
    }
}
