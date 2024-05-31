using Majmuah.Domain.Enums;

namespace Majmuah.WebApi.Models.Users;

public class UserCreateModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool IsBlocked { get; set; }
    public UserRole UserRole {  get; set; }
    public string PasswordHash { get; set; }
    public DateTime DateOfBirth { get; set; }
}