using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public class MissionDTO
    {
        public string? MissionName { get; set; }

        public string? Description { get; set; }

        public TaskStatus Status { get; set; }

        public int Priority { get; set; }

        public int ProjectId { get; set; }
    }
}
