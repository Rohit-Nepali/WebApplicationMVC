using Application.Interface;
using Domain.Models;
using WebApplicationMVC.Models.StudentVM;

namespace WebApplicationMVC.Mapper
{
    public class StudentMapper : IStudentMapper
    {
        public Student Add(AddStudentViewModel addStudentViewModel)
        {
            var student = new Student
            {
                Name = addStudentViewModel.Name,
                Email = addStudentViewModel.Email,
                Phone = addStudentViewModel.Phone,
                Subscribed = addStudentViewModel.Subscribed
            };
            return student;
        }
    }
}
