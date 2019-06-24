using AutoMapper;
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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IUnitOfWork _unitOfWork;


        public StudentService(IStudentRepository studentRepository, IUnitOfWork unitOfWork)
        {
            _studentRepository = studentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Student>> ListAsync()
        {
            return await _studentRepository.ListAsync();
        }

        public async Task<StudentResponse> FindByIdAsync(int id)
        {
            var existingStudent = await _studentRepository.FindByIdAsync(id);

            if (existingStudent == null)
                return new StudentResponse("Student Not Found");

            return new StudentResponse(existingStudent);
        }

        public async Task<StudentResponse> SaveAsync(Student student)
        {
            try
            {
                await _studentRepository.AddAsync(student);
                await _unitOfWork.CompleteAsync(); // if everything is ok , then we can save the changes (transaction).


                return new StudentResponse(student);
            }
            catch (Exception ex)
            {

                // Do some logging stuff
                return new StudentResponse($"An error occurred when saving the student: {ex.Message}");
            }
        }

        public async Task<StudentResponse> UpdateAsync(int id, Student student)
        {
            var existingStudent = await _studentRepository.FindByIdAsync(id);

            if (existingStudent == null)
                return new StudentResponse("Student Not Found");

            existingStudent.Name = student.Name;
            existingStudent.DepartmentName = student.DepartmentName;
            existingStudent.Season = student.Season;
            existingStudent.TeacherID = student.TeacherID;

            try
            {
                _studentRepository.Update(existingStudent);
                await _unitOfWork.CompleteAsync();

                return new StudentResponse(existingStudent);
            }
            catch (Exception ex)
            {

                // Do some logging stuff
                return new StudentResponse($"An error occurred when updating the student: {ex.Message}");
            }
        }

        public async Task<StudentResponse> DeleteAsync(int id)
        {
            var existingStudent = await _studentRepository.FindByIdAsync(id);

            if (existingStudent == null)
                return new StudentResponse("Student Not Found");

            try
            {
                _studentRepository.Remove(existingStudent);
                await _unitOfWork.CompleteAsync();

                return new StudentResponse(existingStudent);
            }
            catch (Exception ex)
            {

                // Do some logging stuff
                return new StudentResponse($"An error occurred when deleting the student: {ex.Message}");
            }
        }
    }
}
