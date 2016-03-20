using System;
using XamZueri.App.Annotations;

namespace XamZueri.App.Services
{
    public interface ILogger
    {
        /// <summary>
        ///     Writes a message followed by a line terminator to the plattform specific device logger.
        /// </summary>
        /// <param name="message">A message to write.</param>
        void Debug(string message);

        /// <summary>
        ///     Writes a formatted message followed by a line terminator to the plattform specific device logger.
        /// </summary>
        /// <param name="format">An object array that contains zero or more objects to format.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        [StringFormatMethod("format")]
        void Debug(string format, params object[] args);

        /// <summary>
        ///     Writes a message followed by a line terminator to the plattform specific device logger.
        /// </summary>
        /// <param name="message">A message to write.</param>
        void Info(string message);

        /// <summary>
        ///     Writes a formatted message followed by a line terminator to the plattform specific device logger.
        /// </summary>
        /// <param name="format">An object array that contains zero or more objects to format.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        [StringFormatMethod("format")]
        void Info(string format, params object[] args);

        /// <summary>
        ///     Writes a message followed by a line terminator to the plattform specific device logger.
        /// </summary>
        /// <param name="message">A message to write.</param>
        void Warn(string message);

        /// <summary>
        ///     Writes a formatted message followed by a line terminator to the plattform specific device logger.
        /// </summary>
        /// <param name="format">An object array that contains zero or more objects to format.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        [StringFormatMethod("format")]
        void Warn(string format, params object[] args);

        /// <summary>
        ///     Writes a message followed by a line terminator to the plattform specific device logger.
        /// </summary>
        /// <param name="message">A message to write.</param>
        void Error(string message);

        /// <summary>
        ///     Writes a formatted message followed by a line terminator to the plattform specific device logger.
        /// </summary>
        /// <param name="format">An object array that contains zero or more objects to format.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        [StringFormatMethod("format")]
        void Error(string format, params object[] args);

        /// <summary>
        ///     Writes an exception followed by a line terminator to the plattform specific device logger.
        /// </summary>
        /// <param name="ex">An exception to place in the output.</param>
        void Error(Exception ex);
    }
}