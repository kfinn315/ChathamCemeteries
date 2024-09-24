using Project.Core.Entities.Business;

namespace Project.Core.Entities.General;

public partial class Grave : Base<int>
{
    public int? CemeteryId { get; set; }

    public string? Name { get; set; }

    public DateModel? Birth { get; set; }

    public int? BirthYear { get; set; }

    public DateModel? Death { get; set; }

    public int? DeathYear { get; set; }
}
