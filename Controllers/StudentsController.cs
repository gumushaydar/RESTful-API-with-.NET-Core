using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeacherStudentAPI.Domain.Services;
using TeacherStudentAPI.Extensions;
using TeacherStudentAPI.Models;
using TeacherStudentAPI.Resources;

namespace TeacherStudentAPI.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentResource>> GetListAsync()
        {
            var students = await _studentService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentResource>>(students);

            return resource;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var result = await _studentService.FindByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var studentResource = _mapper.Map<Student, StudentResource>(result.Student);

            return Ok(studentResource);

        }
        
        [HttpPost]
         public async Task<IActionResult> PostAsync([FromBody] SaveStudentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var student = _mapper.Map<SaveStudentResource, Student>(resource);

            var result = await _studentService.SaveAsync(student);

            if (!result.Success)
                return BadRequest(result.Message);

            var studentResource = _mapper.Map<Student, StudentResource>(result.Student);

            return Ok(studentResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveStudentResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var student = _mapper.Map<SaveStudentResource, Student>(resource);
            var result = await _studentService.UpdateAsync(id, student);

            if (!result.Success)
                return BadRequest(result.Message);

            var studentResource = _mapper.Map<Student, StudentResource>(result.Student);

            return Ok(studentResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _studentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(ModelState.GetErrorMessage());

            var studentResource = _mapper.Map<Student, StudentResource>(result.Student);

            return Ok(studentResource);
        }



    }
}