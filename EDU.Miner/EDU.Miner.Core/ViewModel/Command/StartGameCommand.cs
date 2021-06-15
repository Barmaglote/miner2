// <copyright file="StartGameCommand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EDU.Miner.Core
{
    using System;
    using System.Windows.Input;
    using EDU.Miner.Core.ViewModel;

    /// <summary>
    /// Start game command.
    /// </summary>
    internal class StartGameCommand : ICommand, IStartGameCommand
    {
        private GameViewModel viewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="StartGameCommand"/> class.
        /// </summary>
        /// <param name="vm">GameViewModel.</param>
        public StartGameCommand(GameViewModel vm)
        {
            this.ViewModel = vm;
        }

        /// <summary>
        /// Mandatory event.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Gets viewModel.
        /// </summary>
        public GameViewModel ViewModel
        {
            get { return this.viewModel; }
            private set { this.viewModel = value; }
        }

        /// <summary>
        /// Indicates that command can be executed.
        /// </summary>
        /// <param name="parameter">Paramter.</param>
        /// <returns>Result.</returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Run command.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        public void Execute(object parameter)
        {
            this.ViewModel.Start();
        }
    }
}
