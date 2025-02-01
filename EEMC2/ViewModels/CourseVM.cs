using EEMC2.Commands;
using EEMC2.Models;
using EEMC2.Services.Models;
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

        public CourseVM(CourseFull courseFull, AppState appState, IServiceProvider serviceProvider) 
        {
            ObservableCourseFull = new ObservableCourseFull(courseFull);
            _appState = appState;
            _serviceProvider = serviceProvider;

            ToHome = new ActionCommand(OnToHome);
        }

        public ICommand ToHome { get; private set; }
        private void OnToHome(object param)
        {
            _appState.CurrentVMOnMainWindow = _serviceProvider.GetService<CoursesListVM>();
        }
    }
}
