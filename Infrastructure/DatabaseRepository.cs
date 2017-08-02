
namespace Infrastructure
{
	public class DatabaseRepository : IMessageRepository
	{
		private static string dbMessage; // a db mock-up

		public string GetMessage()
		{
			return dbMessage ?? string.Empty;
		}

		public bool SaveMessage(string message)
		{
			if (string.IsNullOrEmpty(message)) return false;

			dbMessage = message;
			return true;
		}
	}
}
