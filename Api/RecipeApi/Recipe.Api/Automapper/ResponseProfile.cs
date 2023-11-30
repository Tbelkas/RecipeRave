using AutoMapper;
using Recipe.Api.Automapper.Converters;
using Recipe.Api.Automapper.Models;
using Recipe.Api.Models.Responses.Base;
using Recipe.Common.Models.Responses.Base;

namespace Recipe.Api.Automapper;

// ReSharper disable once UnusedType.Global
public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap(typeof(Response), typeof(ApiResponse<>));
        CreateMap(typeof(Response), typeof(ApiResponse));
        CreateMap(typeof(Response), typeof(ApiResponseTuple<>))
            .ForMember("Response", opt => opt.MapFrom(s => s))
            .ForMember("StatusCode", opt => opt.ConvertUsing(new StatusCodeConverter(), "StatusCode"));
        
        CreateMap<Response, ApiResponseTuple>()
            .ForMember(dest => dest.Response, opt => opt.MapFrom(s => s))
            .ForMember(dest => dest.StatusCode, opt => opt.ConvertUsing(new StatusCodeConverter(), x => x.StatusCode));

        CreateMap(typeof(Response<>), typeof(ApiResponse<>))
            .ForMember("Data", opt => opt.MapFrom("Data"));
      
        CreateMap(typeof(Response<>), typeof(ApiResponseTuple<>))
            .ForMember("Response", opt => opt.MapFrom(s => s))
            .ForMember("StatusCode", opt => opt.ConvertUsing(new StatusCodeConverter(), "StatusCode"));

    }
}