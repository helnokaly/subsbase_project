using System.ComponentModel.DataAnnotations;

namespace qna.Models;

public class VoteForCreationDto
{
    [Required]
    [Range(-1, 1)]
    public int Value { get; set; }
}