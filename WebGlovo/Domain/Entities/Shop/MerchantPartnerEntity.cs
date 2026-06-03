using Domain.Entities.Identity;

namespace Domain.Entities.Shop;

public class MerchantPartnerEntity
{
    public long MerchantId { get; set; }
    public MerchantEntity Merchant { get; set; } = null!;

    public long UserId { get; set; }
    public UserEntity User { get; set; } = null!;

    public long RoleId { get; set; }
    public MerchantRoleEntity Role { get; set; } = null!;

    public bool IsBlocked { get; set; }

    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
}
