using Microsoft.AspNetCore.Mvc;
using UniversityProject_Demo.Database;
using UniversityProject_Demo.Database.ModelRepository;
using UniversityProject_Demo.Models.Entity;
using UniversityProject_Demo.Services;

namespace UniversityProject_Demo.Controllers
{
    public class StudentController : Controller
    {
        StudentRepository StudentsRepo =new StudentRepository();
        LoginServiceStudent ObjLogSt = new LoginServiceStudent();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllStudents()
        {
            return View(StudentsRepo.Students);
        }
        #region Create
        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateStudent(Student st)
        {
            StudentsRepo.Create(st);
            //redirectlogin
            return RedirectToAction("GetAllStudents");
        }
        #endregion

        #region Update
        public IActionResult UpdateStudent(int id)
        {
            id = 3;
            var sttt=StudentsRepo.GetById(id);
            return View(sttt);
        }
        [HttpPost]
        public IActionResult UpdateStudent(Student stt)
        {
            StudentsRepo.Update(stt);
            return RedirectToAction("GetAllStudents");
        }
        #endregion

        #region Delete
        [HttpPost]
        public IActionResult DeleteStudent(int Id)
        {
            StudentsRepo.Delete(Id);
            return RedirectToAction("GetAllStudents");
        }
        #endregion

        #region Login

        public IActionResult StudentLogin()
        {
                return View();
        }
        [HttpPost]
        public IActionResult StudentLogin(string user, string pass) {

            Student st = ObjLogSt.Login(user, pass);
            DataBase.CurrentStudent= st;
            return RedirectToAction("StudentPanel",st);
        }
        public IActionResult StudentPanel(Student st)
        {
            return View(st);
        }

        #endregion

        #region register
        public IActionResult StudentRegister()
        {
            return View();
        }
        [HttpPost]
        public IActionResult StudentRegister(Student st)
        {
            StudentsRepo.Create(st);
            return RedirectToAction("Index", "Home");
        }
        #endregion


    }
}
