namespace qna.Models;

public class AnswerDto
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public int UserId { get; set; }
}
