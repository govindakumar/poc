using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OData.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string LogType { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}