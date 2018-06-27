using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EventLogDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //WritingToApplicationLog();
            //WritingToCustomLog();
            //Reading();
        }

        static void WritingToApplicationLog()
        {
            const string LOG_NAME = "Application";
            const string SOURCE_NAME = "My Source";

            // Create the event source (if not already created)
            if (!EventLog.SourceExists(SOURCE_NAME))
                EventLog.CreateEventSource(SOURCE_NAME, LOG_NAME);

            // Create an instance of the EventLog class mapping against the "Application" log
            EventLog log = new EventLog(LOG_NAME);
            log.Source = SOURCE_NAME;
            int eventId = 10;
            short category = 1;

            // Write entry
            log.WriteEntry("My message", EventLogEntryType.Information, eventId, category);
        }

        static void WritingToCustomLog()
        {
            const string LOG_NAME = "My Custom Log";
            const string SOURCE_NAME = "My Custom Source";

            // Create the event source (if not already created)
            if (!EventLog.Exists(LOG_NAME))
                EventLog.CreateEventSource(SOURCE_NAME, LOG_NAME);

            // Create an instance of the EventLog class mapping against the custom log
            EventLog log = new EventLog(LOG_NAME);
            log.Source = SOURCE_NAME;
            int eventId = 10;
            short category = 1;

            // Write entry
            log.WriteEntry("My message", EventLogEntryType.Information, eventId, category);
        }

        static void Reading()
        {
            EventLog log = new EventLog("Application");
            foreach (EventLogEntry entry in log.Entries)
            {
                if (entry.Source == "My Source")
                    Console.WriteLine(entry.Message);
            }
        }
    }
}
