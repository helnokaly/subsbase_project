using qna.Entities;

namespace qna.Services;

public interface IQuestionRepository
{
    Task<IEnumerable<Question>> GetQuestionsAsync();
    Task<Question?> GetQuestionAsync(int questionId);
    Task AddQuestionAsync(Question question);
    void DeleteQuestion(Question question);
    
    Task<Answer?> GetAnswerAsync(int answerId);
    Task AddAnswerAsync(int questionId, Answer answer);
    void DeleteAnswer(Answer answer);

    Task<Vote?> GetVoteByAnswerIdForUser(int answerId, int userId);
    Task AddVote(int answerId, Vote vote);

    Task<bool> SaveChangesAsync();
}
