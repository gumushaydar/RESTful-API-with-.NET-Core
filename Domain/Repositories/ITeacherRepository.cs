using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherStudentAPI.Models;

namespace TeacherStudentAPI.Domain.Repositories
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> ListAsync();
        Task AddAsync(Teacher teacher);
        Task<Teacher> FindByIdAsync(int id);
        void Update(Teacher teacher);
        void Remove(Teacher teacher);

    }
}
