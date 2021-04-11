using System.Linq;
using AutoMapper;
using Bintangku.WebApi.Data.DTO;
using Bintangku.WebApi.Data.Entities;
using Bintangku.WebApi.Extensions;

namespace Bintangku.WebApi.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<NakesUser, MemberNakesUserDto>()
                .ForMember(
                    destination => destination.PhotoUrl, 
                    options => options.MapFrom(
                        source => source.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(
                    destination => destination.Age, 
                    options => options.MapFrom(
                        source => source.DateOfBirth.CalculateAge()));
            CreateMap<ChildData, DataAnakDto>();
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberNakesUserUpdateDto, NakesUser>();
            
        }
    }
}