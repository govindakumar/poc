using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPOC.DataAccess
{
    public class Standard
    {
        public Standard()
        {
            Students = new List<Student>();
        }
        public int StandardId { get; set; }
        public string StandardName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
