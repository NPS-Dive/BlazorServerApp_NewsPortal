namespace Blazor.Models.DTOs.Paging;

public static class PagingExtenstion
{
	 public static IQueryable<T> Paging<T>(this IQueryable<T> queryable, BasePaging paging)
	 {
		 return queryable.Skip(paging.Skip).Take(paging.Take);
	 }
}