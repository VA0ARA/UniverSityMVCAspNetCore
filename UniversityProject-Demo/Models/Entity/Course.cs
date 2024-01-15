using UniversityProject_Demo.Database;

namespace UniversityProject_Demo.Models.Entity
{
    public class Course
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public DateTime Time { get; set; }
        public bool IsItDeleted { get; set; }
        public int credit { get; set; }
        public decimal Mark { get; set; }
        public int capacity { get; set; }
        public Lecturer lectuerer { get; set; }
        /*        public Course(int id,string name,DateTime tim,bool isIt,int credit, Lecturer lec,decimal mark,int capa)
                {
                    this.Id = id;
                    this.Name = name;
                    this.Time = DateTime.Now;
                    this.IsItDeleted = isIt;
                    this.credit= credit;
                    this.lectuerer = lec;   
                    this.Mark=mark;
                    this.capacity = capa;
                }*/

    }
}
