namespace Project.Core.Entities.Business;

public class CemeteryViewModel
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }

    public int? Restricted { get; set; }
}
