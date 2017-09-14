using ODataMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ODataMovies.Business
{
    public class DataService
    {
        #region MoviesDataService
        public List<Movie> Movies
        {
            get { return m_movies; }
        }

        public Movie Find(int id)
        {
            return Movies.Where(m => m.Id == id).FirstOrDefault();
        }

        public Movie Add(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException("Movie cannot be null");

            if (string.IsNullOrEmpty(movie.Title))
                throw new ArgumentException("Movie must have a title");

            if (m_movies.Exists(m => m.Title == movie.Title))
                throw new InvalidOperationException("Movie already present in catalog");

            lock(_lock)
            {                
                movie.Id = m_movies.Max(m => m.Id) + 1;
                m_movies.Add(movie);
            }

            return movie;
        }

        public bool Remove(int id)
        {
            int index = -1;

            for (int n=0; n < Movies.Count && index == -1; n++) if (Movies[n].Id == id) index = n;

            bool result = false;

            if (index != -1)
            {
                lock(_lock)
                {
                    Movies.RemoveAt(index);
                    result = true;
                }
            }

            return result;
        }

        public Movie Save(Movie movie)
        {
            if (movie == null) throw new ArgumentNullException("movie");

            Movie movieInstance = Movies.Where(m => m.Id == movie.Id).FirstOrDefault();

            if (movieInstance == null) throw new ArgumentException(string.Format("Did not find movie with Id: {0}", movie.Id));

            lock (_lock)
            {
                return movieInstance.CopyFrom(movie);
            }
        }

        private static List<Movie> m_movies = new Movie[]
        {
            new Movie { Id = 1, Rating = StarRating.FiveStar, ReleaseDate = new DateTime(2015, 10, 25), Title = "StarWars - The Force Awakens", Director = new Person { FirstName="J.J.", LastName="Abrams" },Expenses=new MovieExpenses { ExpenseId=123,Actor=1000000,Director=500000,Production=200000,Promotion=400000} },
            new Movie { Id = 2, Rating = StarRating.FourStar, ReleaseDate = new DateTime(2015, 5, 15), Title = "Mad Max - The Fury Road", Director = new Person { FirstName ="George", LastName="Miller" },Expenses=new MovieExpenses { ExpenseId=123,Actor=1000000,Director=500000,Production=200000,Promotion=400000} }
        }.ToList();

        private object _lock = new object();
        #endregion MoviesDataService

        #region EmployeeDataService
        private static List<Employee> m_emp = new Employee[]
        {
            new Employee { ID = 1, Name = "Govinda Kumar"},
             new Employee { ID = 2, Name = "Tarun Kumar"}
        }.ToList();

        public List<Employee> Employees
        {
            get { return m_emp; }
        }


        #endregion EmployeeDataService
    }
}