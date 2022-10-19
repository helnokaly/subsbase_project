namespace qna.Models;

public class QuestionDto
{
    public int Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public int UserId { get; set; }
    public ICollection<AnswerDto> Answers { get; set; } = new List<AnswerDto>();
}
