using Microsoft.AspNetCore.Identity;
using QGReports.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace QGReports.Domain.Models;
public class UserModel : IdentityUser
{ 
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; } 
    public Roles? Role { get; set; }
    public DateTime? LastAction { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}
