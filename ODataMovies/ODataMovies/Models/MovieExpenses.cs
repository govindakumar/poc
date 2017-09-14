using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataMovies.Models
{
    public class MovieExpenses
    {
        public int ExpenseId { get; set; }
        public float Production { get; set; }
        public float Director { get; set; }
        public float Actor { get; set; }
        public float Promotion { get; set; }
    }
}