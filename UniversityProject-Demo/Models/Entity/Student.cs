using UniversityProject_Demo.Models.Abstract;

namespace UniversityProject_Demo.Models.Entity
{
    public class Student:Person 
    {
        public List<Course> Courses { get; set; }
        public Student()
        {

        }
        public Student(int id,string firstName, string lastName, string password, string username, string email)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PassWord = password;
            this.UserName = username;
            this.Time = DateTime.Now;
            this.Email = email;
            IsItDeleted = false;
            this.role = "Student";
        }

    }
}
