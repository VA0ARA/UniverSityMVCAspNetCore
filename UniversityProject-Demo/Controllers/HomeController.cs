using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UniversityProject_Demo.Database;
using UniversityProject_Demo.Models;
using UniversityProject_Demo.Models.Entity;

namespace UniversityProject_Demo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
/*            #region Create FirstDataBase
            //Lecturer
            Lecturer lec = new Lecturer()
            {
                Id = 1,
                FirstName = "Mohamad",
                LastName = "mohamadi",
                PassWord = "008MO",
                UserName = "MO",
                Time = DateTime.Now,
                Email = "Mohamad@gmail",
                IsItDeleted = false,
                role="Lecturer"
                
            };
            List<Lecturer> Lectures = new List<Lecturer>();
            Serialization<Lecturer> ser0 = new Serialization<Lecturer>();
            Lectures.Add(lec);
            ser0.SerializeListOfData(Lectures, @"D:\files\ListLecturers.txt");
            //student
            Student st = new Student()
            {
                Id = 1,
                FirstName = "Vahid",
                LastName = "AbedinAra",
                PassWord = "008Va",
                UserName = "Va",
                Time = DateTime.Now,
                Email = "Vahid@gmail",
                IsItDeleted = false,
                role="Student"
        };
            List<Student> Students = new List<Student>();
            Serialization<Student> ser1= new Serialization<Student>();
            Students.Add(st);
            ser1.SerializeListOfData(Students, @"D:\files\ListStudents.txt");
            //Course
            List<Course> Courses = new List<Course>();
            Course co = new Course()
            {
                Id = 1,
                Name = "math",
                Time = DateTime.Now,
                IsItDeleted = false,
                credit = 3,
                Mark = 0,
                capacity = 10,
                lectuerer = lec
            };
            Serialization<Course> ser = new Serialization<Course>();
            Courses.Add(co);
            ser.SerializeListOfData(Courses, @"D:\files\ListCourses.txt");
            #endregion*/
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}