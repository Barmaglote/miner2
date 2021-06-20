// <copyright file="IAbstractFactory.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using EDU.Miner.Core.DataContext;

namespace EDU.Miner.Core.Model.Factory
{
    /// <summary>
    /// Abstract Factory.
    /// </summary>
    internal interface IAbstractFactory
    {
        /// <summary>
        /// Create certain cell.
        /// </summary>
        /// <param name="container">Container.</param>
        /// <param name="withBomb">Bomb is present.</param>
        /// <param name="position">Location on field.</param>
        /// <returns>ICell.</returns>
        ICell CreateCell(IField container, bool withBomb, (int x, int y) position);

        /// <summary>
        /// Create Field.
        /// </summary>
        /// <param name="size">Size.</param>
        /// <param name="bombs">Ammooun of bombs.</param>
        /// <returns>IField.</returns>
        IField CreateField((int Width, int Height) size, int bombs);

        /// <summary>
        /// Create new game.
        /// </summary>
        /// <param name="size">Size of field.</param>
        /// <param name="bombs">Ammount of bombs.</param>
        /// <returns>IMinerGame.</returns>
        IMinerGame CreateGame((int Width, int Height) size, int bombs);

        /// <summary>
        /// Creates new HistoryDataModelContext.
        /// </summary>
        /// <returns></returns>
        HistoryDataContext CreateHistoryDataModelContext();

        /// <summary>
        /// Creates repository to access HistoryData
        /// </summary>
        /// <returns></returns>
        IHistoryDataProvider CreateRepository();
    }
}
