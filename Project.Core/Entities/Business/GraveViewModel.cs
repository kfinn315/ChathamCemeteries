namespace Project.Core.Entities.Business;

public class GraveViewModel
{
    public int Id { get; set; }
    public int? CemeteryId { get; set; }

    public string? Name { get; set; }

    public int? BirthYear { get; set; }

    public int? DeathYear { get; set; }
}
