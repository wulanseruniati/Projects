using System.ComponentModel.DataAnnotations;

namespace EntityFramework;

public class Category {
    [Key]
    [Required, MaxLength(10)]
    public int CategoryId {get; set;}
    [Required, MaxLength(100)]
    public string CategoryName {get; set;}
    [MaxLength(200)]
    public string Description {get; set;}
    public ICollection<Product> Products {get; set;}
}