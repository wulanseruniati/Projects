using System.ComponentModel.DataAnnotations;

namespace EntityFramework;

public class Order {
    [Key]
    [Required, MaxLength(10)]
    public int OrderId {get; set;}
    [Required, MaxLength(10)]
    public int ProductId {get; set;}
    [Required, MaxLength(10)]
    public int OrderQty {get; set;}
    [Required, MaxLength(10)]
    public int OrderPrice {get; set;}
    public ICollection<Product> Products {get; set;}
}