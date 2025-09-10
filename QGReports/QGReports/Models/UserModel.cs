using Microsoft.AspNetCore.Identity;
using QGReports.Domain.Enums;
using QGReports.Domain.Interfaces.IDtos;

namespace QGReports.Domain.Models;
public class UserModel : IdentityUser, IGetIdModel
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? MiddleName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Phone { get; set; }
    public Roles? Role { get; set; }
    public DateTime? LastAction { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}
