using AutoMapper;

namespace BoardgameApi.Model;

public class ApiProfile : Profile
{
    public ApiProfile()
    {
        CreateMap<NewMatchRequest, Match>().ReverseMap();
    }
}
