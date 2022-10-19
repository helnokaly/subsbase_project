using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using qna.Models;
using qna.Services;
using qna.Entities;

namespace qna.Controllers;

[ApiController]
[Route("questions/{questionId}/answers")]
public class AnswersController : ControllerBase
{
    private readonly ILogger<AnswersController> _logger;
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public AnswersController(ILogger<AnswersController> logger, IQuestionRepository questionRepository, IMapper mapper)
    {
        _logger = logger;
        _questionRepository = questionRepository ?? throw new ArgumentException(nameof(questionRepository));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    [HttpPost]
    public async Task<ActionResult<AnswerDto>> AddAnswer(int questionId, AnswerForCreationDto answerForCreationDto)
    {
        var question = await _questionRepository.GetQuestionAsync(questionId);
        if (question == null)
        {
            return this.NotFound();
        }

        var answer = _mapper.Map<Answer>(answerForCreationDto);
        answer.UserId = (int)HttpContext.Items["USER_ID"]!;

        await _questionRepository.AddAnswerAsync(question.Id, answer);
        await _questionRepository.SaveChangesAsync();
        var answerDto = _mapper.Map<AnswerDto>(answer);
        return this.Ok(answerDto);
    }

    [HttpDelete("{answerId}")]
    public async Task<ActionResult> DeleteAnswer(int questionId, int answerId)
    {
        var question = await _questionRepository.GetQuestionAsync(questionId);
        if (question == null)
        {
            return NotFound();
        }

        var answer = await _questionRepository.GetAnswerAsync(answerId);
        if (answer == null)
        {
            return NotFound();
        }

        _questionRepository.DeleteAnswer(answer);
        await _questionRepository.SaveChangesAsync();
        return NoContent();
    }

    [HttpPut("{answerId}/votes")]
    public async Task<ActionResult> Vote(int questionId, int answerId, VoteForCreationDto voteForCreationDto)
    {
        var question = await _questionRepository.GetQuestionAsync(questionId);
        if (question == null)
        {
            return NotFound();
        }

        var answer = await _questionRepository.GetAnswerAsync(answerId);
        if (answer == null)
        {
            return NotFound();
        }

        var userId = (int)HttpContext.Items["USER_ID"]!;
        var vote = await _questionRepository.GetVoteByAnswerIdForUser(answerId, userId);
        if (vote == null)
        {
            vote = new Vote(voteForCreationDto.Value);
            vote.UserId = userId;
            vote.AnswerId = answerId;
            System.Console.WriteLine("Add Vote");
            await _questionRepository.AddVote(answerId, vote);
        } else
        {
            vote.Value = voteForCreationDto.Value;
        }

        await _questionRepository.SaveChangesAsync();
        return Ok();
    }
}
