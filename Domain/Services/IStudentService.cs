using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherStudentAPI.Domain.Services.Communication;
using TeacherStudentAPI.Models;

namespace TeacherStudentAPI.Domain.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> ListAsync();
        Task<StudentResponse> FindByIdAsync(int id);
        Task<StudentResponse> SaveAsync(Student student);
        Task<StudentResponse> UpdateAsync(int id, Student student);
        Task<StudentResponse> DeleteAsync(int id);
    }
}
