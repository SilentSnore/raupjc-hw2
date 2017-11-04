using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2;

namespace Task_3
{
    [TestClass]
    public class TodoRepositoryTests
    { 
        [TestMethod]
        public void AddTest1()
        {
            TodoItem item1 = new TodoItem("1");
            TodoItem item2 = new TodoItem("2");
            TodoItem item3 = new TodoItem("3");
            Exception myException = null;

            TodoRepository repository = new TodoRepository();
            repository.Add(item1);
            repository.Add(item2);
            repository.Add(item3);
            try
            {
                repository.Add(item3);
            }
            catch (Exception exception)
            {
                myException = exception;
            }
            Assert.IsInstanceOfType(myException, typeof(DuplicateTodoItemException));
        }

        [TestMethod]
        public void GetTest1()
        {
            TodoItem item1 = new TodoItem("1");
            TodoItem item2 = new TodoItem("2");
            TodoItem item3 = new TodoItem("3");
            TodoRepository repository = new TodoRepository();
            repository.Add(item1);
            repository.Add(item2);
            repository.Add(item3);

            Assert.AreEqual(item1, repository.Get(item1.Id));
        }

        [TestMethod]
        public void GetTest2()
        {
            TodoItem item1 = new TodoItem("1");
            TodoItem item2 = new TodoItem("2");
            TodoItem item3 = new TodoItem("3");
            TodoItem item4 = new TodoItem("4");
            TodoRepository repository = new TodoRepository();
            repository.Add(item1);
            repository.Add(item2);
            repository.Add(item3);

            Assert.IsNull(repository.Get(item4.Id));
        }

        [TestMethod]
        public void RemoveTest1()
        {
            TodoItem item1 = new TodoItem("1");
            TodoItem item2 = new TodoItem("2");
            TodoItem item3 = new TodoItem("3");
            TodoRepository repository = new TodoRepository();
            repository.Add(item1);
            repository.Add(item2);
            repository.Add(item3);

            Assert.IsTrue(repository.Remove(item1.Id));
        }

        [TestMethod]
        public void RemoveTest2()
        {
            TodoItem item1 = new TodoItem("1");
            TodoItem item2 = new TodoItem("2");
            TodoItem item3 = new TodoItem("3");
            TodoItem item4 = new TodoItem("4");
            TodoRepository repository = new TodoRepository();
            repository.Add(item1);
            repository.Add(item2);
            repository.Add(item3);

            Assert.IsFalse(repository.Remove(item4.Id));
        }

        [TestMethod]
        public void UpdateTest1()
        {
            TodoItem item1 = new TodoItem("1");
            TodoItem item2 = new TodoItem("2");
            TodoItem item3 = new TodoItem("3");
            TodoRepository repository = new TodoRepository();
            repository.Add(item1);
            repository.Add(item2);
            repository.Add(item3);

            item3.Text = "new text";

            Assert.AreEqual(repository.Get(item3.Id), repository.Update(item3));
        }

        [TestMethod]
        public void UpdateTest2()
        {
            TodoItem item1 = new TodoItem("1");
            TodoItem item2 = new TodoItem("2");
            TodoItem item3 = new TodoItem("3");
            TodoItem item4 = new TodoItem("4");
            TodoRepository repository = new TodoRepository();
            repository.Add(item1);
            repository.Add(item2);
            repository.Add(item3);
            repository.Update(item4);

            Assert.IsTrue(repository.Remove(item4.Id));
        }

        [TestMethod]
        public void UpdateTest3()
        {
            TodoItem item1 = new TodoItem("1");
            TodoItem item2 = new TodoItem("2");
            TodoItem item3 = new TodoItem("3");
            TodoRepository repository = new TodoRepository();
            repository.Add(item1);
            repository.Add(item2);
            repository.Add(item3);

            item3.Text = "new text";
            repository.Update(item3);
            Assert.AreEqual(item3.Text, "new text");
        }

