using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Component {
    [Key]
    public int ComponentID {get; set;}
    [Column(TypeName = "TEXT")]
    public string ComponentName {get; set;} = null!;
    [Column("Description", TypeName = "TEXT")]
    public string? ComponentDesc {get; set;}    
    public Guid ItemId {get; set;}
}