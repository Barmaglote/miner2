// <copyright file="ICell.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EDU.Miner.Core.Model
{
    /// <summary>
    /// Single cell of field.
    /// </summary>
    public interface ICell
    {
        /// <summary>
        /// Gets bombs arround.
        /// </summary>
        int BombsArroundFounded { get; }

        /// <summary>
        /// Gets bombs arround string.
        /// </summary>
        string BombsArround { get; }

        /// <summary>
        /// Gets a value indicating whether hidden.
        /// </summary>
        bool IsHidden { get; }

        /// <summary>
        /// Gets a value indicating whether marked.
        /// </summary>
        bool IsMarked { get; }

        /// <summary>
        /// Gets a value indicating whether mined.
        /// </summary>
        bool IsMined { get; }

        /// <summary>
        /// Gets a value indicating whether opened.
        /// </summary>
        bool IsOpened { get; }

        /// <summary>
        /// Gets a value indicating whether cell with bombed is opened.
        /// </summary>
        bool IsMinedAndOpened { get; }

        /// <summary>
        /// Gets position.
        /// </summary>
        (int x, int y) Position { get; }

        /// <summary>
        /// Gets container for cell.
        /// </summary>
        IField Container { get; }

        /// <summary>
        /// Hide button.
        /// </summary>
        void Hide();

        /// <summary>
        /// Mark cell.
        /// </summary>
        void Mark();

        /// <summary>
        /// Open cell.
        /// </summary>
        /// <param name="isRecursive">Recursively.</param>
        void Open(bool isRecursive = true);

        /// <summary>
        /// Show cell.
        /// </summary>
        void Show();
    }
}
