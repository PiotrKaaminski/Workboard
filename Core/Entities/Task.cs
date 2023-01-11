using System;
using System.Collections.Generic;

namespace Workboard.Entities;

public partial class Task
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int StatusId { get; set; }

    public virtual TaskStatus Status { get; set; } = null!;
}
