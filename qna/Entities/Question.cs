using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qna.Entities;

public class Question
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Description { get; set; }
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();

    [ForeignKey("UserId")]
    public User? User { get; set; }
    public int UserId { get; set; }

    public Question(string description)
    {
        this.Description = description;
    }
}
