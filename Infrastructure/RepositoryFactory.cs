using System;
using System.Configuration;

namespace Infrastructure
{
	public enum SaveOption
	{
		None,
		Locally, // Console
		Database
	}

	public class RepositoryFactory : IRepositoryFactory
	{
		public IMessageRepository CreateRepository(SaveOption storageOption = SaveOption.Locally)
		{
			IMessageRepository repo;

			if (storageOption == SaveOption.None)
			{
				storageOption = GetSettings();
			}

			switch (storageOption)
			{
				case SaveOption.Locally:
					repo = new LocalRepository();
					break;

				case SaveOption.Database:
					repo = new DatabaseRepository();
					break;

				default:
					repo = new LocalRepository();
					break;
			}

			return repo;
		}

		private SaveOption GetSettings()
		{
			SaveOption result = SaveOption.None;

			string value = ConfigurationManager.AppSettings["storage"];
			if (string.IsNullOrEmpty(value)) return result;

			SaveOption tmp;
			if (Enum.TryParse<SaveOption>(value, true, out tmp))
			{
				result = tmp;
			}

			return result;
		}
	}
}
