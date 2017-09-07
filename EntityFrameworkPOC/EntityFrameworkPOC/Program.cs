using EntityFrameworkPOC.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkPOC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Alaska DB got configuring.");
            using (var ctx = new SchoolContext())
            {
                //Course course = new Course()
                //{
                //    CourseName = "English"
                //};
                //Standard std = new Standard()
                //{
                //    StandardName = "Std 1",
                //};
                //ctx.Courses.Add(course);
                //ctx.Standards.Add(std);
                var courses = new List<Course>();
                var course = new Course()
                {
                    CourseId = 1
                };
                courses.Add(course);
                Student stud = new Student() {
                    StudentName = "RajSwarup", DateOfBirth=new DateTime(2000,06,16),
                    //Weight =60, 
                    StdId =1,Address=new StudentAddress {
                        Address1="Address11",
                        Address2="Address22",
                        City="Kolkata",
                         State="WB",
                          Country="India",
                          Zipcode=700091,
                    }, Courses= courses
                };
                ctx.Students.Add(stud); 
                ctx.SaveChanges();
                Console.WriteLine("Alaska DB got configured.");
            }
            Console.ReadLine();
        }
    }
}
