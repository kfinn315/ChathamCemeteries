using System.Text.Json.Serialization;

namespace Project.Core.Entities;

public partial class DateModel
{
    [JsonPropertyName("year")]
    public int? Year { get; set; }
    [JsonPropertyName("month")]
    public int? Month { get; set; }
    [JsonPropertyName("day")]
    public int? Day { get; set; }
}
