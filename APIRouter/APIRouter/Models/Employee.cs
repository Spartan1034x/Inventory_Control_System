using System;
using System.Collections.Generic;

namespace APIRouter.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string Password { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Email { get; set; }

    public bool Active { get; set; }

    public int PositionId { get; set; }

    public int SiteId { get; set; }

    public virtual Posn Position { get; set; } = null!;

    public virtual Site Site { get; set; } = null!;
}
