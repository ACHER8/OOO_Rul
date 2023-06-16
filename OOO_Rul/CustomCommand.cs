using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace OOO_Rul
{
    public class CustomCommand:ICommand
    {
        Action action;
        public CustomCommand(Action action)
        {
            this.action = action;
        }
        public static CustomCommand Empty { get; internal set; }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute ( object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            action();
        }

    }
}
