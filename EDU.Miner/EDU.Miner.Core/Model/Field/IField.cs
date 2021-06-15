// <copyright file="IField.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EDU.Miner.Core.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Game field.
    /// </summary>
    public interface IField
    {
        /// <summary>
        /// Gets All items.
        /// </summary>
        IEnumerable<ICell> Items { get; }

        /// <summary>
        /// Gets a value indicating whether field is locked.
        /// </summary>
        bool IsLocked { get; }

        /// <summary>
        /// Gets amount bombs not founded.
        /// </summary>
        int BombsIsLeft { get; }

        /// <summary>
        /// Unlock field.
        /// </summary>
        void UnLock();

        /// <summary>
        /// Lock field.
        /// </summary>
        void Lock();

        /// <summary>
        /// Fill field with items.
        /// </summary>
        void Fill();

        /// <summary>
        /// Open all items.
        /// </summary>
        void Open();

        /// <summary>
        /// Gets ammount of bombs by position.
        /// </summary>
        /// <param name="position">Position.</param>
        /// <returns>ammount of bombs.</returns>
        int CountBombsArround((int x, int y) position);

        /// <summary>
        /// Hide neighbors.
        /// </summary>
        /// <param name="position">Position.</param>
        void HideNeighbors((int x, int y) position);

        /// <summary>
        /// Show neighbors.
        /// </summary>
        /// <param name="position">Position.</param>
        void ShowNeighbors((int x, int y) position);

        /// <summary>
        /// Gets all neighbors.
        /// </summary>
        /// <param name="position">Position.</param>
        /// <returns>All neighbors.</returns>
        IEnumerable<ICell> GetNeighbors((int x, int y) position);
    }
}