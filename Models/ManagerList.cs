using System;
using System.Collections.Generic;

namespace AuhntctionCRUD.Models;

public partial class ManagerList
{
    public int ManagerId { get; set; }

    public string? ManagerName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Technology { get; set; }

    public virtual ICollection<Student> Students { get; } = new List<Student>();
}
