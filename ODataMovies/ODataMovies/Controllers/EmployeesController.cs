
using ODataMovies.Business;
using ODataMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.OData;

namespace ODataMovies.Controllers
{
    public class EmployeesController : ODataController
    {
        private DataService m_service = new DataService();
        // GET: Employees
        [EnableQuery]
        public IList<Employee> Get()
        {
            return m_service.Employees;
        }
    }
}