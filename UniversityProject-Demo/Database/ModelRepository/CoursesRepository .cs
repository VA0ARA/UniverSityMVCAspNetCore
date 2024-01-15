using UniversityProject_Demo.Models.Entity;

namespace UniversityProject_Demo.Database.ModelRepository
{
    public class CoursesRepository : IRepository<Course>
    {
        public Serialization<Course> ObjSerialization;
        public string FilePath;
        public List<Course> Courses { get; set; }

        public CoursesRepository()
        {
            ObjSerialization = new Serialization<Course>();
            FilePath = @"D:\files\ListCourses.txt";
            this.Courses = new List<Course>();   
            Courses = ObjSerialization.Deserialize(FilePath);
        }
        public List<Course> GetAll()
        {
            return Courses;
        }
        public bool Create(Course entity)
        {
            var LastCourse = Courses.LastOrDefault();
            entity.Id = (LastCourse.Id) + 1;
            entity.lectuerer = DataBase.CurrenLectures;
            Courses.Add(entity);
            ObjSerialization.SerializeListOfData(Courses, FilePath);
            return true;
        }
        public bool Get(int id)
        {
            var st = Courses.Any(x => x.Id == id);
            if (st == true)
            {
                return true;
            }
            return false;
        }
        public Course? GetById(int id)
        {
            if (Get(id) == true)
            {
                var Course = Courses.Where(x => x.Id == id).FirstOrDefault();
                return Course;
            }
            return null;
        }
        public bool Update(Course entity)
        {
            // var IsItExsit = Get(entity.Id);
            // if (IsItExsit ==true)
            // {
            var newentity = Courses.FirstOrDefault(x => x.Id == entity.Id);
            newentity.Name = entity.Name;
            newentity.credit = entity.credit;
            newentity.Time = entity.Time;
            newentity.capacity=entity.capacity;
            entity.lectuerer = DataBase.CurrenLectures;
            ObjSerialization.SerializeListOfData(Courses, FilePath);
            return true;
            //  }
            //return false;
        }
        public bool Delete(int id)
        {
            // if (Get(id) == true)
            //{
            var student = Courses.FirstOrDefault(x => x.Id == id);
            //student.IsItDeleted = true;
            Courses.Remove(student);
            ObjSerialization.SerializeListOfData(Courses, FilePath);
            return true;
            // }
            // return false;
        }

    }
}
