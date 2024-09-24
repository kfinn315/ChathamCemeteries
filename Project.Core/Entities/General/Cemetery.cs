
namespace Project.Core.Entities.General;

public partial class Cemetery : Base<int>
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Location { get; set; }

    public int? Restricted { get; set; }
}
