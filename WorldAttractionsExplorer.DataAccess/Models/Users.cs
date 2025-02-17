using Microsoft.AspNetCore.Identity;
using WorldAttractionsExplorer.Common.Enums;

namespace WorldAttractionsExplorer.DataAccess.Models;

public class Users : IdentityUser
{
    public string FullName { get; set; }

    public string Email {  get; set; }

    public DateTime DateOfJoin { get; set; }

    public string Bio { get; set; }

    public string ProfilePicture { get; set; }
}
