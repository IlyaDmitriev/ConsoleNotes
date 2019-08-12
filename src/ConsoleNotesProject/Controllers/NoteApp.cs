using ConsoleNotesProject.Interfaces;
using System;

namespace ConsoleNotesProject.Controllers
{
	public class NoteApp
	{
		private readonly IMainPage _mainPageService;

		public NoteApp(IMainPage testService)
		{
			_mainPageService = testService ?? throw new ArgumentNullException(nameof(testService));
		}

		public void Run()
		{
			_mainPageService.Start();
		}
	}
}
