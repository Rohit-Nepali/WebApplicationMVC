using Domain.Models;
using WebApplicationMVC.Models.StudentVM;

namespace WebApplicationMVC.Mapper
{
    public interface IStudentMapper
    {
        Student Add(AddStudentViewModel addStudentViewModel);
    }
}
