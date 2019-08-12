using ConsoleNotesProject.Helpers;
using ConsoleNotesProject.Interfaces;
using ConsoleNotesProject.Models;
using ConsoleNotesProject.Models.Enums;
using System;

namespace ConsoleNotesProject.Controllers
{
	public class MainPage : IMainPage
	{ 
		private readonly ICommandHandler _commandHandlerService;
		public MainPage(ICommandHandler commandHandlerService)
		{
			_commandHandlerService = commandHandlerService ?? throw new ArgumentNullException(nameof(commandHandlerService));
		}

		public void Start()
		{
			Console.Title = $"{Constants.ProjectName} {Constants.Version}";

			while (true)
			{				
				ShowInitialWindow();
				_commandHandlerService.Handle(Console.ReadLine().Trim());
			}
		}

		private void ShowInitialWindow()
		{
			ConsoleNoteHelper.InitHeader();

			Console.WriteLine("#################################################################");
			Console.WriteLine("#                       Enter command                           #");
			Console.WriteLine($"#               Enter '{nameof(Command.Help)}', if you need help                  #");
			Console.WriteLine("#################################################################");
			Console.Write("> ");
		}
	}
}
