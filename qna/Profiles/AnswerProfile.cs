using AutoMapper;

namespace qna.Profiles;

public class AnswerProfile : Profile
{
    public AnswerProfile()
    {
        CreateMap<Entities.Answer, Models.AnswerDto>();
        CreateMap<Models.AnswerForCreationDto, Entities.Answer>();
    }
}
