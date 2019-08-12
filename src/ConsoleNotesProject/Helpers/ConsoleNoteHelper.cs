using ConsoleNotesProject.Models;
using System;

namespace ConsoleNotesProject.Helpers
{
	class ConsoleNoteHelper
	{
		public static void InitHeader()
		{
			Console.Clear();
			Console.WriteLine($"#####     {Constants.ProjectName} {Constants.Version}     ######");
			Console.WriteLine();
		}
	}
}
