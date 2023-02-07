using System.ComponentModel.DataAnnotations;

namespace Domain.Enum
{
    public enum MissionStatus // status enumerator of the task for the property of the Mission
    {
        [Display(Name = "ToDo")]
        ToDo = 0,

        [Display(Name = "InProgress")]
        InProgress = 1,

        [Display(Name = "Done")]
        Done = 2
    }
}
