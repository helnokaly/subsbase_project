using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using qna.Models;
using qna.Services;
using qna.Entities;

namespace qna.Controllers;

[ApiController]
[Route("questions")]
public class QuestionsController : ControllerBase
{
    private readonly ILogger<QuestionsController> _logger;
    private readonly IQuestionRepository _questionRepository;
    private readonly IMapper _mapper;

    public QuestionsController(
        ILogger<QuestionsController> logger,
        IQuestionRepository questionRepository,
        IMapper mapper)
    {
        _logger = logger;
        _questionRepository = questionRepository ?? throw new ArgumentException(nameof(questionRepository));
        _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
    }

    [HttpGet]
    public async Task<ActionResult<List<QuestionDto>>> GetQuestions()
    {
        var questionEntities = await _questionRepository.GetQuestionsAsync();
        return Ok(_mapper.Map<IEnumerable<QuestionDto>>(questionEntities));
    }

    [HttpGet("{questionId}", Name = "GetQuestion")]
    public async Task<ActionResult<QuestionDto>> GetQuestion(int questionId)
    {
        var questionEntity = await _questionRepository.GetQuestionAsync(questionId);
        if (questionEntity == null)
        {
            return this.NotFound();
        }

        return this.Ok(_mapper.Map<QuestionDto>(questionEntity));
    }

    [HttpPost]
    public async Task<ActionResult<QuestionDto>> CreateQuestion(QuestionForCreationDto questionForCreationDto)
    {
        var question = _mapper.Map<Question>(questionForCreationDto);
        question.UserId = (int)HttpContext.Items["USER_ID"]!;
        await _questionRepository.AddQuestionAsync(question);
        await _questionRepository.SaveChangesAsync();
        var questionDto = _mapper.Map<QuestionDto>(question);
        return this.CreatedAtRoute("GetQuestion", new { questionId = question.Id }, questionDto);
    }

    [HttpDelete("{questionId}")]
    public async Task<ActionResult> DeleteQuestion(int questionId)
    {
        var questionEntity = await _questionRepository.GetQuestionAsync(questionId);
        if (questionEntity == null)
        {
            return this.NotFound();
        }
        _questionRepository.DeleteQuestion(questionEntity);
        await _questionRepository.SaveChangesAsync();
        return this.NoContent();
    }
}
