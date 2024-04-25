using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.web.Data;
using StudentManagement.web.Models;
using StudentManagement.web.Models.Entities;

namespace StudentManagement.web.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext dbContext;
        public StudentController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult About()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Course = viewModel.Course
            };


            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("List", "Student");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
           var students = await dbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var students = await dbContext.Students.FindAsync(viewModel.Id);
            if(students is not null)
            {
                students.Name = viewModel.Name;
                students.Email = viewModel.Email;
                students.Phone = viewModel.Phone;
                students.Course = viewModel.Course;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Student");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await dbContext.Students
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if(student is not null)
            {
                dbContext.Students.Remove(viewModel); 
                dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Student");
        }
    }
}
