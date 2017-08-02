using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
	[TestClass]
	public class MessageServiceTests
	{
		private IRepositoryFactory factory;

		[TestInitialize]
		public void SetupTest()
		{
			factory = new RepositoryFactory();
		}

		[TestMethod]
		public void Get_Message_With_Local_Storage()
		{
			// Arrange
			var repo = factory.CreateRepository(SaveOption.Locally);
			repo.SaveMessage("hello");
			IMessageService svc = new MessageService(repo);

			// Act
			string message = svc.GetMessage();

			// Assert
			Assert.AreEqual("hello", message);
		}

		[TestMethod]
		public void Send_Message_With_Local_Storage()
		{
			// Arrange
			var repo = factory.CreateRepository(SaveOption.Locally);
			IMessageService svc = new MessageService(repo);

			// Act
			svc.SendMessage("hello");
			string message = svc.GetMessage();

			// Assert
			Assert.AreEqual("hello", message);
		}

		[TestMethod]
		public void Get_Message_With_Database_Storage()
		{
			// Arrange
			var repo = factory.CreateRepository(SaveOption.Database);
			repo.SaveMessage("hello");
			IMessageService svc = new MessageService(repo);

			// Act
			string message = svc.GetMessage();

			// Assert
			Assert.AreEqual("hello", message);
		}

		[TestMethod]
		public void Send_Message_With_Database_Storage()
		{
			// Arrange
			var repo = factory.CreateRepository(SaveOption.Database);
			IMessageService svc = new MessageService(repo);

			// Act
			svc.SendMessage("hello");
			string message = svc.GetMessage();

			// Assert
			Assert.AreEqual("hello", message);
		}
	}
}
