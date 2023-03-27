using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InfoCryptocurrenciesTEST.Commands
{
    public class ConvertCommand : ICommand
    {
        private readonly Action<object> action;

        public event EventHandler? CanExecuteChanged;

        public ConvertCommand(Action<object> action)
        {
            this.action = action;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            action(parameter);
        }
    }
}
