using AutoMapper;
//using Blazor.Data.Entities.NewsEntities;
using Blazor.Models.DTOs.News;

namespace Blazor.Business.Mapper;

public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<NewsDto, News>();
			CreateMap<News, NewsDto>();
		}
	}