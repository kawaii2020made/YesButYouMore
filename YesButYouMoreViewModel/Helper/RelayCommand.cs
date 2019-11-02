using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YesButYouMoreViewModel
{
    /// <summary>
    /// Class provides functionality to the GUI by setting up the relay commands that
    /// the ViewModels use to define ICommand properties.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> actionCommand;
        private readonly Predicate<object> actionCondition;

        //Constructor for command if no condition is needed to for it execute.
        public RelayCommand(Action<object> action) : this(action, null)
        {
            actionCommand = action;
        }

        public RelayCommand(Action<object> action, Predicate<object> condition)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action parameter is null");
            }
            actionCommand = action;
            actionCondition = condition;
        }

        #region ICommand Implementation

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }

        }

        public bool CanExecute(object parameter)
        {
            return actionCondition == null || actionCondition(parameter);
        }

        public void Execute(object parameter)
        {
            actionCommand(parameter);
        }

        #endregion       
    }
    /// <summary>
    /// Generic version for taking class types as parameters.
    /// </summary>
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> actionCommand;
        private readonly Predicate<T> actionCondition;

        public RelayCommand(Action<T> action) : this(action, null)
        {
            actionCommand = action;
        }

        public RelayCommand(Action<T> action, Predicate<T> condition)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action parameter is null");
            }
            actionCommand = action;
            actionCondition = condition;
        }

        #region ICommand Implementation

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            return actionCondition == null || actionCondition((T)parameter);
        }

        public void Execute(object parameter)
        {
            actionCommand((T)parameter);
        }

        #endregion
    }
}
