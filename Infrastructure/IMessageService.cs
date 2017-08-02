
namespace Infrastructure
{
	public interface IMessageService
	{
		string GetMessage();
		void SendMessage(string message);
	}
}
