using CommunityToolkit.Mvvm.ComponentModel;
using EEMC2.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.Models
{
    public class ObservableSectionFull : ObservableObject
    {
        private readonly SectionFull _sectionFull;

        public ObservableSectionFull(SectionFull sectionFull)
        {
            _sectionFull = sectionFull;
        }

        public string SectionName
        {
            get => _sectionFull.Section.Name;
            set => SetProperty(
                _sectionFull.Section.Name,
                value,
                _sectionFull,
                (sectionFull, sectionName) => sectionFull.Section.Name = sectionName
            );
        }
    }
}
