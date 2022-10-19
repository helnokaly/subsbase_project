using System.ComponentModel.DataAnnotations;

namespace qna.Models;

public class QuestionForCreationDto
{
    [Required]
    [MaxLength(255)]
    public string Description { get; set; } = string.Empty;
}