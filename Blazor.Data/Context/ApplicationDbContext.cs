//using Blazor.Data.Entities.NewsEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



public class ApplicationDbContext : IdentityDbContext
	{
	public ApplicationDbContext ( DbContextOptions<ApplicationDbContext> options ) : base(options) { }

	public DbSet<News> News { get; set; }
	}