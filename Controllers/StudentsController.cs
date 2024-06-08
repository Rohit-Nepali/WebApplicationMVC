using Microsoft.AspNetCore.Mvc;
using WebApplicationMVC.Data;
using WebApplicationMVC.Models;
using WebApplicationMVC.Models.Entity;

namespace WebApplicationMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationsDBcontext dbContext;

        public StudentsController(ApplicationsDBcontext dbContext)
        { 
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index() 
        { 
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {

            var student = new Student 
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed
            };

            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
