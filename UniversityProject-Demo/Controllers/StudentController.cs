using Microsoft.AspNetCore.Mvc;
using UniversityProject_Demo.Database;
using UniversityProject_Demo.Database.ModelRepository;
using UniversityProject_Demo.Models.DTOs;
using UniversityProject_Demo.Models.Entity;
using UniversityProject_Demo.Services;

namespace UniversityProject_Demo.Controllers
{
    public class StudentController : Controller
    {
        StudentRepository StudentsRepo =new StudentRepository();
        LoginServiceStudent ObjLogSt = new LoginServiceStudent();
        CoursesRepository ObjCoursRepo= new CoursesRepository();
        public static List<Course> ListTempCourse = new List<Course>();

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
            //return RedirectToAction("StudentPanel",st);
            return RedirectToAction("StudentPanel");
        }
        public IActionResult StudentPanel(Student st)
        {
            EntityStudentPanleDto obj = new EntityStudentPanleDto();
            obj.student = DataBase.CurrentStudent;
            obj.Courcess = ObjCoursRepo.Courses;

            return View(obj);
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


        #region Create Course
        public IActionResult SelectCourse()
        {
            var courses=ObjCoursRepo.GetAll();
            return View(courses);
        }
        [HttpPost]
        public IActionResult SelectCourse(int id)
        {
            if (ObjCoursRepo.Get(id) == true  )
            {
                var course = ObjCoursRepo.GetById(id);
                if (course.capacity != 0)
                {
                    //add to student list
                    ListTempCourse.Add(course);
                    DataBase.CurrentStudent.Courses = new List<Course>();
                    DataBase.CurrentStudent.Courses = ListTempCourse;
       /*                    DataBase.CurrentStudent.Courses = new List<Course>()
                                        {
                                            course
                                        };*/
                    // DataBase.CurrentStudent.Courses.Add(course);
                    var st =DataBase.CurrentStudent;    
                    StudentsRepo.Update(st);
                    //reduce capacity
                    course.capacity = course.capacity - 1;
                    //update in database
                    ObjCoursRepo.Update(course);
                    return RedirectToAction("GetAllCourse");
                }
            }
/*            else
            {
                return RedirectToAction("GetAllCourse");
            }*/
            return RedirectToAction("GetAllCourse");
        }
        public IActionResult GetAllCourse()
        {
            return View(ObjCoursRepo.GetAll());
        }
        #endregion
        #region Delete Course
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            ObjCoursRepo.Delete(Id);
            return RedirectToAction("GetAllCourse");
        }
        #endregion





    }
}
