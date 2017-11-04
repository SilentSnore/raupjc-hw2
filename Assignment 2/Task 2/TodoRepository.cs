using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_2
{
    /// <summary >
    /// Class that encapsulates all the logic for accessing TodoTtems .
    /// </ summary >
    public class TodoRepository : ITodoRepository
    {
        /// <summary >
        /// Repository does not fetch todoItems from the actual database ,
        /// it uses in memory storage for this excersise .
        /// </ summary >
        private readonly IGenericList<TodoItem> _inMemoryTodoDatabase;

        public TodoRepository(IGenericList<TodoItem> initialDbState = null)
        {
            if (initialDbState != null)
            {
                _inMemoryTodoDatabase = initialDbState;
            }
            else
            {
                _inMemoryTodoDatabase = new GenericList<TodoItem>();
            }
            // Shorter way to write this in C# using ?? operator :
            // x ?? y => if x is not null , expression returns x. Else it will return y.
            // _inMemoryTodoDatabase = initialDbState ?? new List < TodoItem >();
        }

        public TodoItem Get(Guid todoId)
        {
            return _inMemoryTodoDatabase.SingleOrDefault(item => item.Id.Equals(todoId));
        }

        public TodoItem Add(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
                throw new DuplicateTodoItemException("duplicate id: " + todoItem.Id.ToString());
            _inMemoryTodoDatabase.Add(todoItem);
            return todoItem;
        }

        public bool Remove(Guid todoId)
        {
            TodoItem item = Get(todoId);
            if (object.ReferenceEquals(item, null))
                return false;
            return _inMemoryTodoDatabase.Remove(item);
        }

        public TodoItem Update(TodoItem todoItem)
        {
            if (_inMemoryTodoDatabase.Contains(todoItem))
            {
                Remove(todoItem.Id);
            }
            Add(todoItem);
            return todoItem;
        }

        public bool MarkAsCompleted(Guid todoId)
        {
            if (_inMemoryTodoDatabase.Any(item => item.Id.Equals(todoId)))
            {
                return Get(todoId).MarkAsCompleted();
            }
            return false;
        }

        public List<TodoItem> GetAll()
        {
            return _inMemoryTodoDatabase.OrderByDescending(item => item.DateCreated).ToList();
        }

        public List<TodoItem> GetActive()
        {
            return _inMemoryTodoDatabase.Where(item => item.IsCompleted.Equals(false)).ToList();
        }

        public List<TodoItem> GetCompleted()
        {
            return _inMemoryTodoDatabase.Where(item => item.IsCompleted.Equals(true)).ToList();
        }

        public List<TodoItem> GetFiltered(Func<TodoItem, bool> filterFunction)
        {
            return _inMemoryTodoDatabase.Where(item => filterFunction.Invoke(item).Equals(true)).ToList();
        }
    }
}