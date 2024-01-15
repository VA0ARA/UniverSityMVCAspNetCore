using Newtonsoft.Json;
using System.Text.Json;


namespace UniversityProject_Demo.Database
{
    public  class Serialization<T>

    {
        //serialize list of object to file
        public void SerializeListOfData(List<T> ListOfOBJ, string FilePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = System.Text.Json.JsonSerializer.Serialize(ListOfOBJ, options);
            File.WriteAllText(FilePath, jsonString);
        }
        //deserialize string  to list object
        public List<T> Deserialize(string FilePath)
        {
            List<T> ListOfObject = new List<T>();
            string AllObject = File.ReadAllText(FilePath);
            ListOfObject = JsonConvert.DeserializeObject<List<T>>(AllObject);
            return ListOfObject;
        }
        //    string FilePathMotor = @"D:\files\JFileMotor.txt";








    }
}
