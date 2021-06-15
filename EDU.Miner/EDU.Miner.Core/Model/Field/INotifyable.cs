// <copyright file="INotifyable.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EDU.Miner.Core.Model
{
    /// <summary>
    /// Interface of class that notify it's subscribers.
    /// </summary>
    public interface INotifyable
    {
        /// <summary>
        /// Can notify object it's subscribers.
        /// </summary>
        void NotifyOnUpdate();
    }
}
