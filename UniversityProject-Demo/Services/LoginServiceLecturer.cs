using UniversityProject_Demo.Database;
using UniversityProject_Demo.Database.ModelRepository;
using UniversityProject_Demo.Models.Abstract;
using UniversityProject_Demo.Models.Entity;

namespace UniversityProject_Demo.Services
{
    public class LoginServiceLecturer
    {
        public string PassWord;
        public string UserName;
        public LecturerRepository ObjStRpo = new LecturerRepository();
        public Lecturer Login( string username,string passWord)
        {
            var lecturer = ObjStRpo.Lectures.FirstOrDefault(x => x.PassWord == passWord && x.UserName == username);
            return lecturer;
        }
    }
}
