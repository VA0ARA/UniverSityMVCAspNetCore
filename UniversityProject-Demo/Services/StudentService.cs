using UniversityProject_Demo.Database.ModelRepository;
using UniversityProject_Demo.Models.Entity;

namespace UniversityProject_Demo.Services
{
    public class StudentService
    {
       // public StudentRepository studentRepo { get; set; }
       // public CoursesRepository CourseRepo { get; set; }
       // public LessonRepository LessonRepo { get; set; }
       //// public Credit credit { get; set; }
       // public StudentService()
       // {
       //     this.studentRepo = new StudentRepository();
       //     this.CourseRepo = new CoursesRepository();
       //     this.LessonRepo = new LessonRepository();
       //     this.credit = new Credit(); 
       // }
       // public Student DisplayPersonalInfo(Student student)
       // {
           
       //     var st=studentRepo.GetById(student.Id);
       //     return st;
       // }

       // public List<Course> DisplayAllCourses()
       // {
       //     var courses = CourseRepo.GetAll();
       //     return courses;
       // }
       // public void SubmitCourses(Student student, int CourseId)
       // {
       //     var Course = CourseRepo.GetById(CourseId);
       //     Course.CounterCapacity++;
       //     bool CourseWasExsited =student.Courses.Any(x=>x.Id == CourseId);
       //     if (Course.CounterCapacity <= Course.Capacity && CourseWasExsited==false)
       //     {
       //         student.Courses.Add(Course);
       //         studentRepo.Update(student);
       //     }
       // }
       // public List<Course> DisplaySelectedCourses(Student st)
       // {
       //     var id=st.Id;
       //     var student = studentRepo.GetById(id);
       //     var courses = student.Courses;
       //     return courses;
       // }


    }
}
