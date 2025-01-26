using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMC2.Services.Models
{
    public class Theme
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Guid SectionId { get; set; }
    }
}
