using System.Text.RegularExpressions;

namespace Project.Models
{
	public class Group
	{
		public int GroupId { get; set; }
		public string GroupName { get; set; }

		public ICollection<Discipline> Disciplines { get; set; }
		public Group()
		{
			Disciplines = new List<Discipline>();
		}

		public bool IsValidGroupName()
        {
            return Regex.Match(GroupName, @"\D*-\d*-\d\d").Success;
        }
    }
}
