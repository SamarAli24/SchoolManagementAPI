using AutoMapper;
using SchoolManagement.DBContext.Dto;
using SchoolManagement.Dto;
using SchoolManagement.Entities;

namespace SchoolManagement.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<StudentEntity, Student>().ReverseMap();
            CreateMap<TeacherEntity, Teacher>().ReverseMap();
            CreateMap<ParentEntity, Parents>().ReverseMap();
            CreateMap<ClassroomEntity, Classroom>().ReverseMap();
            CreateMap<SchoolEntity, School>().ReverseMap();
            CreateMap<StudentTeacherEntity, StudentAndTeacher>().ReverseMap().ForMember(x => x.Teacher,y=>y.Ignore()).ForMember(x => x.Student, y => y.Ignore());

        }

    }
}
