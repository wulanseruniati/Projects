using System.ComponentModel.DataAnnotations;

namespace EntityFramework;

public class Product {
    [Key]
    [Required, MaxLength(10)]
    public int ProductId {get; set;}
    [Required, MaxLength(100)]
    public string ProductName {get; set;}
    [Required, MaxLength(10)]
    public int CategoryId {get; set;}
    [Required, MaxLength(10)]
    /*public int Stock { get; set; }
    [Required, MaxLength(10)]
    public int Price { get; set; }*/
    public Category Category {get; set;}
}