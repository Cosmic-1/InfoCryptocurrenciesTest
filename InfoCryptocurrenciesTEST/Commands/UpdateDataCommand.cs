using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InfoCryptocurrenciesTEST.Commands
{
    public class UpdateDataCommand : ICommand
    {
        private readonly Action<object> executeAction;

        public UpdateDataCommand(Action<object> executeAction)
        {
            this.executeAction = executeAction;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter) 
            => executeAction(parameter);
    }
}
