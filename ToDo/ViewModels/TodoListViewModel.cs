using System.Collections.Generic;
using System.Collections.ObjectModel;
using ToDo.Models;

namespace ToDo.ViewModels
{
    public class TodoListViewModel : Observable
    {
        public TodoListViewModel(IEnumerable<TodoItem> items) =>
            Items = new ObservableCollection<TodoItem>(items);

        public ObservableCollection<TodoItem> Items { get; }
    }
}
