using Newtonsoft.Json;
using System.ComponentModel;

namespace Majmuah.WebApi.Models.Users;

public class UserUpdateModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime DateOfBirth { get; set; }
    [DefaultValue(false)]
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
    public bool IsBlocked { get; set; }

}