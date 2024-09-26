using Microsoft.EntityFrameworkCore;
using Project.DataBase;
using Project.Interfaces.StudenstInterfaces;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Test
{
	public class IntegrtationFamily
	{
		public readonly DbContextOptions<StudentDbCotext> _dbContextOptions;

		public IntegrtationFamily()
		{
			_dbContextOptions = new DbContextOptionsBuilder<StudentDbCotext>()
			.UseInMemoryDatabase(databaseName: "student_db")
			.Options;
		}

		[Fact]
		public async Task GetStudentsByGroupAsync_KT3120()
		{
			// Arrange
			var ctx = new StudentDbCotext(_dbContextOptions);
			var studentService = new StudentService(ctx);
			var groups = new List<Group>
			{
				new Group
				{
					GroupName = "KT-31-20"
				},
				new Group
				{
					GroupName = "KT-41-20"
				}
			};
			await ctx.Set<Group>().AddRangeAsync(groups);

			var students = new List<Student>
			{
				new Student
				{
					FirstName = "qwerty",
					LastName = "Первый",
					MiddleName = "zxc",
					GroupId = 1,
				},
				new Student
				{
					FirstName = "qwerty2",
					LastName = "Первый",
					MiddleName = "zxc2",
					GroupId = 2,
				},
				new Student
				{
					FirstName = "qwerty3",
					LastName = "asdf3",
					MiddleName = "zxc3",
					GroupId = 1,
				},
				new Student
				{
					FirstName = "qwerty3",
					LastName = "asdf3",
					MiddleName = "zxc3",
					GroupId = 1,
				}
			};
			await ctx.Set<Student>().AddRangeAsync(students);

			await ctx.SaveChangesAsync();

			// Act
			var filter = new Project.Filters.StudentFilters.StudentNameFilter
			{
				Name = "Первый"
			};
			var studentsResult = await studentService.GetStudentsByNameAsync(filter, CancellationToken.None);

			// Assert
			Assert.Equal(2, studentsResult.Length);
		}
	}
}
