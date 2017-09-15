using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OData.Logging
{
    public class DBLogging: ILogMessage
    {
        Models.ProductsContext db = new Models.ProductsContext();

        public void LogError(string message)
        {
            Models.Log objLog = new Models.Log()
            {
                LogType = "Error",
                Message = message,
                CreatedDate = DateTime.Now
            };
            db.Logs.Add(objLog);
            db.SaveChangesAsync();

        }

        public void LogTrace(string message)
        {
            Models.Log objLog = new Models.Log()
            {
                LogType = "Trace",
                Message = message,
                CreatedDate = DateTime.Now
            };
            db.Logs.Add(objLog);
            db.SaveChangesAsync();
        }
    }
}