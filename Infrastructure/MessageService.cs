
namespace Infrastructure
{
	public class MessageService : IMessageService
	{
		private IMessageRepository repo;

		public MessageService(IMessageRepository repository)
		{
			repo = repository;
		}

		public string GetMessage()
		{
			return repo.GetMessage();
		}

		public void SendMessage(string message)
		{
			if (!string.IsNullOrEmpty(message))
			{
				repo.SaveMessage(message);
			}
		}
	}
}
