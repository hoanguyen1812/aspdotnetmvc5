using AutoMapper;
using MVC5.Dtos;
using MVC5.Models;

namespace MVC5.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDto>()
                    .ForMember(c => c.Id, opt => opt.Ignore());
                cfg.CreateMap<Movie, MovieDto>()
                    .ForMember(m => m.Id, opt => opt.Ignore());
                cfg.CreateMap<MembershipType, MembershipTypeDto>();
                cfg.CreateMap<Genre, GenreDto>();
            });

            config.CreateMapper();
        }
    }
}