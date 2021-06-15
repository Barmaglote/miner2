// <copyright file="CellViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EDU.Miner.Core.ViewModel
{
    using System.ComponentModel;
    using System.Windows.Input;
    using EDU.Miner.Core.Controller;
    using EDU.Miner.Core.Model;

    /// <summary>
    /// ViewModel of Cell.
    /// </summary>
    internal class CellViewModel : ViewModelBase
    {
        private ICell cell;
        private bool preventClick;
        private bool leftButtonIsDown;
        private bool rightButtonIsDown;

        /// <summary>
        /// Initializes a new instance of the <see cref="CellViewModel"/> class.
        /// </summary>
        /// <param name="cell">Cell.</param>
        public CellViewModel(ICell cell)
        {
            this.Cell = cell;
            this.CellLeftMouseUpCommand = new ActionCommand(this.LeftMouseUp);
            this.CellLeftMouseDownCommand = new ActionCommand(this.LeftMouseDown);
            this.CellRightMouseUpCommand = new ActionCommand(this.RightMouseUp);
            this.CellRightMouseDownCommand = new ActionCommand(this.RightMouseDown);
            ((INotifyPropertyChanged)this.Cell).PropertyChanged += this.CellViewModel_PropertyChanged;
        }

        /// <summary>
        /// Gets command of CellRightMouseUp.
        /// </summary>
        public ICommand CellRightMouseUpCommand { get; private set; }

        /// <summary>
        /// Gets command of CellRightMouseDown.
        /// </summary>
        public ICommand CellRightMouseDownCommand { get; private set; }

        /// <summary>
        /// Gets command of CellLeftMouseUp.
        /// </summary>
        public ICommand CellLeftMouseUpCommand { get; private set; }

        /// <summary>
        /// Gets command of CellLeftMouseDown.
        /// </summary>
        public ICommand CellLeftMouseDownCommand { get; private set; }

        /// <summary>
        /// Gets cell (Model).
        /// </summary>
        public ICell Cell
        {
            get { return this.cell; }
            private set { this.cell = value; }
        }

        /// <summary>
        /// Gets a value indicating whether indicates where cell is Hidden.
        /// </summary>
        public bool IsHidden
        {
            get
            {
                return this.Cell.IsHidden;
            }
        }

        /// <summary>
        /// Gets a value indicating whether indicates where cell is Marked.
        /// </summary>
        public bool IsMarked
        {
            get
            {
                return this.Cell.IsMarked;
            }
        }

        /// <summary>
        /// Gets a value indicating whether cell is Mined and Opened.
        /// </summary>
        public bool IsMinedAndOpened
        {
            get
            {
                return this.Cell.IsMinedAndOpened;
            }
        }

        /// <summary>
        /// Gets a value indicating whether Cell is opened.
        /// </summary>
        public bool IsOpened
        {
            get
            {
                return this.Cell.IsOpened;
            }
        }

        /// <summary>
        /// Gets a value indicating number of bombs arround.
        /// </summary>
        public string BombsArround
        {
            get
            {
                return this.Cell.BombsArround;
            }
        }

        private void CellViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.OnPropertyChanged(e.PropertyName);
        }

        /// <summary>
        /// Opens cell.
        /// </summary>
        private void Open()
        {
            if (!this.preventClick)
            {
                this.Cell.Open();
            }

            this.preventClick = false;
        }

        /// <summary>
        /// Action, when Left Mouse is up.
        /// </summary>
        private void LeftMouseUp()
        {
            if (this.Cell.Container.IsLocked)
            {
                return;
            }

            this.leftButtonIsDown = false;
            if (!this.rightButtonIsDown)
            {
                this.Open();
            }
            else
            {
                this.Cell.Container.HideNeighbors(this.Cell.Position);
            }
        }

        /// <summary>
        /// Action when left mouse is down.
        /// </summary>
        private void LeftMouseDown()
        {
            if (this.Cell.Container.IsLocked)
            {
                return;
            }

            this.leftButtonIsDown = true;
        }

        /// <summary>
        /// Action when right mouse is up.
        /// </summary>
        private void RightMouseUp()
        {
            if (this.Cell.Container.IsLocked)
            {
                return;
            }

            this.rightButtonIsDown = false;
            if (!this.leftButtonIsDown)
            {
                this.Cell.Mark();
            }
            else
            {
                this.Cell.Container.HideNeighbors(this.Cell.Position);
            }
        }

        /// <summary>
        /// Action when right mouse is down.
        /// </summary>
        private void RightMouseDown()
        {
            if (this.Cell.Container.IsLocked)
            {
                return;
            }

            this.rightButtonIsDown = true;
            this.preventClick = true;
            if (this.leftButtonIsDown)
            {
                this.Cell.Container.ShowNeighbors(this.Cell.Position);
            }
        }
    }
}
