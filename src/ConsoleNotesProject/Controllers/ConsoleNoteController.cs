using System;
using System.Linq;
using ConsoleNotesProject.Helpers;
using ConsoleNotesProject.Models.Enums;
using NotesProject.Business.Interfaces;

namespace ConsoleNotesProject.Controllers
{
	public class ConsoleNoteController : INoteController
	{
		private readonly INoteRepository _noteRepository;

		public ConsoleNoteController(INoteRepository noteRepository)
		{
			_noteRepository = noteRepository ?? throw new ArgumentNullException(nameof(noteRepository));
		}

		public void AddNote()
		{
			ConsoleNoteHelper.InitHeader();

			var author = GetConsoleString("Enter your name");
			var title = GetConsoleString("Enter note title");
			var text = GetConsoleString("Enter note text");

			_noteRepository.AddNote(author, title, text);			

			Console.WriteLine("Note was added.");
		}

		public void ShowNotes()
		{
			var notes = _noteRepository.GetNotes();

			if (notes.Any())
			{
				Console.WriteLine("Here are list of all notes:");

				notes.ForEach(x =>
				{
					Console.WriteLine($"[{x.Id}] - {x.Title}");
				});
			}
			else
			{
				Console.WriteLine("There are zero notes.");
			}
		}

		public void DeleteNote()
		{
			Console.WriteLine("Please enter id of note to delete:");
			var successfulParsing = Int32.TryParse(Console.ReadLine(), out var id);

			if (successfulParsing)
			{
				var isDeleted = _noteRepository.DeleteNote(id);

				if (isDeleted)
				{
					Console.WriteLine($"The note with id [{id}] was successfully deleted.");
				}
				else
				{
					Console.WriteLine($"The note with id [{id}] is not exist in the list of notes.");
				}
			}
			else
			{
				Console.WriteLine($"Id [{id}] is not a number.");
			}
		}

		public void EditNote()
		{
			Console.WriteLine("Please enter id of note to edit:");
			var successfulParsing = Int32.TryParse(Console.ReadLine(), out var id);

			if (successfulParsing)
			{
				var isExist = _noteRepository.IsNoteExist(id);

				if (isExist)
				{
					var toEdit = _noteRepository.GetNote(id);
					Console.WriteLine($"Current title of this note: {toEdit.Title}. Pick a new title:");
					Console.Write("> ");

					var newTitle = Console.ReadLine();
					Console.WriteLine($"Are you sure (y/n)?");

					var response = Console.ReadLine();

					Action actionYes = () =>
					{
						Console.WriteLine("Title was successfully changed.");
						Console.WriteLine("Current text of this note:");
						Console.WriteLine(toEdit.Text);
						Console.WriteLine("Now you can change the text:");
						Console.Write("> ");

						var newText = Console.ReadLine();
						_noteRepository.EditNote(toEdit.Id, newTitle, newText);
						Console.WriteLine("Text was successfully changed.");
					};

					ActionHelper.DoActionOnResponse(response, actionYes, () => { ConsoleNoteHelper.InitHeader(); });
				}
				else
				{
					Console.WriteLine($"The note with id [{id}] is not exist in the list of notes.");
				}
			}
			else
			{
				Console.WriteLine($"Id [{id}] is not a number.");
			}
		}

		public void Help()
		{
			ConsoleNoteHelper.InitHeader();

			Console.WriteLine("#################################################################");
			Console.WriteLine("#                        List of command                        #");
			Console.WriteLine($"#  1. Enter '{nameof(Command.Add)}', if you need to create new note               #");
			Console.WriteLine($"#  2. Enter '{nameof(Command.List)}', if you need to show all created notes       #");
			Console.WriteLine($"#  3. Enter '{nameof(Command.Delete)}', if you need to delete note                #");
			Console.WriteLine($"#  4. Enter '{nameof(Command.Edit)}', if you need to change text note             #");
			Console.WriteLine($"#  5. Enter '{nameof(Command.Help)}', if you need help                            #");
			Console.WriteLine("#################################################################");
		}

		private string GetConsoleString(string message)
		{
			Console.WriteLine(message);
			Console.Write("> ");
			return Console.ReadLine();
		}
	}
}
