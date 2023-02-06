
using Domain.Enum;

namespace Business.DTO
{
    public class ProjectDTO
    {
        public string? ProjectName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public ProjectStatus? Status { get; set; }

        public int? Priority { get; set; }

        public List<MissionDTO>? ProjectMissions { get; set; }
    }
}
