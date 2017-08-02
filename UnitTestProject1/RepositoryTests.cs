using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Infrastructure;

namespace UnitTestProject1
{
	[TestClass]
	public class RepositoryTests
	{
		[TestMethod]
		public void Create_Local_Storage()
		{
			// Arrange
			var factory = new RepositoryFactory();

			// Act
			var repo = factory.CreateRepository(SaveOption.Locally);

			// Assert
			Assert.IsInstanceOfType(repo, typeof(LocalRepository));
		}

		[TestMethod]
		public void Create_Database_Storage()
		{
			// Arrange
			var factory = new RepositoryFactory();

			// Act
			var repo = factory.CreateRepository(SaveOption.Database);

			// Assert
			Assert.IsInstanceOfType(repo, typeof(DatabaseRepository));
		}

		[TestMethod]
		public void Create_Storage_With_None_Option()
		{
			// Arrange
			var factory = new RepositoryFactory();

			// Act
			var repo = factory.CreateRepository(SaveOption.None);

			// Assert
			Assert.IsInstanceOfType(repo, typeof(LocalRepository));
		}

		[TestMethod]
		public void Get_Message_From_Local_Storage()
		{
			// Arrange
			var factory = new RepositoryFactory();
			var repo = factory.CreateRepository(SaveOption.Locally);
			repo.SaveMessage("hello");

			// Act
			string message = repo.GetMessage();

			// Assert
			Assert.AreEqual("hello", message);
		}

		[TestMethod]
		public void Save_Message_To_Local_Storage()
		{
			// Arrange
			var factory = new RepositoryFactory();
			var repo = factory.CreateRepository(SaveOption.Locally);

			// Act
			repo.SaveMessage("hello");
			string message = repo.GetMessage();

			// Assert
			Assert.AreEqual("hello", message);
		}

		[TestMethod]
		public void Get_Message_From_Database_Storage()
		{
			// Arrange
			var factory = new RepositoryFactory();
			var repo = factory.CreateRepository(SaveOption.Database);
			repo.SaveMessage("hello");

			// Act
			string message = repo.GetMessage();

			// Assert
			Assert.AreEqual("hello", message);
		}

		[TestMethod]
		public void Save_Message_To_Database_Storage()
		{
			// Arrange
			var factory = new RepositoryFactory();
			var repo = factory.CreateRepository(SaveOption.Database);

			// Act
			repo.SaveMessage("hello");
			string message = repo.GetMessage();

			// Assert
			Assert.AreEqual("hello", message);
		}
	}
}
