using System;
using System.Collections.Generic;

namespace AuhntctionCRUD.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public int? ManagerId { get; set; }

    public string? StudentName { get; set; }

    public string? StudentEmail { get; set; }

    public string? StudentPassword { get; set; }

    public string? Task { get; set; }

    public string? Status { get; set; }

    public virtual ManagerList? Manager { get; set; }
}
