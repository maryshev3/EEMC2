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
        public SectionFull SectionFull { get; private set; }

        public ObservableSectionFull(SectionFull sectionFull)
        {
            SectionFull = sectionFull;
        }

        public string SectionName
        {
            get => SectionFull.Section.Name;
            set => SetProperty(
                SectionFull.Section.Name,
                value,
                SectionFull,
                (sectionFull, sectionName) => sectionFull.Section.Name = sectionName
            );
        }
    }
}
