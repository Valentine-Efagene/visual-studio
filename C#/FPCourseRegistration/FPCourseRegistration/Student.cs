using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPCourseRegistration
{
    class Student
    {
        private string Name { set; get; }
        private string MatNumber { set; get; }
        private List<Course> Courses { set; get; }
    }
}
