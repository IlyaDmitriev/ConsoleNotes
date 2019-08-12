using NotesProject.Business.Models;
using System.Collections.Generic;

namespace NotesProject.Business.Interfaces
{
	public interface INoteRepository
	{
		void AddNote(string author, string title, string text);
		List<Note> GetNotes();
		bool DeleteNote(int id);
		void EditNote(int id, string title, string text);
		void Help();
		bool IsNoteExist(int id);
		Note GetNote(int id);
	}
}
