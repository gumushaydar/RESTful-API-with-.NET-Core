using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherStudentAPI.Domain.Repositories;
using TeacherStudentAPI.Models;
using TeacherStudentAPI.Persistence.Contexts;

namespace TeacherStudentAPI.Persistence.Repositories
{
    public class TeacherRepository : BaseRepository, ITeacherRepository
    {
        public TeacherRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Teacher>> ListAsync()
        {
            return await _context.Teachers.ToListAsync();
        }

        public async Task AddAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
        }

        public async Task<Teacher> FindByIdAsync(int id)
        {
            return await _context.Teachers.FindAsync(id);
        }

        public void  Update(Teacher teacher)
        {
             _context.Teachers.Update(teacher);
        }

        public void Remove(Teacher teacher)
        {
            _context.Teachers.Remove(teacher);
        }
    }
}
