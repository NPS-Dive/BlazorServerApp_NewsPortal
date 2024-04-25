using Blazor.Models.DTOs.Paging;

namespace Blazor.Models.DTOs.News;

public class NewsFiltersDto : BasePaging
	{
	public string Title { get; set; }
	public List<NewsDto> NewsList { get; set; }

	public NewsFiltersDto SetPaging ( BasePaging paging )
		{
		PageIndex = paging.PageIndex;
		Take = paging.Take;
		Skip = paging.Skip;
		EntitiesCount = paging.EntitiesCount;
		PageCount = paging.PageCount;
		StartPage = paging.StartPage;
		EndPage = paging.EndPage;
		HowManyShowAfterBefore = paging.HowManyShowAfterBefore;
		return this;
		}
	}