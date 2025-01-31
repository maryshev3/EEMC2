using EEMC2.Commands;
using EEMC2.Services.Models;
using EEMC2.Services.Services.CourseFull;
using EEMC2.Utils;
using EEMC2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EEMC2.ViewModels
{
    public class CoursesListVM : ViewModelBase
    {
        private readonly AppState _appState;
        private readonly WindowService _windowService;

        public ObservableCollection<CoursesListItemVM> Courses => new ObservableCollection<CoursesListItemVM>(
            _appState.CourseFulls.Select(x => new CoursesListItemVM(x))
        );

        public CoursesListVM(AppState appState, WindowService windowService) 
        {
            _appState = appState;
            _windowService = windowService;

            _appState.CourseFulls.CollectionChanged += (sender, e) => OnPropertyChanged(nameof(Courses));

            AddCourse = new ActionCommand(OnAddCourse);
        }

        private void OnAddCourse(object param)
        {
            _windowService.OpenUserControl(typeof(AddCourse), typeof(AddCourseVM));
        }

        public ICommand AddCourse { get; private set; }
    }
}
