using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Other.DebuggingExternalSourceCode
{
    public class LoggingConfiguration
    {
        //public LogModes LogMode { get; set; } = LogModes.TextFile;
        public string LogFile { get; set; } = "~/logs/ApplicationLog.txt";
        public string ConnectionString { get; set; }
        public int LogDays { get; set; } = 7;
    }
}
