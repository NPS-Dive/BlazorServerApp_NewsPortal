namespace Blazor.Models.DTOs.Paging;

public class Pager
	{
	public static BasePaging BuildPage ( int pageIndex, int take, int entitiesCount, int howManyShowAfterBefore )
		{
		var pageCount = (int)Math.Ceiling(entitiesCount / (double)take);
		return new BasePaging()
			{

			PageIndex = pageIndex,
			Take = take,
			Skip = (pageIndex - 1) * take,
			HowManyShowAfterBefore = howManyShowAfterBefore,
			EntitiesCount = entitiesCount,
			PageCount = pageCount,
			StartPage = pageIndex > howManyShowAfterBefore ? pageIndex - howManyShowAfterBefore : 1,
			EndPage = pageIndex + howManyShowAfterBefore > pageCount ? pageCount : pageCount + howManyShowAfterBefore
			};
		}
	}