        [TestMethod]
        public void MarkAsCompletedTest1()
        {
            TodoItem item1 = new TodoItem("1");
            TodoItem item2 = new TodoItem("2");
            TodoItem item3 = new TodoItem("3");
            TodoRepository repository = new TodoRepository();
            repository.Add(item1);
            repository.Add(item2);
            repository.Add(item3);

            Assert.IsTrue(repository.MarkAsCompleted(item2.Id));
        }

        [TestMethod]
        public void MarkAsCompletedTest2()
        {
            TodoItem item1 = new TodoItem("1");
            TodoItem item2 = new TodoItem("2");
            TodoItem item3 = new TodoItem("3");
            TodoRepository repository = new TodoRepository();
            repository.Add(item1);
            repository.Add(item2);
            repository.Add(item3);
            repository.MarkAsCompleted(item1.Id);

            Assert.IsFalse(repository.MarkAsCompleted(item1.Id));
        }

        [TestMethod]
        public void MarkAsCompletedTest3()
        {
            TodoItem item1 = new TodoItem("1");
            TodoItem item2 = new TodoItem("2");
            TodoItem item3 = new TodoItem("3");
            TodoItem item4 = new TodoItem("4");
            TodoRepository repository = new TodoRepository();
            repository.Add(item1);
            repository.Add(item2);
            repository.Add(item3);

            Assert.IsFalse(repository.MarkAsCompleted(item4.Id));
        }

        [TestMethod]
        public void GetAllTest()
        {
            TodoRepository repository = new TodoRepository();
            TodoItem item1 = new TodoItem("1");
            repository.Add(item1);
            System.Threading.Thread.Sleep(100);
            TodoItem item2 = new TodoItem("2");
            repository.Add(item2);
            System.Threading.Thread.Sleep(100);
            TodoItem item3 = new TodoItem("3");
            repository.Add(item3);

            TodoItem[] array = repository.GetAll().ToArray();
            if(!array[0].Equals(item3) || !array[1].Equals(item2) || !array[2].Equals(item1))
                Assert.Fail();
        }

        [TestMethod]
        public void GetActiveTest()
        {
            TodoItem item1 = new TodoItem("1");
            TodoItem item2 = new TodoItem("2");
            TodoItem item3 = new TodoItem("3");
            TodoItem item4 = new TodoItem("4");
            TodoRepository repository = new TodoRepository();
            repository.Add(item1);
            repository.Add(item2);
            repository.Add(item3);
            repository.Add(item4);
            repository.MarkAsCompleted(item1.Id);
            repository.MarkAsCompleted(item4.Id);

            List<TodoItem> list = repository.GetActive();
            if(list.Contains(item1) || list.Contains(item4) || list.Count != 2)
                Assert.Fail();
        }

        [TestMethod]
        public void GetCompletedTest()
        {
            TodoItem item1 = new TodoItem("1");
            TodoItem item2 = new TodoItem("2");
            TodoItem item3 = new TodoItem("3");
            TodoItem item4 = new TodoItem("4");
            TodoRepository repository = new TodoRepository();
            repository.Add(item1);
            repository.Add(item2);
            repository.Add(item3);
            repository.Add(item4);
            repository.MarkAsCompleted(item1.Id);
            repository.MarkAsCompleted(item4.Id);

            List<TodoItem> list = repository.GetCompleted();
            if (list.Contains(item2) || list.Contains(item3) || list.Count != 2)
                Assert.Fail();
        }

        [TestMethod]
        public void GetFilteredTest()
        {
            TodoItem item1 = new TodoItem("good");
            TodoItem item2 = new TodoItem("2");
            TodoItem item3 = new TodoItem("good");
            TodoItem item4 = new TodoItem("4");
            TodoRepository repository = new TodoRepository();
            repository.Add(item1);
            repository.Add(item2);
            repository.Add(item3);
            repository.Add(item4);

            List<TodoItem> list = repository.GetFiltered(item => item.Text.Equals("good"));
            if (list.Contains(item2) || list.Contains(item4) || list.Count != 2)
                Assert.Fail();
        }
    }
}
