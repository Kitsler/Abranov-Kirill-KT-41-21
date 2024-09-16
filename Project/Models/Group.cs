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
	}
}
