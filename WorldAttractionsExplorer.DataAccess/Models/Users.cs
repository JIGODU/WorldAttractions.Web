using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WorldAttractionsExplorer.Common.Enums;

namespace WorldAttractionsExplorer.DataAccess.Models;

public class Users
{
    public int UserId { get; set; }

    public string UserName { get; set; }

    public string FullName { get; set; }

    public DateTime DateOfJoin { get; set; }

    public string Bio { get; set; }

    public Roles Role { get; set; }

    public string ProfilePicture { get; set; }
}
