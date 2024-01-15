using UniversityProject_Demo.Models.Abstract;

namespace UniversityProject_Demo.Models.Entity
{
    public class Lecturer:Person
    {
        public List <Student>Students { get; set; }
        public List<Course> Courses { get; set; }
        public Lecturer()
        {

        }
        public Lecturer(int Id,string firstName, string lastName, string password, string username, string email)
        {
            this.Id = Id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PassWord = password;
            this.UserName = username;
            this.Time = DateTime.Now;
            this.Email = email;
            this.IsItDeleted = false;
            this.role = "lecturer";


        }

    }
}
