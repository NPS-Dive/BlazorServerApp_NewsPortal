using System.ComponentModel.DataAnnotations;

namespace Blazor.Models.DTOs.News;

public class NewsDto
	{
	/// <summary>
	/// Data Transfer Object: what is shown to users
	/// </summary>

	public long NewsId { get; set; }


	[Required]
	[MaxLength(100)]
	public string NewsTitle { get; set; }


	[Required]
	[MaxLength(500)]
	public string NewsPrecis { get; set; }


	[Required]
	public string NewsBody { get; set; }

	[Display(Name = "Date of Post")]
	public DateTime PostDate { get; set; }


	//[Required]
	public string NewsImage { get; set; }


	public bool IsActive { get; set; }
	}