using EEMC2.Commands;
using EEMC2.Models;
using EEMC2.Services.Models;
using EEMC2.Services.Services.SectionFull;
using EEMC2.Utils;
using EEMC2.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EEMC2.ViewModels
{
    public class SectionsListVM : ViewModelBase
    {
        private readonly AppState _appState;
        private readonly WindowService _windowService;
        private readonly ISectionFullService _sectionFullService;
        private readonly Guid _courseId;

        private ObservableCollection<ObservableSectionFull> _observableSectionFull;
        public ObservableCollection<ObservableSectionFull> ObservableSectionFull 
        {
            get => _observableSectionFull;
            private set => SetProperty(ref _observableSectionFull, value);
        }

        public SectionsListVM(
            AppState appState,
            WindowService windowService,
            ISectionFullService sectionFullService,
            Guid courseId
        ) 
        {
            _appState = appState;
            _windowService = windowService;
            _sectionFullService = sectionFullService;
            _courseId = courseId;

            RefreshObservableSectionFull();

            _appState.SectionsListChanged += OnSectionsListChanged;

            AddSection = new ActionCommand(OnAddSection);
            OpenSection = new ActionCommand(OnOpenSection);
        }

        ~SectionsListVM()
        {
            _appState.SectionsListChanged -= OnSectionsListChanged;
        }

        private void RefreshObservableSectionFull()
        {
            ObservableSectionFull = new ObservableCollection<ObservableSectionFull>(
                _appState
                    .CourseFulls
                    .First(courseFull => courseFull.Course.Id == _courseId)
                    .SectionFulls
                    .Select(section => new ObservableSectionFull(section))
            );
        }

        private void OnSectionsListChanged(Guid courseId)
        {
            if (courseId == _courseId)
            {
                RefreshObservableSectionFull();
            }
        }

        public ICommand AddSection { get; private set; }
        private void OnAddSection(object param)
        {
            _windowService.OpenUserControl(
                typeof(AddSection),
                new AddSectionVM(
                    appState: _appState,
                    sectionFullService: _sectionFullService,
                    courseId: _courseId
                )
            );
        }

        public ICommand OpenSection { get; private set; }
        private void OnOpenSection(object param)
        {

        }
    }
}
