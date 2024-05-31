using Majmuah.Domain.Commons;
using Majmuah.Domain.Entities.Collections;
using Majmuah.Domain.Entities.Comments;
using Majmuah.Domain.Entities.Likes;
using Majmuah.Domain.Enums;

namespace Majmuah.Domain.Entities.Users;

public class User : Auditable
{
    public string FirstName {  get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Phone {  get; set; }
    public UserRole UserRole { get; set; }
    public bool IsBlocked { get; set; } = false;
    public IEnumerable<Collection> Collections { get; set; }
    public IEnumerable<Like> Likes { get; set; }
    public IEnumerable<Comment> Comments { get; set; } 
}