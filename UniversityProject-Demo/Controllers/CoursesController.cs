using Microsoft.AspNetCore.Mvc;
using UniversityProject_Demo.Database;
using UniversityProject_Demo.Database.ModelRepository;
using UniversityProject_Demo.Models.DTOs;
using UniversityProject_Demo.Models.Entity;

namespace UniversityProject_Demo.Controllers
{
    public class CoursesController : Controller
    {
        CoursesRepository OBJcourseRepo=new CoursesRepository();
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult GetAllCourse()
        {
            CourseDto objCourseDto = new CourseDto();
            objCourseDto.course= OBJcourseRepo.GetAll();
            return View(objCourseDto.course);
        }

        #region Create
        public IActionResult CreateCourse()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCourse(Course co)
        {
          OBJcourseRepo.Create(co);
            return RedirectToAction("GetAllCourse");
        }
        #endregion

        #region Update
        public IActionResult UpdateCourse(int id)
        {
            id = 3;
            var cooo = OBJcourseRepo.GetById(id);
            return View(cooo);
        }
        [HttpPost]
        public IActionResult UpdateCourse(Course coo)
        {
            OBJcourseRepo.Update(coo);
            return RedirectToAction("GetAllCourse");
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            OBJcourseRepo.Delete(Id);
            return RedirectToAction("GetAllCourse");
        }
        #endregion
    }
}
