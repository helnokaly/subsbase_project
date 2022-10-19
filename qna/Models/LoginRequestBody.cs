using System.ComponentModel.DataAnnotations;

namespace qna.Models;

public class LoginRequestBody
{
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}
