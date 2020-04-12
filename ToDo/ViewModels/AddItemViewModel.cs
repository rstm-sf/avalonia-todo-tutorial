using System;
using ToDo.Models;

namespace ToDo.ViewModels
{
    class AddItemViewModel : Observable
    {
        private string _description;

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                NotifyPropertyChanged();
                Ok.OnCanExecuteChanged();
            }
        }

        public MyCommand Ok { get; }

        public MyCommand Cancel { get; }

        public AddItemViewModel(Action<TodoItem> addItem)
        {
            Ok = new MyCommand(
                delegate (object parameter)
                {
                    addItem.Invoke(new TodoItem { Description = Description });
                },
                param => !string.IsNullOrWhiteSpace(Description));

            Cancel = new MyCommand(delegate (object parameter)
            {
                addItem.Invoke(null);
            });
        }
    }
}
