// <copyright file="ActionCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EDU.Miner.Core.Controller
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Command base on Action.
    /// </summary>
    public class ActionCommand : ICommand
    {
        /// <summary>
        /// Action to run by command.
        /// </summary>
        private Action action = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionCommand"/> class.
        /// </summary>
        /// <param name="action">Action to run.</param>
        public ActionCommand(Action action)
        {
            this.action = action;
        }

        /// <summary>
        /// Event.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Indicates where command is allowed.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        /// <returns>If command is possible.</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Execute command.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        public void Execute(object parameter)
        {
            this.action();
        }
    }
}
