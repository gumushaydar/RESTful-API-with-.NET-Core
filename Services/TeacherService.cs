using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherStudentAPI.Domain.Repositories;
using TeacherStudentAPI.Domain.Services;
using TeacherStudentAPI.Domain.Services.Communication;
using TeacherStudentAPI.Models;

namespace TeacherStudentAPI.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TeacherService(ITeacherRepository teacherRepository, IUnitOfWork unitOfWork)
        {
            _teacherRepository = teacherRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<IEnumerable<Teacher>> ListAsync()
        {
            return await _teacherRepository.ListAsync();
        }

        public async Task<TeacherResponse> SaveAsync(Teacher teacher)
        {
            try
            {
                await _teacherRepository.AddAsync(teacher);
                await _unitOfWork.CompleteAsync(); // if everything is ok , then we can save the changes (transaction).
                

                return new TeacherResponse(teacher); 
            }
            catch (Exception ex)
            {

                // Do some logging stuff
                return new TeacherResponse($"An error occurred when saving the teacher: {ex.Message}");
            }
            
        }

        public async Task<TeacherResponse> UpdateAsync(int id, Teacher teacher)
        {
            var existingTeacher = await _teacherRepository.FindByIdAsync(id);

            if (existingTeacher == null)
                return new TeacherResponse("Teacher Not Found");

            existingTeacher.Name = teacher.Name;

            try
            {
                _teacherRepository.Update(existingTeacher);
                await _unitOfWork.CompleteAsync();

                return new TeacherResponse(existingTeacher);
            }
            catch (Exception ex)
            {

                // Do some logging stuff
                return new TeacherResponse($"An error occurred when updating the teacher: {ex.Message}");
            }

        }



        public async Task<TeacherResponse> DeleteAsync(int id)
        {
            var existingTeacher = await _teacherRepository.FindByIdAsync(id);

            if (existingTeacher == null)
                return new TeacherResponse("Teacher Not Found");

            try
            {
                _teacherRepository.Remove(existingTeacher);
                await _unitOfWork.CompleteAsync();

                return new TeacherResponse(existingTeacher);
            }
            catch (Exception ex)
            {

                // Do some logging stuff
                return new TeacherResponse($"An error occurred when deleting the teacher: {ex.Message}");
            }

        }

        public async Task<TeacherResponse> FindByIdAsync(int id)
        {
            var existingTeacher = await _teacherRepository.FindByIdAsync(id);
            if (existingTeacher == null)

                return new TeacherResponse("Teacher Not Found");

            return new TeacherResponse(existingTeacher);

        }
    }
}
