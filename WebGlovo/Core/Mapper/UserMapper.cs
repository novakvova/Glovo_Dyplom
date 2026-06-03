using Core.Models.Account;
using Domain.Entities.Identity;
using Riok.Mapperly.Abstractions;

namespace Core.Mapper;

[Mapper]
public partial class UserMapper
{
    [MapperIgnoreTarget(nameof(UserEntity.Image))]
    [MapProperty(nameof(GoogleAccountModel.Email), nameof(UserEntity.UserName))]
    public partial UserEntity GoogleAccountToUser(GoogleAccountModel googleAccount);

    [MapProperty(nameof(RegisterModel.Email), nameof(UserEntity.UserName))]
    [MapperIgnoreTarget(nameof(UserEntity.Image))]
    public partial UserEntity RegisterToUser(RegisterModel source);
}
