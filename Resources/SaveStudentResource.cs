using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeacherStudentAPI.Resources
{
    public class SaveStudentResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        public string DepartmentName { get; set; }

        [Required]
        [MaxLength(30)]
        public string Season { get; set; }

        [Required]
        public int TeacherId { get; set; }
    }
}
