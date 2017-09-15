using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OData.Logging
{
    public class AppInsightLogging : ILogMessage
    {
        public void LogError(string message)
        {
            throw new NotImplementedException();
        }

        public void LogTrace(string message)
        {
            throw new NotImplementedException();
        }
    }
}