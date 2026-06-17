using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Shop;

/// <summary>
/// Категорії закладу - продуктів
/// </summary>
[Table("tblCategories")]
public class CategoryEntity
{
    [Key]
    public long Id { get; set; }

    [Required, StringLength(200)]
    public string Name { get; set; } = null!;

    [ForeignKey(nameof(Merchant))]
    public long MerchantId { get; set; }

    public MerchantEntity Merchant { get; set; } = null!;

    [ForeignKey(nameof(Parent))]
    public long? ParentId { get; set; }

    public CategoryEntity? Parent { get; set; }

    public ICollection<CategoryEntity> Children { get; set; }
        = new List<CategoryEntity>();

    public ICollection<ProductEntity> Products { get; set; }
        = new List<ProductEntity>();
}
