using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qna.Entities;

public class Answer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(255)]
    public string Description { get; set; }
    
    [ForeignKey("QuestionId")]
    public Question? Question { get; set; }
    public int QuestionId { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; }
    public int UserId { get; set; }

    public Answer(string description)
    {
        this.Description = description;
    }
}
