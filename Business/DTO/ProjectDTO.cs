using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class ProjectDTO
    {
        public string? ProjectName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public ProjectStatus Status { get; set; }
        public int Priority { get; set; }
    }
}
