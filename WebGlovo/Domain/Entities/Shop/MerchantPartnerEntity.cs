using Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Shop;

/// <summary>
/// Який користувач до якого закладу має доступ і яка його роль
/// </summary>
[Table("tblMerchantPartners")]
public class MerchantPartnerEntity
{
    [ForeignKey(nameof(Merchant))]
    public long MerchantId { get; set; }

    public MerchantEntity Merchant { get; set; } = null!;

    [ForeignKey(nameof(User))]
    public long UserId { get; set; }

    public UserEntity User { get; set; } = null!;

    [ForeignKey(nameof(Role))]
    public long RoleId { get; set; }

    public MerchantRoleEntity Role { get; set; } = null!;

    /// <summary>
    /// Чи заблокований партнер
    /// </summary>
    public bool IsBlocked { get; set; }

    /// <summary>
    /// Дата приєднання до магазину
    /// </summary>
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
}
