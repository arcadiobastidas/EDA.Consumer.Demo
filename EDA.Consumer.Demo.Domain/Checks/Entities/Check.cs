using System.ComponentModel.DataAnnotations.Schema;

namespace EDA.Consumer.Demo.Domain.Checks;

public class Check
{
    [Column("id")]
    public Guid Id { get;  set; }
    [Column("name")]
    public string Name { get;  set;} = string.Empty;
    [Column("amount")]
    public decimal Amount { get;  set; }
    [Column("isgenerated")]
    public bool IsGenerated { get; private set; }
    
    public void Generate()
    {
        IsGenerated = true;
    }
}