// <copyright file="GameViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EDU.Miner.Core.ViewModel
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Input;
    using EDU.Miner.Core.Model;
    using EDU.Miner.Core.Model.Factory;

    /// <summary>
    /// ViewModel of Game.
    /// </summary>
    internal class GameViewModel : ViewModelBase
    {
        private IMinerGame game;
        private string _Title = "Miner 2.0";
        public string Title 
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameViewModel"/> class.
        /// </summary>
        public GameViewModel()
        {
            this.Game = this.Factory.CreateGame((10, 10), 10);
            this.StartGameCommand = new LambdaCommand(OnStartGameCommandExecuted, CanStartGameCommandExecute);
            (this.Game.Field as INotifyPropertyChanged).PropertyChanged += this.GameViewModel_PropertyChanged;
        }

        /// <summary>
        /// Gets get Command of Game's start.
        /// </summary>
        //public IStartGameCommand StartGameCommand { get; private set; }
        public ICommand StartGameCommand { get; private set; }

        private bool CanStartGameCommandExecute(object p) => true;
        private void OnStartGameCommandExecuted(object p)
        {
            this.Start();
        }

        /// <summary>
        /// Gets Game's Model.
        /// </summary>
        public IMinerGame Game
        {
            get { return this.game; }
            private set { this.game = value; }
        }

        /// <summary>
        /// Gets all Cells as IEnumerable of ViewModel.
        /// </summary>
        public IEnumerable<CellViewModel> Cells
        {
            get
            {
                return this.Game.Field.Items.Select(x => new CellViewModel(x));
            }
        }

        /// <summary>
        /// Gets a value indicating whether Game is Active(in progress).
        /// </summary>
        public bool IsActive
        {
            get
            {
                return this.Game.IsActive;
            }
        }

        /// <summary>
        /// Gets Abstract factory.
        /// </summary>
        private IAbstractFactory Factory => new ConcreteFactory();

        /// <summary>
        /// Starts new game.
        /// </summary>
        public void Start()
        {
            this.Game.Start();
            this.OnPropertyChanged("Cells");
            this.OnPropertyChanged("IsActive");
        }

        private void GameViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.Game.Stop();
            this.OnPropertyChanged("IsActive");
        }
    }
}
