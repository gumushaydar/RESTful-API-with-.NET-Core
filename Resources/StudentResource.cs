using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherStudentAPI.Resources
{
    public class StudentResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public string Season { get; set; }
        public TeacherResource Teacher { get; set; }
    }
}
