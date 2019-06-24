using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeacherStudentAPI.Models;
using TeacherStudentAPI.Resources;

namespace TeacherStudentAPI.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Teacher, TeacherResource>();
            CreateMap<Student, StudentResource>();

        }
    }
}
