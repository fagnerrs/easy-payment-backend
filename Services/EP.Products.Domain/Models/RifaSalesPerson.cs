using System.Text.Json.Serialization;

namespace EP.Products.Domain.Models;

public class RifaSalesPerson
{
    public long? RifaId { get; set; }
    [JsonIgnore]
    public Rifa? Rifa { get; set; }
    public long SalesPersonId { get; set; }
}