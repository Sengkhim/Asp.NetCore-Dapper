using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Model;

public class UserModel
{
    [Key]
    [Column("UserId")]
    public string UserId { get; set; } = string.Empty;
    [Column("Username")]
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}