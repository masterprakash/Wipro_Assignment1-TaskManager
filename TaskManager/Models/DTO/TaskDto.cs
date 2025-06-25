namespace TaskManager.Models.DTO
{
    public class TaskDto
    {
        public int TaskID { get; set; }
        public string? TaskDescription { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? ExpectedClosureDate { get; set; }
        public string? AssignedTo { get; set; }
        public string? CompletionStatus { get; set; }
    }
}

