using UniversityProject_Demo.Database;
using UniversityProject_Demo.Database.ModelRepository;
using UniversityProject_Demo.Models.Abstract;
using UniversityProject_Demo.Models.Entity;

namespace UniversityProject_Demo.Services
{
    public class LoginServiceStudent
    {
        public string PassWord;
        public string UserName;
        public StudentRepository ObjStRpo = new StudentRepository();
        public Student Login( string username,string passWord)
        {
            var student = ObjStRpo.Students.FirstOrDefault(x => x.PassWord == passWord && x.UserName == username);
            return student;
        }
    }
}
