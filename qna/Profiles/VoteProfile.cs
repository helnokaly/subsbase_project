using AutoMapper;

namespace qna.Profiles;

public class VoteProfile : Profile
{
    public VoteProfile()
    {
        CreateMap<Models.VoteForCreationDto, Entities.Vote>();
    }
}
