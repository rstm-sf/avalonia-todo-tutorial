using System;
using System.Windows.Input;

namespace ToDo.Models
{
    public class MyCommand : ICommand
    {
        private readonly Action<object> _execute;

        private readonly Predicate<object> _canExecute;

        public event EventHandler CanExecuteChanged;

        internal MyCommand(Action<object> execute)
            : this(execute, DefaultCanExecute)
        { }

        internal MyCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute ?? throw new ArgumentNullException(nameof(canExecute));
        }

        public bool CanExecute(object parameter) =>
            _canExecute(parameter);

        public void Execute(object parameter) =>
            _execute.Invoke(parameter);

        public void OnCanExecuteChanged() =>
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        private static bool DefaultCanExecute(object parameter) => true;
    }
}
