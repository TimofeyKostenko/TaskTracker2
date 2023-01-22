using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{

    public class Project  // represents entity - Project
    {
        [Key]
        
        public int Id { get; set; }


        [Display(Name = "Project name")]
       
        [Required(ErrorMessage = "Enter a project name")]
        [Column("ProjectName")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Invalid length of the name (3 to 50 characters)")]
        public string? ProjectName { get; set; }


        [Display(Name = "Start Date")]
        [Column("StartDate")]
        public DateTime? StartDate { get; set; }


        [Display(Name = "Completion Date")]
        [Column("CompletionDate")]
        public DateTime? CompletionDate { get; set; }


        [Column("Status")]
        public ProjectStatus? Status { get; set; }


        [Column("Priority")]
        [Range(1, 10, ErrorMessage = "Range from 1 to 10 ")]
        public int? Priority { get; set; }

        
        public ICollection<Mission>? Missions { get; set; }
    }

}

