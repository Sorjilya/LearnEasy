using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasy
{
	class JsonScores
    {
        private static string filePath = "";
        private static string fileName = "w1.json";
        public void SetPath(string path)
        {
            filePath = path;
        }
        public void SetName(string name)
        {
            fileName = name;
        }
        public void SaveToFile(List<Results> results)
        {
            var t = LoadFromFile();
            for (int i = 0; i < t.Count; i++)
            {
                results.Add(t[i]);
            }
            string json = JsonConvert.SerializeObject(results, Formatting.Indented);
            File.WriteAllText(filePath + fileName, json);
        }

        public List<Results> LoadFromFile()
        {
            if (!File.Exists(filePath + fileName))
            {
                return new List<Results>();
            }

            string json = File.ReadAllText(filePath + fileName);
            return JsonConvert.DeserializeObject<List<Results>>(json);
        }
    }
}
