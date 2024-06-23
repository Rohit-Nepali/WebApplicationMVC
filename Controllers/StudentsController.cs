using Application.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Mapper;
using WebApplicationMVC.Models.StudentVM;

namespace WebApplicationMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IWebApplicationInterface _iWebApplicationInterface;
        private readonly IStudentMapper _iStudentMapper;

        public StudentsController(IWebApplicationInterface iWebApplicationInterface,IStudentMapper iStudentMapper )
        {
            _iWebApplicationInterface = iWebApplicationInterface;
            _iStudentMapper = iStudentMapper;
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
        public IActionResult Add(AddStudentViewModel viewModel)
        {
            var student = _iStudentMapper.Add(viewModel);
            _iWebApplicationInterface.Add(student);
            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public async Task<IActionRe   sult> List()
        //{
        //    var students = await dbContext.Students.ToListAsync();

        //    return View(students);
        //}

        //[HttpGet]
        //public async Task<IActionResult> Edit(Guid id)
        //{
        //    var student = await dbContext.Students.FindAsync(id);

        //    return View(student);
        //}

        //[HttpPost]
        //public async Task<IActionResult> Edit(Student viewModel)
        //{
        //    var student = await dbContext.Students.FindAsync(viewModel.Id);

        //    if (student is not null)
        //    {
        //        student.Name = viewModel.Name;
        //        student.Email = viewModel.Email;
        //        student.Phone = viewModel.Phone;
        //        student.Subscribed = viewModel.Subscribed;

        //        await dbContext.SaveChangesAsync();

        //    }
        //    return RedirectToAction("List", "Students");
        //}

        //[HttpPost]

        //public async Task<IActionResult> Delete(Student viewModel)
        //{
        //    var student = await dbContext.Students
        //        .AsNoTracking()
        //        .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

        //    if (student is not null)
        //    {

        //        dbContext.Students.Remove(viewModel);
        //        await dbContext.SaveChangesAsync();
        //    }
        //    return RedirectToAction("List", "Students");
        //}
    }
}
