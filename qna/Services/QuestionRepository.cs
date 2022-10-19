using qna.Entities;
using qna.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace qna.Services;

public class QuestionRepository : IQuestionRepository
{
    private readonly QnaContext _context;

    public QuestionRepository(QnaContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<Question>> GetQuestionsAsync()
    {
        // TODO:
        // Question Rank
        // Listing questions (GET /questions) returns results ordered descendingly by QuestionRank as defined below::

        // QuestionRank = {MaxUpVotes} * {AnswersCount} - {CountOfDownVotedAnswers}

        // Where:
        //     MaxUpVotes is the total number of upvotes on the most upvoted answer
        //     AnswersCount is the total count of answers for that specific question (up or down voted)
        //     CountOfDownVotedAnswers is the count of answers with VoteScore < 0
        
        return await _context
            .Questions
            .Include(q => q.Answers)
            .ToListAsync();
    }

    public async Task<Question?> GetQuestionAsync(int questionId)
    {
        return await _context
            .Questions
            .Include(q => q.Answers)
            .Where(q => q.Id == questionId)
            .FirstOrDefaultAsync();
    }

    public async Task AddQuestionAsync(Question question)
    {
        await _context.Questions.AddAsync(question);
    }

    public void DeleteQuestion(Question question)
    {
        _context.Remove(question);
    }

    public async Task<Answer?> GetAnswerAsync(int answerId)
    {
        return await _context
            .Answers
            .Where(a => a.Id == answerId)
            .FirstOrDefaultAsync();
    }

    public async Task AddAnswerAsync(int questionId, Answer answer)
    {
        var question = await GetQuestionAsync(questionId);
        if (question != null)
        {
            answer.QuestionId = questionId;
            await _context.Answers.AddAsync(answer);
        }
    }

    public void DeleteAnswer(Answer answer)
    {
        _context.Remove(answer);
    }

    public async Task<Vote?> GetVoteByAnswerIdForUser(int answerId, int userId)
    {
        return await _context
            .Votes
            .Where(v => v.AnswerId == answerId && v.UserId == userId)
            .FirstOrDefaultAsync();
    }

    public async Task AddVote(int answerId, Vote vote)
    {
        var answer = await GetQuestionAsync(answerId);
        if (answer != null)
        {
            vote.AnswerId = answerId;
            await _context.Votes.AddAsync(vote);
        }
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await _context.SaveChangesAsync()) >= 0;
    }
}
