using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Shop;

public class CategoryEntity
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public long MerchantId { get; set; }
    public MerchantEntity Merchant { get; set; } = null!;

    public long? ParentId { get; set; }
    public CategoryEntity? Parent { get; set; }

    public ICollection<CategoryEntity> Children { get; set; }
        = new List<CategoryEntity>();

    public ICollection<ProductEntity> Products { get; set; }
        = new List<ProductEntity>();
}
