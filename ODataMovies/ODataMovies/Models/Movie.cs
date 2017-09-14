using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ODataMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime ReleaseDate { get; set; }

        public StarRating Rating { get; set; }

        public Person Director { get; set; }

        public DateTime LastModifiedOn
        {
            get { return m_lastModifiedOn; }
            set { m_lastModifiedOn = value; }
        }

        public Movie CopyFrom(Movie rhs)
        {
            this.Title = rhs.Title;
            this.ReleaseDate = rhs.ReleaseDate;
            this.Rating = rhs.Rating;
            this.LastModifiedOn = DateTime.Now;
            return this;
        }

        [ForeignKey("Expense")]
        public int? ExpenseId { get; set; }

        public virtual MovieExpenses Expenses { get; set; }

        private DateTime m_lastModifiedOn = DateTime.Now;
    }
}