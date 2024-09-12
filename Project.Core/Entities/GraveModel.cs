using System;
using System.Collections.Generic;

namespace Project.Core.Entities;

public partial class GraveModel
{
    public int Id { get; set; }
    public int? CemeteryId { get; set; }

    public string? Name { get; set; }

    public DateModel? Birth { get; set; }
    
    public int? BirthYear { get; set; }

    public DateModel? Death { get; set; }

    public int? DeathYear { get; set; }
}
