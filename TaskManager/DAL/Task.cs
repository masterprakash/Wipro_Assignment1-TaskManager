using System;
using System.Collections.Generic;

namespace TaskManager.DAL;

public partial class Task
{
    public int TaskId { get; set; }

    public string? TaskDescription { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? ExpectedClosureDate { get; set; }

    public string? AssignedTo { get; set; }

    public string? CompletionStatus { get; set; }
}
