using EEMC2.Commands;
using EEMC2.Models;
using EEMC2.Services.Models;
using EEMC2.Services.Services.SectionFull;
using EEMC2.Utils;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EEMC2.ViewModels
{
    public class CourseVM : ViewModelBase
    {
        private readonly AppState _appState;
        private readonly IServiceProvider _serviceProvider;

        private ObservableCourseFull _observableCourseFull;
        public ObservableCourseFull ObservableCourseFull
        {
            get => _observableCourseFull;
            private set => SetProperty(ref _observableCourseFull, value);
        }

        public SectionsListVM SectionsListVM { get; private set; }

        public CourseVM(ObservableCourseFull observableCourseFull, AppState appState, IServiceProvider serviceProvider) 
        {
            ObservableCourseFull = observableCourseFull;

            _appState = appState;
            _serviceProvider = serviceProvider;

            SectionsListVM = new SectionsListVM(
                appState: _appState,
                windowService: _serviceProvider.GetService<WindowService>(),
                sectionFullService: _serviceProvider.GetService<ISectionFullService>(),
                courseId: ObservableCourseFull.CourseFull.Course.Id
            );

            ToHome = new ActionCommand(OnToHome);
        }

        public ICommand ToHome { get; private set; }
        private void OnToHome(object param)
        {
            _appState.CurrentVMOnMainWindow = _serviceProvider.GetService<CoursesListVM>();
        }
    }
}
