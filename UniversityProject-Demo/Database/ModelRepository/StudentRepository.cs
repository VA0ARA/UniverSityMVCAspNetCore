using UniversityProject_Demo.Models.Entity;

namespace UniversityProject_Demo.Database.ModelRepository
{
    public class StudentRepository : IRepository<Student>
    {
        public Serialization<Student> ObjSerialization;
        public string FilePath;
        public List<Student> Students=new List<Student>();
        public StudentRepository()
        {
            ObjSerialization = new Serialization<Student>();
            FilePath = @"D:\files\ListStudents.txt";
           Students = ObjSerialization.Deserialize(FilePath);
        }
        public List<Student> GetAll()
        {
            return Students;
        }
        public bool Create(Student entity)
        {
                var LastStudent = Students.LastOrDefault();
                entity.Id = (LastStudent.Id) + 1;
                entity.role = "Student";
                Students.Add(entity);
                ObjSerialization.SerializeListOfData(Students, FilePath);
                return true;
        }
        public bool Get(int id)
        {
            var st = Students.Any(x => x.Id == id);
            if (st == true)
            {
                return true;
            }
            return false;
        }
        public Student? GetById(int id)
        {
            if (Get(id) == true)
            {
                var student = Students.Where(x=>x.Id==id).FirstOrDefault();
                return student;
            }
            return null;
        }
        public bool Update(Student entity)
        {
           // var IsItExsit = Get(entity.Id);
           // if (IsItExsit ==true)
           // {
                var newentity= Students.FirstOrDefault(x => x.Id == entity.Id);
                newentity.FirstName = entity.FirstName;
                newentity.LastName= entity.LastName;
                newentity.Email = entity.Email; 
                newentity.PassWord=entity.PassWord;
                newentity.UserName=entity.UserName;
                newentity.Courses= entity.Courses;
                //Students.Add(newentity);
                ObjSerialization.SerializeListOfData(Students, FilePath);
                return true;
          //  }
            //return false;
        }
        public bool Delete(int id)
        {
           // if (Get(id) == true)
            //{
                var student = Students.FirstOrDefault(x => x.Id == id);
                //student.IsItDeleted = true;
                Students.Remove(student);
                ObjSerialization.SerializeListOfData(Students, FilePath);
                return true;
           // }
           // return false;
        }





    }
}
