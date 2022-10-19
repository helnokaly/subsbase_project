using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qna.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string AuthId { get; set; }

    public User(string username, string password, string authId)
    {
        this.Username = username;
        this.Password = password;
        this.AuthId = authId;
    }
}
