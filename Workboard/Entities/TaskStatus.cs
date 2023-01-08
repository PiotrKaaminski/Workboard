using System;
using System.Collections.Generic;

namespace Workboard.Entities;

public partial class TaskStatus
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
}
