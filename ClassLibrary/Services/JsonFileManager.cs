using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;



namespace ServicesClasslib
{
    public class JsonFileManager
    {
        //new folders name created in the project directory
        private const string DirectoryPath = "Data";


        // Object's type name (ex. Employee, Ticket) is saved to create ObjectName.json file in Data directory
        public void Save<T>(List<T> repositoryData)
        {
            string typeName = typeof(T).Name; // get the objects type name
            string filename = $"{typeName}.json";
            Directory.CreateDirectory(DirectoryPath); // create new directory
            string fullpath = Path.Combine(DirectoryPath, filename); //save directory and objectsname.json

            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(repositoryData, options);
            File.WriteAllText(fullpath, json);
            //WriteLine($"{typeName} collection is saved in {fullpath}");
        }


        // Object's type name (ex. Employee, Ticket) is saved to check if directory has ObjectName.json file
        // if no file exists, new empty List is returned, if file exists, data is deserialized 
        public List<T> Load<T>()
        {
            string typeName = typeof(T).Name;
            string filename = $"{typeName}.json";
            string fullpath = Path.Combine(DirectoryPath, filename);

            if (!File.Exists(fullpath))
            {
                Console.WriteLine($"File with {typeName} not found. new empty List is returned");
                return new List<T>();
            }

            string json = File.ReadAllText(fullpath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
    }
}