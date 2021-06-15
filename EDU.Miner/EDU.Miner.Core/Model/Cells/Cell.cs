// <copyright file="Cell.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EDU.Miner.Core.Model
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;

    /// <summary>
    /// Model of Cell.
    /// </summary>
    internal class Cell : ModelBase, ICell
    {
        private IField container;
        private (int x, int y) position;
        private bool isHidden;
        private bool isMarked;
        private bool isMined;
        private bool isOpened;
        private int? bombsArroundFounded = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="container">Container (Field).</param>
        /// <param name="isMined">Whether Cell is mined.</param>
        /// <param name="position">Position of cell.</param>
        public Cell(IField container, bool isMined, (int x, int y) position)
        {
            this.container = container;
            this.IsMined = isMined;
            this.Position = position;
            this.IsOpened = false;
        }

        /// <summary>
        /// Gets a value indicating whether cell is hidden.
        /// </summary>
        public bool IsHidden
        {
            get
            {
                return this.isHidden;
            }

            private set
            {
                this.isHidden = value;
                this.OnPropertyChanged("IsHidden");
            }
        }

        /// <summary>
        /// Gets a value indicating whether cell Is mined.
        /// </summary>
        public bool IsMined
        {
            get
            {
                return this.isMined;
            }

            private set
            {
                this.isMined = value;
                this.OnPropertyChanged("IsMined");
                this.OnPropertyChanged("IsMinedAndOpened");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether is marked.
        /// </summary>
        public bool IsMarked
        {
            get { return this.isMarked; }
            set { this.isMarked = value; }
        }

        /// <summary>
        /// Gets a value indicating whether cell is mined and opened.
        /// </summary>
        public bool IsMinedAndOpened
        {
            get
            {
                return this.IsMined && this.IsOpened;
            }
        }

        /// <summary>
        /// Gets a value indicating whether cell is opened.
        /// </summary>
        public bool IsOpened
        {
            get
            {
                return this.isOpened;
            }

            private set
            {
                this.isOpened = value;
                this.OnPropertyChanged("IsOpened");
                this.OnPropertyChanged("IsMinedAndOpened");
            }
        }

        /// <summary>
        /// Gets Container.
        /// </summary>
        public IField Container
        {
            get { return this.container; }
            private set { this.container = value; }
        }

        /// <summary>
        /// Gets position.
        /// </summary>
        public (int x, int y) Position
        {
            get { return this.position; }
            private set { this.position = value; }
        }

        /// <summary>
        /// Gets bombs arround.
        /// </summary>
        public string BombsArround
        {
            get
            {
                if (!this.IsOpened || this.IsMined || this.BombsArroundFounded < 1)
                {
                    return string.Empty;
                }

                return this.BombsArroundFounded.ToString();
            }
        }

        /// <summary>
        /// Gets bombs arround.
        /// </summary>
        public int BombsArroundFounded
        {
            get
            {
                if (this.bombsArroundFounded.HasValue)
                {
                    return this.bombsArroundFounded.Value;
                }

                this.bombsArroundFounded = this.container.CountBombsArround(this.Position);
                return this.bombsArroundFounded.Value;
            }
        }

        private IEnumerable<ICell> Neighbors
        {
            get
            {
                return this.container.GetNeighbors(this.Position);
            }
        }

        /// <summary>
        /// Hides cells.
        /// </summary>
        public void Hide()
        {
            if (this.IsMarked || this.IsOpened)
            {
                return;
            }

            this.IsHidden = true;
            this.OnPropertyChanged("IsHidden");
        }

        /// <summary>
        /// Show cell.
        /// </summary>
        public void Show()
        {
            if (this.IsMarked)
            {
                return;
            }

            this.IsHidden = false;
            this.OnPropertyChanged("IsHidden");
        }

        /// <summary>
        /// Mark cell.
        /// </summary>
        public void Mark()
        {
            if (this.IsOpened)
            {
                return;
            }

            this.IsMarked = !this.IsMarked;
            (this.Container as INotifyable).NotifyOnUpdate();
            this.OnPropertyChanged("IsMarked");
        }

        /// <summary>
        /// Open cell.
        /// </summary>
        /// <param name="isRecursive">Open cell recursively.</param>
        public void Open(bool isRecursive = true)
        {
            if (this.IsOpened || this.IsMarked)
            {
                return;
            }

            this.IsOpened = true;
            this.OnPropertyChanged("IsOpened");

            if (!isRecursive)
            {
                return;
            }

            if (this.IsMined)
            {
                this.container.Open();
            }
            else
            {
                if (this.BombsArroundFounded == 0)
                {
                    foreach (var item in this.Neighbors.Where(x => !x.IsMined && !x.IsOpened && !x.IsHidden && x.BombsArroundFounded == 0))
                    {
                        item.Open();
                    }
                }

                this.OnPropertyChanged("BombsArround");
                this.OnPropertyChanged("IsMarked");
            }
        }
    }
}
