using System.Text.Json.Serialization;

namespace EP.Products.Domain.Models;

public class RifaSoldNumber
{
    [JsonIgnore]
    public Rifa? Rifa { get; set; }
    public long? RifaId { get; set; }
    [JsonIgnore]
    public RifaOrder? RifaOrder { get; set; }
    public long? RifaOrderId { get; set; }
    public int Number { get; set; }
    public long Id { get; set; }
}