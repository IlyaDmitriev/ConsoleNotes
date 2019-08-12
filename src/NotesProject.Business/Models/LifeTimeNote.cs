namespace NotesProject.Business.Models
{
	public class LifeTimeNote
	{
		/// <summary>
		/// Количество допустимых просмотров (По умолчанию ставится 1, при удалении заметки 0).
		/// При изменении логики удаления заметок будет проще перестроить логику.
		/// </summary>
		public int Count { get; set; }
	}	
}
