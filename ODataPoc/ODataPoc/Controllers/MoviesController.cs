using ODataPoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.OData;

namespace ODataPoc.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        [EnableQuery]
        public IList<Movie> Get()
        {
            return m_service.Movies;
        }

        private DataService m_service = new DataService();

    }
}