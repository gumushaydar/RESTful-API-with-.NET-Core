using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherStudentAPI.Persistence.Contexts;

namespace TeacherStudentAPI.Persistence.Repositories
{
    public class BaseRepository 
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
