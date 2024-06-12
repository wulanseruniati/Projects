using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
[Table("Order Details")]
public class OrderDetail {
    [Key]
    [Column(Order = 1)]
    public int OrderId {get; set;}
    [Key]
    [Column(Order = 2)]
    public int ProductID {get; set;}
    public Product? Product {get; set;}
}