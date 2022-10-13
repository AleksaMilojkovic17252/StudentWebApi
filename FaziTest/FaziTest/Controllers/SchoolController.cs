using FaziTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FaziTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        public modelContext Context { get; set; }

        public SchoolController(modelContext con)
        {
            Context = con;
        }


        //STUDENTS
        [Route("AddStudent")]
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student s)
        {
            Context.Students.Add(s);
            await Context.SaveChangesAsync();
            return Ok();
        }

        [Route("ChangeStudent")]
        [HttpPut]
        public async Task<IActionResult> ChangeStudent([FromBody] Student s)
        {
            Context.Students.Update(s);
            await Context.SaveChangesAsync();
            return NoContent();
        }

        [Route("DeleteStudent/{id}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var student = await Context.Students.SingleAsync(prop => prop.StudentId == id);
                Context.Remove(student);
                await Context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(title: "Unknown student", detail: "Deleting unknown student", statusCode: 500);
            }
        }

        //COURSES

        [Route("AddCourse")]
        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] Kur course)
        {
            Context.Kurs.Add(course);
            await Context.SaveChangesAsync();
            return Ok();
        }

        [Route("ChangeCourse")]
        [HttpPut]
        public async Task<IActionResult> ChangeCourse([FromBody] Kur course)
        {
            Context.Kurs.Update(course);
            await Context.SaveChangesAsync();
            return NoContent();
        }

        [Route("DeleteCourse/{code}")]
        [HttpDelete]
        public async Task<IActionResult> ChangeCourse(string code)
        {
            try
            {
                var course = await Context.Kurs.SingleAsync(prop => prop.Kod == code);
                Context.Remove(course);
                await Context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(title: "Unknown course", detail: "Deleting unknown course", statusCode: 500);
            }
        }

        //Everything together

        [Route("GetStudentsAndCourses")]
        [HttpGet]
        public async Task<StudentKur> GetStudentsAndCourses()
        {
            StudentKur zaPovracaj = new StudentKur();
            zaPovracaj.Studenti = await Context.Students.Include(prop => prop.Ocenas).ThenInclude(prop => prop.KursKodNavigation).ToListAsync();
            zaPovracaj.Kursevi = await Context.Kurs.ToListAsync();
            return zaPovracaj;

        }

        [Route("Filter")]
        [HttpPost]
        public async Task<StudentKur> Filter([FromBody] FilterOptions options)
        {

            StudentKur zaPovracaj = new StudentKur();
            zaPovracaj.Studenti = await Context.Students.Include(prop => prop.Ocenas).ThenInclude(prop => prop.KursKodNavigation).ToListAsync();
            
            if (options.CourseName != "")
            {
                zaPovracaj.Kursevi = await Context.Kurs.Where(prop=>prop.Ime.ToLower().Contains(options.CourseName.ToLower())).ToListAsync();
                for (int i = 0; i < zaPovracaj.Studenti.Count; i++)
                {
                    zaPovracaj.Studenti[i].Ocenas.RemoveAll(prop => !prop.KursKodNavigation.Ime.ToLower().Contains(options.CourseName.ToLower()));
                }
            }
            else
            {
                zaPovracaj.Kursevi = await Context.Kurs.ToListAsync();  
            }
            if (options.StudentName != "")
            {
                zaPovracaj.Studenti = zaPovracaj.Studenti.Where(prop => prop.Ime.ToLower().Contains(options.StudentName.ToLower()) || prop.Prezime.ToLower().Contains(options.StudentName.ToLower())).ToList();
            }
            return zaPovracaj;
        }
    }
}
