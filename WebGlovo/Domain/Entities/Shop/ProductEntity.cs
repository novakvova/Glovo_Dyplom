using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Shop;

public class ProductEntity
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;
    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string? Image { get; set; }

    public bool IsAvailable { get; set; } = true;

    public long MerchantId { get; set; }
    public MerchantEntity Merchant { get; set; } = null!;

    public long CategoryId { get; set; }
    public CategoryEntity Category { get; set; } = null!;
}
