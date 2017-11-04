using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2;

namespace Task_3
{
    [TestClass]
    public class TodoItemTests
    {
        [TestMethod]
        public void ConstrutorTest1()
        {
            TodoItem todoItem = new TodoItem("description");
            Assert.AreEqual(todoItem.Text, "description");
        }

        [TestMethod]
        public void ConstrutorTest2()
        {
            TodoItem todoItem = new TodoItem("description");
            List<TodoItem> list = new List<TodoItem>(100);
            for (int i = 0; i < 10000; i++)
            {
                list.Add(new TodoItem(i.ToString()));
            }
            foreach (TodoItem item in list)
            {
                if (item.Id.Equals(todoItem.Id) || item.DateCreated.Equals(null) || item.IsCompleted.Equals(null))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void MarkAsCompletedTest1()
        {
            TodoItem todoItem = new TodoItem("description");
            Assert.IsTrue(todoItem.MarkAsCompleted());
        }

        [TestMethod]
        public void MarkAsCompletedTest2()
        {
            TodoItem todoItem = new TodoItem("description");
            todoItem.MarkAsCompleted();
            Assert.IsFalse(todoItem.MarkAsCompleted());
        }

        [TestMethod]
        public void GetHashCodeTest()
        {
            TodoItem todoItem1 = new TodoItem("description");
            TodoItem todoItem2 = new TodoItem("description");
            Assert.AreNotEqual(todoItem1.GetHashCode(), todoItem2.GetHashCode());
        }

        [TestMethod]
        public void EqualsTest1()
        {
            TodoItem todoItem1 = new TodoItem("description");
            TodoItem todoItem2 = new TodoItem("description");
            Assert.AreNotEqual(todoItem1, todoItem2);
        }

        [TestMethod]
        public void EqualsTest2()
        {
            TodoItem todoItem = new TodoItem("description");
            object randomObject = 4;
            Assert.AreNotEqual(todoItem, randomObject);
        }

        [TestMethod]
        public void EqualsTest3()
        {
            TodoItem todoItem = new TodoItem("description");
            object randomObject = todoItem;
            Assert.AreEqual(todoItem, randomObject);
        }
    }
}
