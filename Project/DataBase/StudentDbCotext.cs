using Microsoft.EntityFrameworkCore;
using Project.DataBase.Configurations;
using Project.Models;

namespace Project.DataBase
{
	public class StudentDbCotext : DbContext
	{
		DbSet<Student> students {  get; set; }
		DbSet<Group> groups {  get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new StudentCofiguration());
			modelBuilder.ApplyConfiguration(new GroupConfiguration());
		}
		public StudentDbCotext(DbContextOptions<StudentDbCotext> options) : base(options) 
		{ 

		}
	}
}
