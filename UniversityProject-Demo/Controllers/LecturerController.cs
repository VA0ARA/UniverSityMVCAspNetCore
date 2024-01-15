using Microsoft.AspNetCore.Mvc;
using UniversityProject_Demo.Database;
using UniversityProject_Demo.Database.ModelRepository;
using UniversityProject_Demo.Models.DTOs;
using UniversityProject_Demo.Models.Entity;
using UniversityProject_Demo.Services;

namespace UniversityProject_Demo.Controllers
{
    public class LecturerController : Controller
    {
        LecturerRepository lecturerRepo = new LecturerRepository();
        LoginServiceLecturer ObjLogLc = new LoginServiceLecturer();
        CoursesRepository OBJcourseRepo = new CoursesRepository();
        StudentRepository StudentRepo = new StudentRepository();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllLecturer()
        {
            return View(lecturerRepo.Lectures);
        }
        #region Create lecturer
        public IActionResult CreateLecturer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateLecturer(Lecturer le)
        {
            lecturerRepo.Create(le);
            //redirectlogin
            return RedirectToAction("GetAllLecturer");
        }
        #endregion
        #region Update lecturer
        public IActionResult UpdateLecturer(int id)
        {
            id = 3;
            var leee = lecturerRepo.GetById(id);
            return View(leee);
        }
        [HttpPost]
        public IActionResult UpdateLecturer(Lecturer lee)
        {
            lecturerRepo.Update(lee);
            return RedirectToAction("GetAllLecturer");
        }
        #endregion
        #region Delete lecturer
        [HttpPost]
        public IActionResult DeleteLecturer(int Id)
        {
            lecturerRepo.Delete(Id);
            return RedirectToAction("GetAllLecturer");
        }
        #endregion
        #region Login
        public IActionResult LecturerLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LecturerLogin(string user, string pass)
        {
            Lecturer lc = ObjLogLc.Login(user, pass);
            DataBase.CurrenLectures = lc;
            // return RedirectToAction("LectutrerPanel", lc);
            return RedirectToAction("LectutrerPanel");
        }
        public IActionResult LectutrerPanel()
        {
            EntityLecturerPanelDto obj=new EntityLecturerPanelDto();
            obj.lecture = DataBase.CurrenLectures;
            obj.students = StudentRepo.Students;
            return View(obj);
        }
/*        public IActionResult LectutrerPanel()
        {
            return View(DataBase.CurrenLectures);
        }*/
        #endregion
        #region register
        public IActionResult LecturerRegister()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LecturerRegister(Lecturer lc)
        {
            lecturerRepo.Create(lc);
            return RedirectToAction("Index", "Home");
        }
        #endregion
        #region Create Course
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
        public IActionResult GetAllCourse()
        {
            return View(OBJcourseRepo.GetAll());
        }
        #endregion
        #region Delete Course
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            OBJcourseRepo.Delete(Id);
            return RedirectToAction("GetAllCourse");
        }
        #endregion

    }
}
