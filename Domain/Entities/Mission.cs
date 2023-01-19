using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Entities
{
    public class Mission  // represents the entity - Task
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Task name")]
        [Required(ErrorMessage = "Enter a task name")]
        [Column("MissionName")]
        public string? MissionName { get; set; }

        

        [Display(Name = "Task description")]
        [Required(ErrorMessage = "Enter a task description")]
        [Column("Description")]

        public string? Description { get; set; }

        [Column("Status")]
        public MissionStatus? Status { get; set; }

        [Column("Priority")]
        public int? Priority { get; set; }

        [Display(Name = "Priject ID")]
        [Required(ErrorMessage = "Enter a project ID")]
        [Column("ProjectId")]
        public int? ProjectId { get; set; }
    }

}
