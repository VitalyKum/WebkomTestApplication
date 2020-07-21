using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Webkom.Stuff
{
    public abstract class Filter
    {
        [Display(Name = "Искать")]
        public string SearchString { get; set; }
        public bool ExtendedMode { get; set; }
    }
}
