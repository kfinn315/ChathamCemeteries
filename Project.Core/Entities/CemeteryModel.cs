using System;
using System.Collections.Generic;

namespace Project.Core.Entities;

public partial class CemeteryModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }

    public int? Restricted { get; set; }
}
