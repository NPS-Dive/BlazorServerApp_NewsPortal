using System.ComponentModel.DataAnnotations;


public class News
	{
	[Key]
	public long NewsId { get; set; }

	[Display(Name = "Running TiTle")]
	[Required(ErrorMessage = "Please insert{0}")]
	[MaxLength(100,ErrorMessage = "{0} cant be more than {1} characters")]
	public string NewsTitle { get; set; }

	[Display(Name = "Abstract")]
	[Required(ErrorMessage = "Please insert{0}")]
	[MaxLength(500, ErrorMessage = "{0} cant be more than {1} characters")]
	public string NewsPrecis { get; set; }

	[Display(Name = "main news")]
	[Required(ErrorMessage = "Please insert{0}")]
	public string NewsBody { get; set; }

	[Display(Name = "Date of Post")]
	public DateTime PostDate { get; set; }

	[Display(Name = "Image Name")]
	[Required(ErrorMessage = "Please insert{0}")]
	public string NewsImage { get; set; }

	[Display(Name = "Active/Deactive")]
	public bool IsActive { get; set; }

	public string? CreatedBy { get; set; }

	public string? LastUpdatedBy { get; set;}
	}