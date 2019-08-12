using NotesProject.Business.Interfaces;
using NotesProject.Business.Models;
using System.Collections.Generic;
using System.Linq;

namespace NotesProject.Business.Controllers
{
	public class NoteRepository : INoteRepository
	{
		private static List<Note> Notes { get; set; }
		
		public NoteRepository()
		{
			Notes = new List<Note>(); 
		}

		public void AddNote(string author, string title, string text)
		{
			Notes.Add(new Note
			{
				Id = Notes.Count + 1,
				Author = author,
				Title = title,
				Text = text,
				LifeTime = new LifeTimeNote() { Count = 1 },
			});
		}

		public List<Note> GetNotes()
		{
			return Notes;
		}

		public bool DeleteNote(int id)
		{
			if (!IsNoteExist(id))
			{
				return false;
			}

			Notes.Remove(GetNote(id));
			return true;
		}

		public void EditNote(int id, string title, string text)
		{
			var toEdit = GetNote(id);

			toEdit.Title = title;
			toEdit.Text = text;
		}

		public bool IsNoteExist(int id)
		{
			return Notes.FirstOrDefault(x => x.Id == id) != null;
		}

		public void Help()
		{
			
		}

		public Note GetNote(int id)
		{
			return Notes.First(x => x.Id == id);
		}
	}
}
