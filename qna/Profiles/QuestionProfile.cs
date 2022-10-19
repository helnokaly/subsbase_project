using AutoMapper;

namespace qna.Profiles;

public class QuestionProfile : Profile
{
    public QuestionProfile()
    {
        CreateMap<Entities.Question, Models.QuestionDto>();
        CreateMap<Models.QuestionForCreationDto, Entities.Question>();
    }
}
