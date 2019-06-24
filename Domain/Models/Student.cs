using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherStudentAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DepartmentName { get; set; }
        public string Season { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher  { get; set; }
    }
}
