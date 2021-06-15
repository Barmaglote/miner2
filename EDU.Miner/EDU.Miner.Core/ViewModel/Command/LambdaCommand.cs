namespace EDU.Miner.Core.ViewModel
{
    using System;

    /// <summary>
    /// Standard command.
    /// </summary>
    internal class LambdaCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LambdaCommand"/> class.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <param name="canExecute">Can execute command.</param>
        public LambdaCommand(Action<object> action, Func<object, bool> canExecute = null)
        {
            this.Action = action ?? throw new ArgumentNullException("Unable to creatge Command");
            this.CanExecuteAction = canExecute;
        }

        /// <summary>
        /// Gets or sets action of command.
        /// </summary>
        private Action<object> Action { get; set; }

        /// <summary>
        /// Gets or sets state.
        /// </summary>
        private Func<object, bool> CanExecuteAction { get; set; }

        /// <summary>
        /// Returns state of command.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        /// <returns>State.</returns>
        public override bool CanExecute(object parameter) => this.CanExecuteAction?.Invoke(parameter) ?? true;

        /// <summary>
        /// Command itself.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        public override void Execute(object parameter) => this.Action(parameter);
    }
}
