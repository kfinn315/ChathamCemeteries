using System.Text.Json.Serialization;

namespace Project.Core.Entities.Business;

public class DateModel
{
    [JsonPropertyName("year")]
    public int? Year { get; set; }
    [JsonPropertyName("month")]
    public int? Month { get; set; }
    [JsonPropertyName("day")]
    public int? Day { get; set; }
}
