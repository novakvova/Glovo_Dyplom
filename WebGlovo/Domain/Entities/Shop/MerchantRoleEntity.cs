using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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


/// <summary>
/// Ролі працівників GLOVO
/// </summary>
[Table("tblMerchantRoles")]
public class MerchantRoleEntity
{
    [Key]
    public long Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(10000)]
    public string? Description { get; set; }

    public ICollection<MerchantPartnerEntity> MerchantPartners { get; set; }
        = new List<MerchantPartnerEntity>();
}