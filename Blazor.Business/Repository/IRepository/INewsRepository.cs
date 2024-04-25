using Blazor.Models.DTOs.News;

namespace Blazor.Business.Repository.IRepository;

public interface INewsRepository
	{
	public Task<NewsDto> CreateNews ( NewsDto newNews );
	public Task<NewsDto> UpdateNews ( long newsID, NewsDto newNews );
	public Task<NewsDto> GetNewsById ( long newsID );
	public Task<IEnumerable<NewsDto>> GetAllNews ();
	public Task<IEnumerable<NewsDto>>  GetAllNewsByCount( int count );
	public Task<NewsDto> IsNewsExistsByTitle ( long newsID, string title );
	public Task<long> DeleteNews ( long newsID );
	public Task<long> DeleteNews ( NewsDto newNews );
	public Task<NewsFiltersDto> FilterNews(NewsFiltersDto filter);
	}