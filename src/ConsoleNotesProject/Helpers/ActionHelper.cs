using System;

namespace ConsoleNotesProject.Helpers
{
	public static class ActionHelper
	{
		public static void DoActionOnResponse(string response, Action actionYes, Action actionNo)
		{
			var formattedResult = response.Trim().ToLower();

			if (formattedResult == "y")
			{
				actionYes();
			}
			else if (formattedResult == "n")
			{
				actionNo();
			}
			else
			{
				Console.WriteLine("Wrong input! Pass only \"y\" or \"n\".");
				DoActionOnResponse(Console.ReadLine().Trim().ToLower(), actionYes, actionNo);
			}
		}
	}
}
