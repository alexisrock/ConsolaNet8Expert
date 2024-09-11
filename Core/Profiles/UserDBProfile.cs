using AutoMapper;
using Domain.DataAccess;
using Domain.Service;


namespace Core.Profiles
{
    public class UserDBProfile : Profile
    {


        public UserDBProfile()
        {
            CreateMap<UsuarioIn, Usuario>()
              .ReverseMap();

            CreateMap<UsuarioDBIn, UsuarioDB>()
             .ReverseMap();

        }
    }
}
