namespace Domain.Entities.Shop;

public class MerchantEntity
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string? Image { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<MerchantPartnerEntity> Partners { get; set; }
        = new List<MerchantPartnerEntity>();

    public ICollection<CategoryEntity> Categories { get; set; }
        = new List<CategoryEntity>();

    public ICollection<ProductEntity> Products { get; set; }
        = new List<ProductEntity>();
}
