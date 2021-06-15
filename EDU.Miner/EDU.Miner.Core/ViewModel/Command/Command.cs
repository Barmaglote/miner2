namespace EDU.Miner.Core.ViewModel
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Basic class for all commands.
    /// </summary>
    internal abstract class Command : ICommand
    {
        /// <summary>
        /// Fired, when state is changed.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Determines state.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        /// <returns>State.</returns>
        public abstract bool CanExecute(object parameter);

        /// <summary>
        /// Execute action.
        /// </summary>
        /// <param name="parameter">Parameter of command.</param>
        public abstract void Execute(object parameter);
    }
}
