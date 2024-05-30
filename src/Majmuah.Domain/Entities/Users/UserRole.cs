using Majmuah.Domain.Commons;

namespace Majmuah.Domain.Entities.Users;

public class UserRole : Auditable
{
    public string Name {  get; set; }
    public IEnumerable<RolePermission> RolePermissions { get; set; }
    public IEnumerable<User> Users { get; set; }
}