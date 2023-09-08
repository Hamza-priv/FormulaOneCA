using AutoMapper;
using FormulaOne.Entity.Dtos.Request;
using FormulaOne.Entity.Dtos.Response;
using FormulaOne.Entity.Model;

namespace FormulaOne.Api.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {                             // we are saying if status then set status to 1 and dates to the date at that time

                     //source                destination
            CreateMap<AchievementRequestDto, Achievement>()
                .ForMember(dest => dest.status, op => op.MapFrom(src => 1))
                .ForMember(dest => dest.createdDate, op => op.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.updatedDate, op => op.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateAchievementRequestDto, Achievement>()
                .ForMember(dest => dest.updatedDate, op => op.MapFrom(src => DateTime.UtcNow));

            CreateMap<Achievement, AchievementResponeDto>();

            CreateMap<Driver, DriverResponseDto>()
                .ForMember(dest => dest.FullName, op => op.MapFrom(src => $"{src.firstName} {src.lastName}"));

            CreateMap<CreateDriverRequestDto, Driver>()
                .ForMember(dest => dest.status, op => op.MapFrom(src => 1))
                .ForMember(dest => dest.createdDate, op => op.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.updatedDate, op => op.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateDriverRequestDto, Driver>()
                .ForMember(dest => dest.updatedDate, op => op.MapFrom(src => DateTime.UtcNow));

            CreateMap<Achievement, Achievement>();
        }
    }
}
