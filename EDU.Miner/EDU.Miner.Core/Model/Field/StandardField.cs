// <copyright file="StandardField.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EDU.Miner.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using EDU.Miner.Core.Model.Factory;

    /// <summary>
    /// Field of game.
    /// </summary>
    internal class StandardField : IField, INotifyPropertyChanged, INotifyable
    {
        private int bombs;
        private int height;
        private int width;
        private bool isLooked;
        private ICell[,] items;

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardField"/> class.
        /// </summary>
        /// <param name="size">Size of field.</param>
        /// <param name="bombs">Ammount of bombs.</param>
        public StandardField((int w, int h) size, int bombs)
        {
            if (this.IsFieldImpossible(size, bombs))
            {
                throw new Exception("Unable to create Field");
            }

            this.Width = size.w;
            this.Height = size.h;
            this.Bombs = bombs;
            this.IsLocked = true;
            this.items = new ICell[this.Height, this.Width];
            this.Fill();
        }

        /// <summary>
        /// Event of property change
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets width.
        /// </summary>
        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }

        /// <summary>
        /// Gets or sets height.
        /// </summary>
        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
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
        /// Gets a value indicating whether field is locked.
        /// </summary>
        public bool IsLocked
        {
            get { return this.isLooked; }
            private set { this.isLooked = value; }
        }

        /// <summary>
        /// Gets items.
        /// </summary>
        public IEnumerable<ICell> Items
        {
            get
            {
                if (this.items == null)
                {
                    return null;
                }

                return this.items.Cast<ICell>().ToList();
            }
        }

        /// <summary>
        /// Gets ammount of marked cells.
        /// </summary>
        public int Marked
        {
            get
            {
                return this.Items.Where(x => x.IsMarked).Count();
            }
        }

        /// <summary>
        /// Gets ammount of bombs to be opened.
        /// </summary>
        public int BombsIsLeft
        {
            get
            {
                return (this.Bombs < this.Marked) ? 0 : this.Bombs - this.Marked;
            }
        }

        private IAbstractFactory Factory => new ConcreteFactory();

        /// <summary>
        /// Open entire field.
        /// </summary>
        public void Open()
        {
            if (this.IsLocked)
            {
                return;
            }

            foreach (var item in this.Items)
            {
                item.Open();
            }

            this.IsLocked = true;
            this.OnPropertyChanged("IsLocked");
        }

        /// <summary>
        /// Return number of bombs arround.
        /// </summary>
        /// <param name="position">Position.</param>
        /// <returns>Ammount of bombs.</returns>
        public int CountBombsArround((int x, int y) position)
        {
            return this.GetNeighbors(position).Count(x => x.IsMined);
        }

        /// <summary>
        /// Returns all neighbors.
        /// </summary>
        /// <param name="position">Position.</param>
        /// <returns>Neighbors.</returns>
        public IEnumerable<ICell> GetNeighbors((int x, int y) position)
        {
            var items = new List<ICell>();

            // LEFT TOP
            if (position.x > 0 && position.y > 0)
            {
                items.Add(this.items[position.x - 1, position.y - 1]);
            }

            // CENTER TOP
            if (position.y > 0)
            {
                items.Add(this.items[position.x, position.y - 1]);
            }

            // RIGHT TOP
            if (position.x + 1 < this.Width && position.y > 0)
            {
                items.Add(this.items[position.x + 1, position.y - 1]);
            }

            // LEFT MIDDLE
            if (position.x > 0)
            {
                items.Add(this.items[position.x - 1, position.y]);
            }

            // RIGHT MIDDLE
            if (position.x + 1 < this.Width)
            {
                items.Add(this.items[position.x + 1, position.y]);
            }

            // LEFT BOTTOM
            if (position.x > 0 && position.y + 1 < this.Height)
            {
                items.Add(this.items[position.x - 1, position.y + 1]);
            }

            // CENTER BOTTOM
            if (position.y + 1 < this.Height)
            {
                items.Add(this.items[position.x, position.y + 1]);
            }

            // RIGHT BOTTOM
            if (position.x + 1 < this.Width && position.y + 1 < this.Height)
            {
                items.Add(this.items[position.x + 1, position.y + 1]);
            }

            return items;
        }

        /// <summary>
        /// Show neighbors.
        /// </summary>
        /// <param name="position">Position.</param>
        public void ShowNeighbors((int x, int y) position)
        {
            if (this.IsLocked)
            {
                return;
            }

            var neighbors = this.GetNeighbors(position);
            foreach (var item in neighbors)
            {
                if (item == null)
                {
                    continue;
                }

                item.Hide();
            }
        }

        /// <summary>
        /// Hide neighbors.
        /// </summary>
        /// <param name="position">Position.</param>
        public void HideNeighbors((int x, int y) position)
        {
            var neighbors = this.GetNeighbors(position);
            foreach (var item in neighbors)
            {
                if (item == null)
                {
                    continue;
                }

                item.Show();
            }
        }

        /// <summary>
        /// Notify On Update.
        /// </summary>
        public void NotifyOnUpdate()
        {
            this.OnPropertyChanged("BombsIsLeft");
        }

        /// <summary>
        /// Fill field with new set of cells.
        /// </summary>
        public void Fill()
        {
            var bombs = new List<(int i, int j)>();
            var rand = new Random();

            while (bombs.Count < this.Bombs)
            {
                var i = rand.Next(0, this.Height - 1);
                var j = rand.Next(0, this.Width - 1);

                if (bombs.Contains((i, j)))
                {
                    continue;
                }

                bombs.Add((i, j));
            }

            for (int i = 0; i < this.Height; i++)
            {
                for (int j = 0; j < this.Width; j++)
                {
                    this.items[i, j] = this.Factory.CreateCell(this, bombs.Contains((i, j)), (i, j));
                }
            }
        }

        /// <summary>
        /// Unlock field.
        /// </summary>
        public void UnLock()
        {
            this.IsLocked = false;
            this.OnPropertyChanged("IsLocked");
        }

        /// <summary>
        /// Lock field.
        /// </summary>
        public void Lock()
        {
            this.IsLocked = true;
            this.OnPropertyChanged("IsLocked");
        }

        /// <summary>
        /// Notify on property changed.
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

        /// <summary>
        /// Checks whether paratemers are ok.
        /// </summary>
        /// <param name="size">Size.</param>
        /// <param name="bombs">Ammount bombs.</param>
        /// <returns>Result.</returns>
        private bool IsFieldImpossible((int Width, int Height) size, int bombs)
        {
            return size.Width < 1 || size.Height < 1 || bombs < 1;
        }
    }
}
