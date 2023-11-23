using System.Net;
using AutoMapper;
using Recipe.Api.Automapper.Converters;
using Recipe.Api.Models.AutoMapper;
using Recipe.Api.Models.Responses.Base;
using Recipe.Common.Models.Responses.Base;

namespace Recipe.Api.Automapper;

public class ResponseProfile : Profile
{
    public ResponseProfile()
    {
        CreateMap<Response, ApiResponse>();
        CreateMap(typeof(DataResponse<>), typeof(ApiDataResponse<>));
        CreateMap<Response, ApiResponseTuple>()
            .ForMember(dest => dest.Response, opt => opt.MapFrom(s => s))
            .ForMember(dest => dest.StatusCode, opt => opt.ConvertUsing(new StatusCodeConverter(), x => x.StatusCode));
        CreateMap(typeof(DataResponse<>), typeof(DataApiResponseTuple<>)).ForMember("Response", opt => opt.MapFrom(src => src));
    }
}