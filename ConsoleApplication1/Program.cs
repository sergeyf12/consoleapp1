using Infrastructure;
using System;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Starting Hello World...");

			IMessageRepository repo1 = new RepositoryFactory().CreateRepository(SaveOption.Database);
			IMessageService svc1 = new MessageService(repo1);
			string message = svc1.GetMessage();
			Console.WriteLine(message);
			svc1.SendMessage("Hello World");
			Console.WriteLine(svc1.GetMessage());

			IMessageRepository repo2 = new RepositoryFactory().CreateRepository(SaveOption.Database);
			IMessageService svc2 = new MessageService(repo2);
			Console.WriteLine(svc2.GetMessage());

			IMessageRepository repo3 = new RepositoryFactory().CreateRepository(SaveOption.Locally);
			IMessageService svc3 = new MessageService(repo3);
			svc3.SendMessage("Hello there");
			svc3.GetMessage();

			Console.WriteLine("Press enter...");
			Console.ReadLine();
		}
	}
}
