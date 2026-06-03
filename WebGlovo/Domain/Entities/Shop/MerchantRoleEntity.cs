using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Shop;

/*
 
 new MerchantRoleEntity
{
    Id = 1,
    Name = "Owner",
    Description = "Повний доступ до закладу"
};

new MerchantRoleEntity
{
    Id = 2,
    Name = "Manager",
    Description = "Управління товарами та категоріями"
};

new MerchantRoleEntity
{
    Id = 3,
    Name = "Editor",
    Description = "Редагування товарів"
};

new MerchantRoleEntity
{
    Id = 4,
    Name = "Viewer",
    Description = "Лише перегляд"
};
 */



public class MerchantRoleEntity
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public ICollection<MerchantPartnerEntity> MerchantPartners { get; set; }
        = new List<MerchantPartnerEntity>();
}