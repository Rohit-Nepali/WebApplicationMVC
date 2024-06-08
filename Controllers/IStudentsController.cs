using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Data;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public interface IStudentsController
    {
        ApplicationsDBcontext DbContext { get; }
        ApplicationsDBcontext DBcontext { get; }

        IActionResult Add();
        IActionResult Add(AddStudentViewModel viewModel);
    }
}