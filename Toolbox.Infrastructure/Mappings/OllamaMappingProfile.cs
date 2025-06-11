using Microsoft.Data.SqlClient;
using Toolbox.Infrastructure.DTOs;

namespace Toolbox.Infrastructure.Mappings
{


    namespace Toolbox.Infrastructure.Mappings
    {
        public class OllamaMappingProfile : Profile
        {
            public OllamaMappingProfile()
            {
                // Request entity to Ollama API DTO
                CreateMap<Request, OllamaRequestDto>()
                    .ForMember(dest => dest.Stream, opt => opt.MapFrom(src => true)) // Enable streaming
                    .ForMember(dest => dest.Context, opt => opt.Ignore())
                    .ForMember(dest => dest.Options, opt => opt.Ignore());

                // Ollama API DTO to Request entity
                CreateMap<OllamaRequestDto, Request>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                    .ForMember(dest => dest.Chat, opt => opt.Ignore());

                // Ollama API response DTO to Response entity
                CreateMap<OllamaResponseDto, Response>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.ResponseText, opt => opt.MapFrom(src => src.Response))
                    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => ParseCreatedAt(src.CreatedAt)))
                    .ForMember(dest => dest.Done, opt => opt.MapFrom(src => src.Done))
                    .ForMember(dest => dest.Context, opt => opt.MapFrom(src => src.Context))
                    .ForMember(dest => dest.TotalDuration, opt => opt.MapFrom(src => src.TotalDuration))
                    .ForMember(dest => dest.LoadDuration, opt => opt.MapFrom(src => src.LoadDuration))
                    .ForMember(dest => dest.PromptEvalCount, opt => opt.MapFrom(src => src.PromptEvalCount))
                    .ForMember(dest => dest.PromptEvalDuration, opt => opt.MapFrom(src => src.PromptEvalDuration))
                    .ForMember(dest => dest.EvalCount, opt => opt.MapFrom(src => src.EvalCount))
                    .ForMember(dest => dest.EvalDuration, opt => opt.MapFrom(src => src.EvalDuration))
                    .ForMember(dest => dest.Chat, opt => opt.Ignore());

                // Response entity to Ollama API DTO (for reverse mapping if needed)
                CreateMap<Response, OllamaResponseDto>()
                    .ForMember(dest => dest.Response, opt => opt.MapFrom(src => src.ResponseText))
                    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src =>
                        src.CreatedAt.ToString("yyyy-MM-ddTHH:mm:ss.fffZ")))
                    .ForMember(dest => dest.Done, opt => opt.MapFrom(src => src.Done))
                    .ForMember(dest => dest.Context, opt => opt.MapFrom(src => src.Context))
                    .ForMember(dest => dest.TotalDuration, opt => opt.MapFrom(src => src.TotalDuration))
                    .ForMember(dest => dest.LoadDuration, opt => opt.MapFrom(src => src.LoadDuration))
                    .ForMember(dest => dest.PromptEvalCount, opt => opt.MapFrom(src => src.PromptEvalCount))
                    .ForMember(dest => dest.PromptEvalDuration, opt => opt.MapFrom(src => src.PromptEvalDuration))
                    .ForMember(dest => dest.EvalCount, opt => opt.MapFrom(src => src.EvalCount))
                    .ForMember(dest => dest.EvalDuration, opt => opt.MapFrom(src => src.EvalDuration));

                // OllamaOptionsDto mapping (for request options)
                CreateMap<OllamaOptionsDto, OllamaOptionsDto>()
                    .ForMember(dest => dest.Temperature, opt => opt.MapFrom(src => src.Temperature))
                    .ForMember(dest => dest.TopP, opt => opt.MapFrom(src => src.TopP))
                    .ForMember(dest => dest.TopK, opt => opt.MapFrom(src => src.TopK))
                    .ForMember(dest => dest.NumPredict, opt => opt.MapFrom(src => src.NumPredict))
                    .ForMember(dest => dest.RepeatPenalty, opt => opt.MapFrom(src => src.RepeatPenalty));
            }
            // Helper method for parsing CreatedAt
            private static DateTime ParseCreatedAt(string createdAtString)
            {
                if (string.IsNullOrWhiteSpace(createdAtString))
                    return DateTime.UtcNow;

                DateTime parsedDate;
                if (DateTime.TryParse(createdAtString, out parsedDate))
                    return parsedDate;

                return DateTime.UtcNow;
            }
        }
    }
}
