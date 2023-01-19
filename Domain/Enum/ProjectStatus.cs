using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Enum
{

     public enum ProjectStatus //  enumerator of project statuses for the entity Project property

    {
        [Display(Name = "NotStarted")]
        NotStarted = 0,

        [Display(Name = "Active")]
        Active = 1,

        [Display(Name = "Completed")]
        Completed = 2
    }
}
