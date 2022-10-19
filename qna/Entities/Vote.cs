using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace qna.Entities;

public class Vote
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int Value { get; set; }

    [ForeignKey("AnswerId")]
    public Answer? Answer { get; set; }
    public int AnswerId { get; set; }

    [ForeignKey("UserId")]
    public User? User { get; set; }
    public int UserId { get; set; }

    public Vote(int value)
    {
        this.Value = value;
    }
}
