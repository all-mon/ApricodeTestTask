using AutoMapper;
using Entities.DTO;
using Entities.Models;

namespace ApiServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Game, GameDto>();
            CreateMap<Genre, GenreDto>();
            CreateMap<GameForCreationDto, Game>();
           // CreateMap<GameForUpdateDto, Game>();
        }
    }
}
