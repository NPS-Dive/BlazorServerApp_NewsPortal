using AutoMapper;
using Blazor.Business.Repository.IRepository;
//using Blazor.Data.Context;
//using Blazor.Data.Entities.NewsEntities;
using Blazor.Models.DTOs.News;
using Blazor.Models.DTOs.Paging;
using Microsoft.EntityFrameworkCore;


namespace Blazor.Business.Repository;

public class NewsRepository : INewsRepository
	{
	#region Constructor

	private readonly ApplicationDbContext _context;
	private readonly IMapper _mapper;

	public NewsRepository ( ApplicationDbContext context, IMapper mapper )
		{
		_context = context;
		_mapper = mapper;
		}

	#endregion


	public async Task<NewsDto> CreateNews ( NewsDto newNews )
		{
		var news = _mapper.Map<NewsDto, News>(newNews);
		news.CreatedBy = "";
		news.PostDate = DateTime.Now;
		var newlyAddedNews = await _context.News.AddAsync(news);
		await _context.SaveChangesAsync();
		return _mapper.Map<News, NewsDto>(newlyAddedNews.Entity);
		}

	public async Task<NewsDto> UpdateNews ( long newsID, NewsDto newNews )
		{
		try
			{
			if (newsID == newNews.NewsId)
				{
				News newsDetails = await _context.News.FindAsync(newsID);
				News news = _mapper.Map<NewsDto, News>(newNews, newsDetails);
				news.LastUpdatedBy = "";
				_context.News.Update(news);
				await _context.SaveChangesAsync();
				return _mapper.Map<News, NewsDto>(news);
				}
			else
				{
				return null;
				}
			}
		catch (Exception e)
			{
			return null;
			}
		}

	public async Task<NewsDto> GetNewsById ( long newsID )
		{
		try
			{
			NewsDto news = _mapper.Map<News, NewsDto>(await _context.News.SingleOrDefaultAsync(p => p.NewsId == newsID));
			return news;
			}
		catch (Exception e)
			{
			return null;
			}
		}

	public async Task<IEnumerable<NewsDto>> GetAllNews ()
		{
		try
			{
			IEnumerable<NewsDto> newsDtos = _mapper.Map<IEnumerable<News>, IEnumerable<NewsDto>>(await _context.News.ToListAsync());
			return newsDtos;
			}
		catch (Exception e)
			{
			return null;
			}
		}

	public async Task<IEnumerable<NewsDto>> GetAllNewsByCount ( int count )
		{
		try
			{
			var data = await _context
				.News
				.OrderByDescending(or => or.PostDate)
				.Take(count)
				.ToListAsync();

			IEnumerable<NewsDto> newsDtos = _mapper.Map<IEnumerable<News>, IEnumerable<NewsDto>>(data);

			return newsDtos;
			}
		catch (Exception e)
			{
			return null;
			}
		}

	public async Task<NewsDto> IsNewsExistsByTitle ( long newsID, string title )
		{
		return _mapper.Map<News, NewsDto>(await _context.News.FirstOrDefaultAsync(p => p.NewsTitle == title && p.NewsId != newsID));
		}

	public async Task<long> DeleteNews ( long newsID )
		{
		var news = await _context.News.FindAsync(newsID);
		if (news != null)
			{
			_context.News.Remove(news);
			await _context.SaveChangesAsync();
			return news.NewsId;
			}

		return 0;
		}

	public async Task<long> DeleteNews ( NewsDto newNews )
		{
		return await DeleteNews(newNews.NewsId);
		}

	public async Task<NewsFiltersDto> FilterNews ( NewsFiltersDto filter )
		{
		var query = _context.News.AsQueryable();
		if (!string.IsNullOrEmpty(filter.Title))
			{
			query.Where(s => EF.Functions.Like(s.NewsTitle, $"%{filter.Title}%"));
			}

		var entitiesCount = await query.CountAsync();
		var pager = Pager.BuildPage(filter.PageIndex, filter.Take, entitiesCount, filter.HowManyShowAfterBefore);

		var newsList= await query.Paging(pager).ToListAsync();

		filter.NewsList = _mapper.Map<List<News>, List<NewsDto>>(newsList);

		return filter.SetPaging(pager);
		}
	}