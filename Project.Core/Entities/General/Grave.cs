namespace Project.Core.Entities.General;

public partial class Grave : Base<int>
{
    public int? CemeteryId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public int? BirthYear { get; set; }

    public int? DeathYear { get; set; }

    public virtual Cemetery? Cemetery { get; set; }
}
