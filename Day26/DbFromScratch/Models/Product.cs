using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Product {
    [Key]
    public int ProductID {get; set;}
    [Column(TypeName = "TEXT")]
    public string? ProductName {get; set;}
    [Column("Description", TypeName = "TEXT")]
    public string? ProductDesc {get; set;}
    public int CategoryId {get; set;}
    public int? Price {get; set;}
    public Category? Category {get; set;}
}