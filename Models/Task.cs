using System;
using System.Collections.Generic;

namespace AuhntctionCRUD.Models;

public partial class Task
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public string? TaskName { get; set; }
}
