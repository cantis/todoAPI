using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TodoApi.Managers;
using TodoApi.Models;

namespace TodoApi.Test
{
    [TestClass]
    public class TodoControllerTests
    {
        private Mock<ITodoContext> _mockContext;

        [TestInitialize]
        public void TestInit()
        {
            // Setup moc data
            var mockTodoData = (new List<TodoItem>
                                {
                                    new TodoItem {Name = "Item1"},
                                    new TodoItem {Name = "Item2"},
                                    new TodoItem {Name = "Item3"},
                                    new TodoItem {Name = "Item4"},
                                    new TodoItem {Name = "Item5"},
                                    new TodoItem {Name = "Item6"},
                                    new TodoItem {Name = "Item7"},
                                    new TodoItem {Name = "Item8"}
                                });

            var ms = new Mock<DbSet<TodoItem>>();
            ms.Setup(x => x.Any()).Returns(true);
            ms.Setup(x => x.Find(It.IsAny<int>())).Returns((int p) => mockTodoData.FirstOrDefault(x => x.Id == p));

            _mockContext = new Mock<ITodoContext>();
            _mockContext.Setup(x => x.TodoItems).Returns(ms.Object);
            
            
        }



        [TestMethod]
        public void GetById_ValidID_Ok()
        {
            // arrange
            var manager = new TodoManager(_mockContext.Object);

            // act
            var result = manager.GetById(2);

            // assert
            Assert.IsNotNull(result);

            //var okResult = result as OkObjectResult;
            //Assert.IsNotNull(okResult);
            //var messages = okResult.Value as List<string>;
            //Assert.IsNotNull(messages);
            //Assert.AreEqual(1, messages.Count);


        }
    }
}
