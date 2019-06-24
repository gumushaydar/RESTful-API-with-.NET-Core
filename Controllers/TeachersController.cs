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
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherService teacherService,IMapper mapper)
        {
            _teacherService = teacherService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<TeacherResource>> GetListAsync()
        {
            var teachers = await _teacherService.ListAsync();

            var resource = _mapper.Map<IEnumerable<Teacher>, IEnumerable<TeacherResource>>(teachers);

            return resource;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var result = await _teacherService.FindByIdAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var teacherResource = _mapper.Map<Teacher, TeacherResource>(result.Teacher);

            return Ok(teacherResource);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveTeacherResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var teacher = _mapper.Map<SaveTeacherResource, Teacher>(resource);

            var result = await _teacherService.SaveAsync(teacher);

            if (!result.Success)
                return BadRequest(result.Message);

            var teacherResource = _mapper.Map<Teacher, TeacherResource>(result.Teacher);

            return Ok(teacherResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveTeacherResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessage());

            var teacher = _mapper.Map<SaveTeacherResource, Teacher>(resource);
            var result = await _teacherService.UpdateAsync(id, teacher);

            if (!result.Success)
                return BadRequest(result.Message);

            var teacherResource = _mapper.Map<Teacher, TeacherResource>(result.Teacher);

            return Ok(teacherResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _teacherService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(ModelState.GetErrorMessage());

            var teacherResource = _mapper.Map<Teacher, TeacherResource>(result.Teacher);

            return Ok(teacherResource);
        }









    }
}