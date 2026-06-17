using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Shop;

/// <summary>
/// Заклади для GLOVO
/// </summary>
[Table("tblMerchants")]
public class MerchantEntity
{
    [Key]
    public long Id { get; set; }

    [Required, StringLength(200)]
    public string Name { get; set; } = null!;

    [Required, StringLength(10000)]
    public string Description { get; set; } = null!;

    [Required, StringLength(500)]
    public string Address { get; set; } = null!;

    [StringLength(250)]
    public string? Image { get; set; }

    /// <summary>
    /// Чи активний мерчант
    /// </summary>
    public bool IsActive { get; set; } = true;

    public ICollection<MerchantPartnerEntity> Partners { get; set; }
        = new List<MerchantPartnerEntity>();

    public ICollection<CategoryEntity> Categories { get; set; }
        = new List<CategoryEntity>();

    public ICollection<ProductEntity> Products { get; set; }
        = new List<ProductEntity>();
}
