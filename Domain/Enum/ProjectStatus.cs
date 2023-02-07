using System.ComponentModel.DataAnnotations;


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
