//see SunburstItemNode.ts
namespace Project.Core.Entities.Business;

public class NodeViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int? Size { get; set; }
    public NodeViewModel[]? Children { get; set; }
}
