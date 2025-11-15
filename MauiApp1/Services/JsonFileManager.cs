using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Storage;
using System.Text.Json;
using System.Diagnostics;



namespace Services
{
    public class JsonFileManager
    {
        //using Microsoft.Maui.Storage; works only in MAUI project,
        //so the JsonFilemanager should be in MAUI project, not in the ClassLibrary

        //new folder is created in the project directory
        string DirectoryPath = Path.Combine(FileSystem.AppDataDirectory, "Data");

        //workson windows only
        //string DirectoryPath = Path.Combine(Environment.CurrentDirectory, "Data");


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
            Debug.WriteLine($"Saving to: {fullpath}");
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
            Debug.WriteLine($"Loading from : {fullpath}");
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
            
        }
    }
}