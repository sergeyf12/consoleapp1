
namespace Infrastructure
{
	public interface IRepositoryFactory
	{
		IMessageRepository CreateRepository(SaveOption storageOption = SaveOption.Locally);
	}
}
