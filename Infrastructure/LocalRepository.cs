using System;

namespace Infrastructure
{
	public class LocalRepository : IMessageRepository
	{
		private string message;

		public string GetMessage()
		{
			string msg = message ?? string.Empty;

			try
			{
				Console.WriteLine(msg);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.ToString());
			}

			return msg;
		}

		public bool SaveMessage(string message)
		{
			if (string.IsNullOrEmpty(message)) return false;

			this.message = message;
			return true;
		}
	}
}
