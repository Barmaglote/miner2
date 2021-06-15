// <copyright file="IMinerGame.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EDU.Miner.Core.Model
{
    /// <summary>
    /// Interface of game.
    /// </summary>
    public interface IMinerGame
    {
        /// <summary>
        /// Gets field.
        /// </summary>
        IField Field { get; }

        /// <summary>
        /// Gets a value indicating whether game is active.
        /// </summary>
        bool IsActive { get; }

        /// <summary>
        /// Run game.
        /// </summary>
        void Start();

        /// <summary>
        /// Stop game.
        /// </summary>
        void Stop();
    }
}
