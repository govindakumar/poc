using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OData.Logging
{
    public interface ILogMessage
    {
        void LogError(string message);
        void LogTrace(string message);
    }
}
