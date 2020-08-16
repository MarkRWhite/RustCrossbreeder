using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace RustCrossbreeder.Logging
{
	/// <summary>
	/// A wrapper for the log4net logger instance to expose it to the program.  Handles logging messages throughout the program and writes them to a rolling log file
	/// </summary>
	public class Logger
	{
		#region Constants

		/// <summary>
		/// The name of the logger
		/// </summary>
		private const string LoggerName = "RustCrossbreederLogger";

		/// <summary>
		/// The Logger configuration file name
		/// </summary>
		private const string LoggerConfigurationFile = "logging.xml";

		#endregion

		#region Fields

		/// <summary>
		/// The logger instance backing field
		/// NOTE: This will be created once the public instance if first called
		/// </summary>
		private static Logger _instance;

		/// <summary>
		/// The log4net Logger implementation
		/// </summary>
		private ILog _logger;

		#endregion

		#region Static Properties

		/// <summary>
		/// Returns the Public Logger Singleton used for app information
		/// </summary>
		public static Logger Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new Logger(LoggerName, LoggerConfigurationFile);
				}

				return _instance;
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Create a new instance of a logger
		/// NOTE: This is only called by the singleton instantiation and thus this constructor is private
		/// </summary>
		/// <param name="loggerName"></param>
		/// <param name="loggerConfigurationFile"></param>
		private Logger(string loggerName, string loggerConfigurationFile)
		{
			// Create a Logger
			this._logger = LogManager.GetLogger(loggerName);
			XmlConfigurator.Configure(new System.IO.FileInfo(loggerConfigurationFile));
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Logs the specified message through the log4net logger file to the configured log file
		/// </summary>
		public void Log(Severity level, string message)
		{
			switch (level)
			{
				case Severity.Debug:
					_logger.DebugFormat(message);
					break;
				case Severity.Info:
					_logger.InfoFormat(message);
					break;
				case Severity.Warning:
					_logger.WarnFormat(message);
					break;
				case Severity.Error:
					_logger.ErrorFormat(message);
					break;
			}
		}

		#endregion

		#region Enums

		/// <summary>
		/// Lists all log severity levels
		/// </summary>
		public enum Severity
		{
			Debug,
			Info,
			Warning,
			Error
		}

		#endregion
	}
}
