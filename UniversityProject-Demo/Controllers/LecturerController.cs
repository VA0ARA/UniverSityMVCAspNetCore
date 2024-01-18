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
/*        [HttpPost]
        public IActionResult LectutrerPanel(int id)
        {
            return View(id);
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
/*            if (ModelState.IsValid)
            {*/
                TempData["success"] = "create successfully";
                OBJcourseRepo.Create(co);
                return RedirectToAction("GetAllCourse");
/*            }
            return View();*/
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
        #region Mark
        public IActionResult Mark(int id)
        {
            Student st=StudentRepo.GetById(id);
            EntityStudentPanleDto obj=new EntityStudentPanleDto();
            obj.student = st;
            obj.Courcess = st.Courses;
            return View(obj);
        }
/*        [HttpPost]
        public IActionResult Mark(Course co)
        {

            return View();
        }
*/
        /*        public IActionResult GetMark(Course co)
                {
                    return View(co);
                }*/

        #endregion

    }
}
