using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Shop;

/// <summary>
/// Продукти в GLOVO
/// </summary>
[Table("tblProducts")]
public class ProductEntity
{
    [Key]
    public long Id { get; set; }

    [Required, StringLength(500)]
    public string Name { get; set; } = null!;

    [StringLength(10000)]
    public string? Description { get; set; }

    public decimal Price { get; set; }

    [StringLength(250)]
    public string? Image { get; set; }

    /// <summary>
    /// Доступність товару
    /// </summary>
    public bool IsAvailable { get; set; } = true;

    [ForeignKey(nameof(Merchant))]
    public long MerchantId { get; set; }

    public MerchantEntity Merchant { get; set; } = null!;

    [ForeignKey(nameof(Category))]
    public long CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
}
