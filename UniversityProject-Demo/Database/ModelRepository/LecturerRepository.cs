using UniversityProject_Demo.Models.Entity;

namespace UniversityProject_Demo.Database.ModelRepository
{
    public class LecturerRepository : IRepository<Lecturer>
    {
        public Serialization<Lecturer> ObjSerialization;
        public string FilePath;
        public List<Lecturer> Lectures=new List<Lecturer>();
        public LecturerRepository()
        {
            ObjSerialization = new Serialization<Lecturer>();
            FilePath = @"D:\files\ListLecturers.txt";
            Lectures = ObjSerialization.Deserialize(FilePath);
        }
        public bool Create(Lecturer entity)
        {
            var LastLecturer = Lectures.LastOrDefault();
            entity.Id = (LastLecturer.Id) + 1;
            entity.role = "Lecturer";
            Lectures.Add(entity);
            ObjSerialization.SerializeListOfData(Lectures, FilePath);
            return true;
        }
        public bool Get(int id)
        {
            var st = Lectures.Any(x => x.Id == id);
            if (st == true)
            {
                return true;
            }
            return false;
        }
        public List<Lecturer> GetAll()
        {
            return Lectures;
        }
        public Lecturer? GetById(int id)
        {
            if (Get(id) == true)
            {
                var lecturer = Lectures.Where(x => x.Id == id).FirstOrDefault();
                return lecturer;
            }
            return null;
        }
        public bool Update(Lecturer entity)
        {
            var newentity = Lectures.FirstOrDefault(x => x.Id == entity.Id);
            newentity.FirstName = entity.FirstName;
            newentity.LastName = entity.LastName;
            newentity.Email = entity.Email;
            newentity.PassWord = entity.PassWord;
            newentity.UserName = entity.UserName;
            ObjSerialization.SerializeListOfData(Lectures, FilePath);
            return true;

        }
        public bool Delete(int id)
        {
            var lecturer = Lectures.FirstOrDefault(x => x.Id == id);
            Lectures.Remove(lecturer);
            ObjSerialization.SerializeListOfData(Lectures, FilePath);
            return true;
        }

        /*        public bool Get(int id)
       {
           var st = Lectures.Where(x => x.Id == id).First();
           if (st != null)
           {
               return true;
           }
           return false;
       }
       public List<Lecturer> GetAll()
       {
           return Lectures;
       }
       public Lecturer? GetById(int id)
       {
           if (Get(id) == true)
           {
               var lecturer = Lectures.FirstOrDefault();
               return lecturer;
           }
           return null;
       }
       public bool Update(Lecturer entity)
       {
           var newent = Lectures.FirstOrDefault(x => x.Id == entity.Id);
           if (newent != null)
           {
               Lectures.Add(newent);
               ObjSerialization.SerializeListOfData(Lectures, FilePath);
               return true;
           }
           return false;
       }
       public bool Delete(int id)
       {
           if (Get(id) == true)
           {
               var lecturer = Lectures.FirstOrDefault(x => x.Id == id);
               lecturer.IsItDeleted = true;
               ObjSerialization.SerializeListOfData(Lectures, FilePath);
               return true;
           }
           return false;
       }*/
    }
}
