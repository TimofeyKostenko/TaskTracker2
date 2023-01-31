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
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Invalid length of the name (3 to 50 characters)")]
        public string? MissionName { get; set; }

        [Display(Name = "Task description")]
        [Required(ErrorMessage = "Enter a task description")]
        [MaxLength(200, ErrorMessage = "The maximum number of characters is 200")]
        public string? Description { get; set; }

        public MissionStatus? Status { get; set; }

        [Range(1, 10, ErrorMessage = "Range from 1 to 10 ")]   
        public int? Priority { get; set; }

        [Display(Name = "Project ID")]
        [Required(ErrorMessage = "Enter a project ID")]
        public int? ProjectId { get; set; }
        
        public Project? Project { get; set; }
    }

}
