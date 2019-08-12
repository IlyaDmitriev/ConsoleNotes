namespace NotesProject.Business.Models
{
	public class Note
	{
		/// <summary>
		/// Уникальный идентификатор.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Текст заметки.
		/// </summary>
		public string Text { get; set; }

		/// <summary>
		/// Автор.
		/// </summary>
		public string Author { get; set; }

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Жизненый цикл заметки.
		/// </summary>
		public LifeTimeNote LifeTime { get; set; }
	}
}
