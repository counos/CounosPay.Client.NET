using System;

namespace CounosPayClient.Logger
{
    /// <summary>
    /// Holds the Instance Of ErrorManager
    /// <remarks></remarks>
    /// </summary>
    public class ErrorManager
    {
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="type"></param>
        public ErrorManager(string type)
        {
            //Logger = LogManager.GetLogger(type);
        }

        /// <summary>
        /// Logs an Error in Windows Event logs.
        /// </summary>
        /// <param name="ex"></param>
        public void LogError(string _counosPayAPI, Exception _ex ,string _methodname)
        {
            //Logger.Error(ex);
            if (!EventLog.SourceExists(_counosPayAPI))
                EventLog.CreateEventSource(_counosPayAPI, "Application");

            EventLog.WriteEntry(_counosPayAPI, _ex.Message + _methodname , EventLogEntryType.Error);
        }

        public void WebLogError(string _counosPayAPI, Exception _ex)
        {
            //Logger.Error(ex);
            if (!EventLog.SourceExists(_counosPayAPI))
                EventLog.CreateEventSource(_counosPayAPI, "Application");

            EventLog.WriteEntry(_counosPayAPI, _ex.Message, EventLogEntryType.Error);
        }

        /// <summary>
        /// To log error in log file.
        /// </summary>
        /// <param name="message"></param>
        public void LogMessage(string message)
        {
            var _strAppName = "CounosPayAPI";
            if (!EventLog.SourceExists(_strAppName))
                EventLog.CreateEventSource(_strAppName, "Application");

            EventLog.WriteEntry(_strAppName, message, EventLogEntryType.Information);
        }
    }
}