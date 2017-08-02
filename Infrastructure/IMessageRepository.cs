
namespace Infrastructure
{
	public interface IMessageRepository
	{
		string GetMessage();
		bool SaveMessage(string message);
	}
}
