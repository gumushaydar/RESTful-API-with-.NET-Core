using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherStudentAPI.Models;

namespace TeacherStudentAPI.Domain.Services.Communication
{
    public class TeacherResponse : BaseResponse
    {
        public Teacher Teacher { get; set; }
        public TeacherResponse(bool success, string message, Teacher teacher) : base(success, message)
        {
            Teacher = teacher;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="teacher">Saved category.</param>
        /// <returns>Response.</returns>
        public TeacherResponse(Teacher teacher) : this(true, string.Empty, teacher)
        { }


        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public TeacherResponse(string message) : this(false, message, null)
        {}


    }
}
