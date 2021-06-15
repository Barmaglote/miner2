// <copyright file="BoolInverter.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EDU.Miner.Core.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    /// <summary>
    /// Bool Convertor.
    /// </summary>
    public class BoolInverter : IValueConverter
    {
        /// <summary>
        /// Converts object to bool with inversion.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="targetType">TargetType.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">Culture.</param>
        /// <returns>Converted value.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !((bool)value);
        }

        /// <summary>
        /// Converts object to bool.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="targetType">TargetType.</param>
        /// <param name="parameter">Parameter.</param>
        /// <param name="culture">Culture.</param>
        /// <returns>Converted value.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value;
        }
    }
}
