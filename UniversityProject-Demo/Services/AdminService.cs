using UniversityProject_Demo.Database;
using UniversityProject_Demo.Database.ModelRepository;
using UniversityProject_Demo.Models.Entity;

namespace UniversityProject_Demo.Services
{
    public class AdminService
    {
        public StudentRepository studentRepo { get; set; }
        public CoursesRepository CourseRepo { get; set; }
        public LecturerRepository LecturerRepo { get; set; }
        public AdminService()
        {
            this.studentRepo = new StudentRepository();
            this.CourseRepo = new CoursesRepository();
            this.LecturerRepo = new LecturerRepository();
        }
        public Lecturer DisplayPersonalInfo(Lecturer lecturer)
        {
            var le = LecturerRepo.GetById(lecturer.Id);
            return le;
        }
        public List<Course> DisplayAllCourses()
        {
            var courses = CourseRepo.GetAll();
            return courses;
        }
        public void CreateCours(Course Course)
        { 
                CourseRepo.Create(Course);
        }
        public List<Student> DisplayAllStudent()
        {
            var studens = studentRepo.GetAll();
            return studens;
        }
        //public void GiveGrid(Student st, int IdCourse, double gride)
        //{
        //    bool IsItstudent = DataBase.Students.Any(student => student.Id == st.Id);

        //    if (IsItstudent == true && st.Courses.Any(x => x.Id == IdCourse))
        //    {
        //        bool DoHaveCreditWithName = st.credits.Any(x => x.lesson.Name == CourseRepo.GetById(IdCourse).Lesson.Name);
        //        if (DoHaveCreditWithName == true)
        //        {
        //            var CreditSt = st.credits.FirstOrDefault(x => x.lesson.Name == CourseRepo.GetById(IdCourse).Lesson.Name);
        //            CreditSt.Grid = gride;
        //        }
        //    }
        //}

    }
}

