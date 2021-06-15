// <copyright file="ConcreteFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EDU.Miner.Core.Model.Factory
{
    using EDU.Miner.Core.ViewModel;

    /// <summary>
    /// Abstract factory realization.
    /// </summary>
    internal class ConcreteFactory : IAbstractFactory
    {
        /// <summary>
        /// Creates Cell.
        /// </summary>
        /// <param name="container">Container.</param>
        /// <param name="withBomb">Bomb is present.</param>
        /// <param name="position">Position.</param>
        /// <returns>ICell.</returns>
        public ICell CreateCell(IField container, bool withBomb, (int x, int y) position)
        {
            return new Cell(container, withBomb, position);
        }

        /// <summary>
        /// Creates field.
        /// </summary>
        /// <param name="size">Size of field.</param>
        /// <param name="bombs">Ammount bombs.</param>
        /// <returns>IField.</returns>
        public IField CreateField((int Width, int Height) size, int bombs)
        {
            return new StandardField(size, bombs);
        }

        /// <summary>
        /// Creates game.
        /// </summary>
        /// <param name="size">Size of field.</param>
        /// <param name="bombs">Ammount of bombs.</param>
        /// <returns>IMinerGame.</returns>
        public IMinerGame CreateGame((int Width, int Height) size, int bombs)
        {
            return new StandardMinerGame(size, bombs);
        }

        /// <summary>
        /// Create StartGameCommand.
        /// </summary>
        /// <param name="vm">GameViewModel.</param>
        /// <returns>IStartGameCommand.</returns>
        public IStartGameCommand CreateStartGameCommand(GameViewModel vm)
        {
            return new StartGameCommand(vm);
        }
    }
}
