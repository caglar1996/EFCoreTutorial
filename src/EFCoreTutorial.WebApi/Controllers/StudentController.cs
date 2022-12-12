using EFCoreTutorial.Data.Context;
using EFCoreTutorial.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTutorial.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public StudentController(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var students = await applicationDbContext.Students.ToListAsync();

            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Add()
        {
            Student st = new Student()
            {
                FirstName = "Çağlar",
                LastName = "KARABACAK",
                Number = 1,
                Address = new StudentAddress()
                {
                    City = "Tekirdağ",
                    District = "Çorlu",
                    Country = "Türkiye",
                    FullAddress = "XX Sokak"
                }
            };

            await applicationDbContext.Students.AddAsync(st);
            await applicationDbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await applicationDbContext.Students.FindAsync(id);

            if (student != null)
            {
                applicationDbContext.Students.Remove(student);
                applicationDbContext.SaveChanges();
            }
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update()
        {
            var student = await applicationDbContext.Students.FirstOrDefaultAsync();

            if (student != null)
            {
                student.FirstName = "Aysu";
                await applicationDbContext.SaveChangesAsync();
            }
            return Ok();
        }

    }
}
