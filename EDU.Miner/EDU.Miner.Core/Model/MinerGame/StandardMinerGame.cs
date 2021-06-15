// <copyright file="StandardMinerGame.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EDU.Miner.Core.Model
{
    using System.ComponentModel;
    using EDU.Miner.Core.Model.Factory;

    /// <summary>
    /// Standard Miner.
    /// </summary>
    internal class StandardMinerGame : IMinerGame, INotifyPropertyChanged
    {
        private IField field;
        private int bombs;
        private (int Width, int Height) size;
        private bool isActive;

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardMinerGame"/> class.
        /// </summary>
        /// <param name="size">Size of field.</param>
        /// <param name="bombs">Number ob bombs.</param>
        public StandardMinerGame((int Width, int Height) size, int bombs)
        {
            this.Size = size;
            this.Bombs = bombs;
            this.Field = this.Factory.CreateField((10, 10), 10);
            this.IsActive = false;
        }

        /// <summary>
        /// Event of property changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets a value indicating whether is active.
        /// </summary>
        public bool IsActive
        {
            get { return this.isActive; }
            private set { this.isActive = value; }
        }

        /// <summary>
        /// Gets field.
        /// </summary>
        public IField Field
        {
            get { return this.field; }
            private set { this.field = value; }
        }

        /// <summary>
        /// Gets size.
        /// </summary>
        public (int Width, int Height) Size
        {
            get { return this.size; }
            private set { this.size = value; }
        }

        /// <summary>
        /// Gets or sets bombs.
        /// </summary>
        public int Bombs
        {
            get { return this.bombs; }
            set { this.bombs = value; }
        }

        /// <summary>
        /// Gets factory.
        /// </summary>
        private IAbstractFactory Factory => new ConcreteFactory();

        /// <summary>
        /// Start game.
        /// </summary>
        public void Start()
        {
            this.IsActive = true;
            this.Field = this.Factory.CreateField(this.Size, this.Bombs);
            this.OnPropertyChanged("Field");
            this.Field.UnLock();
            this.OnPropertyChanged("IsActive");
        }

        /// <summary>
        /// Stop game.
        /// </summary>
        public void Stop()
        {
            this.IsActive = false;
            this.Field.Lock();
            this.OnPropertyChanged("IsActive");
        }

        /// <summary>
        /// Fire event.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return;
            }

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
