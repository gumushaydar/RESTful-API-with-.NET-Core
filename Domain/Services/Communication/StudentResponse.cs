using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherStudentAPI.Models;

namespace TeacherStudentAPI.Domain.Services.Communication
{
    public class StudentResponse : BaseResponse
    {
        public Student Student { get; set; }
        public StudentResponse(bool success , string message, Student student) : base(success , message)
        {
            Student = student;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="student">Saved product.</param>
        /// <returns>Response.</returns>
        public StudentResponse(Student student) : this(true, string.Empty, student)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public StudentResponse(string message) : this(false, message, null)
        { }


    }
}
