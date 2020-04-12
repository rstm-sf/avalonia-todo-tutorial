using ToDo.Models;
using ToDo.Services;

namespace ToDo.ViewModels
{
    class MainWindowViewModel : Observable
    {
        private Observable _content;

        public MainWindowViewModel(Database db) =>
            Content = List = new TodoListViewModel(db.GetItems());

        public TodoListViewModel List { get; }

        public Observable Content
        {
            get => _content;

            private set
            {
                _content = value;
                NotifyPropertyChanged();
            }
        }

        public void AddItem()
        {
            void addItem(TodoItem item)
            {
                if (item != null)
                    List.Items.Add(item);
                Content = List;
            }

            Content = new AddItemViewModel(addItem);
        }
    }
}
