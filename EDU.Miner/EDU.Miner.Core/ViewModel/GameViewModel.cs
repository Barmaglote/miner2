// <copyright file="GameViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EDU.Miner.Core.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using EDU.Miner.Core.DataContext;
    using EDU.Miner.Core.Model;
    using EDU.Miner.Core.Model.Factory;

    /// <summary>
    /// ViewModel of Game.
    /// </summary>
    internal class GameViewModel : ViewModelBase
    {
        private IMinerGame game;
        private string _Title = "Miner 2.0";
        private int _TimeIsLeftSeconds = 1000;
        private readonly int _OneSecondInMiliseconds = 1000;
        private int _StartCountDown = 1000;
        private CancellationTokenSource _CancellationTokenSource;
        private bool _IsStarted = false;

        public IHistoryDataProvider History { get; private set; }

        public IEnumerable<HistoricalRecord> HistoricalRecords
        {
            get {
                return History?.Records.OrderByDescending(r => r.TotalTimeInSeconds).ToList();
            }
        }

        public int TimeIsLeftSeconds
        {
            get => _TimeIsLeftSeconds;
            set => Set(ref _TimeIsLeftSeconds, value);
        }


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
            this._CancellationTokenSource = new CancellationTokenSource();
            this.StartGameCommand = new LambdaCommand(OnStartGameCommandExecuted, CanStartGameCommandExecute);
            (this.Game.Field as INotifyPropertyChanged).PropertyChanged += this.GameViewModel_PropertyChanged;
            (this.Game as INotifyPropertyChanged).PropertyChanged += this.GameViewModel_PropertyChanged;

            this.History = this.Factory.CreateRepository();
        }

        /// <summary>
        /// Gets get Command of Game's start.
        /// </summary>
        public ICommand StartGameCommand { get; private set; }

        private bool CanStartGameCommandExecute(object p) => true;
        private void OnStartGameCommandExecuted(object p)
        {
            this.Start();
            if (this._IsStarted)
            {                
                this._CancellationTokenSource.Cancel();
                this._CancellationTokenSource = new CancellationTokenSource();
            }
            Task.Factory.StartNew(() => this._CountDown(this._StartCountDown, this._CancellationTokenSource.Token));
        }

        /// <summary>
        /// Gets Game's Model.
        /// </summary>
        public IMinerGame Game
        {
            get 
            {
                return this.game; 
            }
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

        private void _CountDown(int start, CancellationToken token)
        {
            if (this._IsStarted) {
                return;
            }
            this._IsStarted = true;
            this.TimeIsLeftSeconds = start;
            while (this.TimeIsLeftSeconds > 0 && !token.IsCancellationRequested)
            {
                this._CheckGameStatus();
                Thread.Sleep(_OneSecondInMiliseconds);
                this.TimeIsLeftSeconds--;
            }
            this._IsStarted = false;
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
            this._CheckGameStatus();
        }

        private void _CheckGameStatus() 
        {
            if (this.TimeIsLeftSeconds > 0 && this.Game.Field.IsUnmined)
            {
                this.History.AddNewRecord(new HistoricalRecord() { Time = DateTime.Now, TotalTimeInSeconds = this._StartCountDown - this.TimeIsLeftSeconds });
                this.OnPropertyChanged("HistoricalRecords");
                this.Game.Stop();
                this._CancellationTokenSource.Cancel();
                this.OnPropertyChanged("IsActive");
            }
        }
    }
}
