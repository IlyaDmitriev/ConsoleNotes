using ConsoleNotesProject.Helpers;
using ConsoleNotesProject.Interfaces;
using ConsoleNotesProject.Models.Enums;
using NotesProject.Business.Interfaces;
using NotesProject.Business.Extensions;
using System;

namespace ConsoleNotesProject.Controllers
{
	public class CommandHandler : ICommandHandler
	{
		private readonly INoteController _noteController;
		public CommandHandler(INoteController noteController)
		{
			_noteController = noteController ?? throw new ArgumentNullException(nameof(noteController));
		}

		public void Handle(string strCommand)
		{

			if (!Enum.TryParse(strCommand.Capitalize(), out Command command))
			{
				Console.WriteLine($"Wrong input! Press any key to proceed...");
				Console.ReadKey();
				return;
			}

			Handle(command);
		}

		public void Handle(Command command)
		{
			switch (command)
			{
				case Command.Add:
					_noteController.AddNote();

					Console.WriteLine("Do you want to add another note? (y/n)");
					ActionHelper.DoActionOnResponse(Console.ReadLine(), () => { Handle(Command.Add); }, () => { ConsoleNoteHelper.InitHeader(); });

					break;

				case Command.List:
					_noteController.ShowNotes();

					Console.WriteLine("Press any key to return to the main window...");
					Console.ReadKey();
					ActionHelper.DoActionOnResponse("y", () => { ConsoleNoteHelper.InitHeader(); }, () => { });

					break;

				case Command.Delete:
					_noteController.DeleteNote();

					Console.WriteLine("Do you want to delete another note? (y/n)");
					ActionHelper.DoActionOnResponse(Console.ReadLine(), () => { Handle(Command.Delete); }, () => { ConsoleNoteHelper.InitHeader(); });

					break;

				case Command.Edit:
					_noteController.EditNote();

					Console.WriteLine("Do you want to edit another note? (y/n)");
					ActionHelper.DoActionOnResponse(Console.ReadLine(), () => { Handle(Command.Edit); }, () => { ConsoleNoteHelper.InitHeader(); });

					break;

				case Command.Help:
					_noteController.Help();

					Console.WriteLine("Press any key to return to the main window...");
					Console.ReadKey();
					ActionHelper.DoActionOnResponse("y", () => { ConsoleNoteHelper.InitHeader(); }, () => { });

					break;
			}
		}
	}
}
