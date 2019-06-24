using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherStudentAPI.Models;

namespace TeacherStudentAPI.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> ListAsync();

        Task<Student> FindByIdAsync(int id);

        Task AddAsync(Student student);
        void Update(Student student);
        void Remove(Student student);
    }
}
