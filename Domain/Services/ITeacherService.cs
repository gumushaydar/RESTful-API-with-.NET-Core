using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherStudentAPI.Domain.Services.Communication;
using TeacherStudentAPI.Models;

namespace TeacherStudentAPI.Domain.Services
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> ListAsync();
        Task<TeacherResponse> SaveAsync(Teacher teacher);
        Task<TeacherResponse> UpdateAsync(int id, Teacher teacher);
        Task<TeacherResponse> DeleteAsync(int id);
        Task<TeacherResponse> FindByIdAsync(int id);
    }
}
