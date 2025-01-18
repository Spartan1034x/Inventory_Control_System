using System;
using System.Collections.Generic;

namespace BullseyeDesktopApp.Models;

public partial class Posn
{
    public override string ToString()
    {
        return this.PermissionLevel;
    }

    public int PositionId { get; set; }

    public string PermissionLevel { get; set; } = null!;

    public sbyte Active { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
