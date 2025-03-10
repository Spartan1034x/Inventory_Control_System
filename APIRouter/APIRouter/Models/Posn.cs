using System;
using System.Collections.Generic;

namespace APIRouter.Models;

public partial class Posn
{
    public int PositionId { get; set; }

    public string PermissionLevel { get; set; } = null!;

    public sbyte Active { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
