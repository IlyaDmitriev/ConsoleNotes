using ConsoleNotesProject.Controllers;
using ConsoleNotesProject.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using NotesProject.Business.Controllers;
using NotesProject.Business.Interfaces;

namespace ConsoleNotesProject
{
	class Program 
	{
		public static void Main(string[] args)
		{
			// create service collection
			var serviceCollection = new ServiceCollection();
			ConfigureServices(serviceCollection);

			// create service provider
			var serviceProvider = serviceCollection.BuildServiceProvider();

			// entry to run app
			serviceProvider.GetService<NoteApp>().Run();
		}

		private static void ConfigureServices(IServiceCollection serviceCollection)
		{
			// add services
			serviceCollection.AddTransient<IMainPage, MainPage>();
			serviceCollection.AddTransient<ICommandHandler, CommandHandler>();
			serviceCollection.AddTransient<INoteRepository, NoteRepository>();
			serviceCollection.AddTransient<INoteController, ConsoleNoteController>();

			// add app
			serviceCollection.AddTransient<NoteApp>();
		}
	}
}
