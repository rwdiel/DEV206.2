using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestaurantManager.ViewModels
{
    public class Command : ICommand
    {
        private readonly Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           this._execute(parameter);
        }

        public Command(Action<object> execute)
        {
            this._execute = execute;
        }
    }
}
