using UniversityProject_Demo.Models.Entity;

namespace UniversityProject_Demo.Models.Abstract
{
    public abstract class Person
    {
        public  int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassWord { get; set; }
        public string UserName { get; set; }
        public DateTime Time { get; set; }
        public string Email { get; set; }
        public bool IsItDeleted { get; set; }
        public string role { get; set; }
    }
}
