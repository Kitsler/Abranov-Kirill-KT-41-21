namespace Project.Models
{
	public class Discipline
	{
		public int DisciplineId { get; set; }
		public string DisciplineName { get; set; }

		public ICollection<Group> Groups { get; set; }

		public Discipline() 
		{
			Groups = new List<Group>();
		}
	}
}
