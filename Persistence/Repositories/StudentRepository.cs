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
    public class StudentRepository : BaseRepository, IStudentRepository
    {

        public StudentRepository(AppDbContext context) : base(context) { }


        public async Task<IEnumerable<Student>> ListAsync()
        {
            return await _context.Students.Include(p => p.Teacher)
                                   .ToListAsync();
        }


        public async Task<Student> FindByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);

        }

        public void Update(Student student)
        {
            _context.Students.Update(student);
        }

        public void Remove(Student student)
        {
            _context.Students.Remove(student);
        }
    }
}
