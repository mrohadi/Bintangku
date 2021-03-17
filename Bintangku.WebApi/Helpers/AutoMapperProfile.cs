using System.Linq;
using AutoMapper;
using Bintangku.Data.DTO;
using Bintangku.Data.Entities;
using Bintangku.Data.Extensions;

namespace Bintangku.Services.Helpers
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
            CreateMap<DataAnak, DataAnakDto>();
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberNakesUserUpdateDto, NakesUser>();
            
        }
    }
}