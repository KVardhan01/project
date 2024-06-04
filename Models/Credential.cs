using System;
using System.Collections.Generic;

namespace AuhntctionCRUD.Models;

public partial class Credential
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Role { get; set; }
}
