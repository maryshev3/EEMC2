﻿using EEMC2.Extensions;
using EEMC2.Models;
using EEMC2.Services.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.ViewModels
{
    public class ThemesListVM : ViewModelBase
    {
        private readonly AppState _appState;
        private readonly Guid _courseId;
        private readonly Guid _sectionId;

        private ObservableCollection<ObservableTheme> _observableThemes;
        public ObservableCollection<ObservableTheme> ObservableThemes
        {
            get => _observableThemes;
            private set => SetProperty(ref _observableThemes, value);
        }

        public ThemesListVM(AppState appState, Guid courseId, Guid sectionId)
        {
            _appState = appState;
            _courseId = courseId;
            _sectionId = sectionId;

            ObservableThemes = new ObservableCollection<ObservableTheme>(
                _appState
                    .CourseFulls
                    .First(courseFull => courseFull.Course.Id == _courseId)
                    .SectionFulls
                    .First(sectionFull => sectionFull.Section.Id == _sectionId)
                    .Themes
                    .Select(theme => new ObservableTheme(theme))
            );

            _appState.ThemesListChanged += OnThemesListChanged;
        }

        ~ThemesListVM() 
        {
            _appState.ThemesListChanged -= OnThemesListChanged;
        }

        private void OnThemesListChanged(CollectionChangeType collectionChangeType, Theme trigeredItem)
        {
            if (trigeredItem.SectionId != _sectionId) 
            {
                return;
            }

            switch(collectionChangeType)
            {
                case CollectionChangeType.Added:
                    ObservableThemes.Add(new ObservableTheme(trigeredItem));
                    break;
                case CollectionChangeType.Removed:
                    ObservableThemes.RemoveFirst(item => item.Theme ==  trigeredItem);
                    break;
            }
        }
    }
}
