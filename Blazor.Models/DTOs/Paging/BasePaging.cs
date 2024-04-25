namespace Blazor.Models.DTOs.Paging;

public class BasePaging
	{
	public BasePaging ()
		{
		PageIndex = 1;
		Take = 5;
		HowManyShowAfterBefore = 4;
		} 

	public int PageIndex { get; set; }
	public int StartPage { get; set; }
	public int EndPage { get; set; }
	public int Take { get; set; }
	public int Skip { get; set; }
	public int HowManyShowAfterBefore { get; set; }
	public int PageSize { get; set; } = 10;
	public int PageCount { get; set; }
	public int TotalPages { get; set; }
	public int EntitiesCount { get; set; }

	}