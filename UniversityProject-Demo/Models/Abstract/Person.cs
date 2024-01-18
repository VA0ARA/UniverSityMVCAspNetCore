using System.ComponentModel.DataAnnotations;
using UniversityProject_Demo.Models.Entity;

namespace UniversityProject_Demo.Models.Abstract
{
    public abstract class Person
    {
        public  int Id { get; set; }
        //[Required]
        public string FirstName { get; set; }
       // [Required]
        public string LastName { get; set; }
       // [Required]
        public string PassWord { get; set; }
       // [Required]
        public string UserName { get; set; }
        public DateTime Time { get; set; }
       // [Required]
        public string Email { get; set; }
        public bool IsItDeleted { get; set; }
        public string role { get; set; }
    }
}
