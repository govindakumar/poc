using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPOC.DataAccess
{
    public class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
        }
        public int StudentKey { get; set; }
        public string StudentName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
        public decimal Height { get; set; }
        //public float Weight { get; set; }
        public int StdId { get; set; }
        public string FathersName { get; set; }
        public virtual Standard Standard { get; set; }
        public virtual StudentAddress Address {get;set;}
        public virtual ICollection<Course> Courses { get; set; }
    }
}
