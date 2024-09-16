using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Models;

namespace Project.DataBase.Configurations
{
	public class GroupConfiguration : IEntityTypeConfiguration<Group>
	{
		private const string TableName = "cd_group";

		public void Configure(EntityTypeBuilder<Group> builder)
		{

		}
	}
}
