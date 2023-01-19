using Domain.Enum;
using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Domain.Entities
{

    public class Project  // represents entity - Project
    {
        [Key]
        
        public int Id { get; set; }

        [Display(Name = "Project name")]
        [Required(ErrorMessage = "Enter a project name")]
        [Column("ProjectName")]
        public string? ProjectName { get; set; }

        [Display(Name = "Start Date")]
        [Column("StartDate")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "Completion Date")]
        [Column("CompletionDate")]
        public DateTime? CompletionDate { get; set; }

        [Column("Status")]
        public ProjectStatus Status { get; set; }
        [Column("Priority")]
        public int Priority { get; set; }

    }
}
