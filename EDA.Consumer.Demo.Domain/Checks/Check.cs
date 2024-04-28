using System.ComponentModel.DataAnnotations.Schema;

namespace EDA.Consumer.Demo.Domain.Checks;

public class Check
{
    [Column("id")]
    public Guid Id { get; private set; }
    [Column("name")]
    public string Name { get; private set; }
    [Column("amount")]
    public decimal Amount { get; private set; }
    [Column("isgenerated")]
    public bool IsGenerated { get; private set; }
    
    public void Generate()
    {
        IsGenerated = true;
    }
}