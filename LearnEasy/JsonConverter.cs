using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnEasy
{
	class JsonWordsFile
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
		public void SaveToFile(List<Word> data)
		{
			var t = LoadFromFile();
			for (int i = 0; i < t.Count; i++)
			{
				data.Add(t[i]);
			}
			string json = JsonConvert.SerializeObject(data, Formatting.Indented);
			File.WriteAllText(filePath + fileName, json);
		}
		public void DeleteWord(string word)
		{
			var t = LoadFromFile();
			List<Word> data = new List<Word>();
			for (int i = 0; i < t.Count; i++)
			{
				bool isThere = false;
				for(int j = 0; j < t[i].Words.Count; j++)
				{
					if(t[i].Words[j].Word == word)
					{
						isThere = true;
						break;
					}
				}
				if (!isThere)
				{
					data.Add(t[i]);
				}
			}
			string json = JsonConvert.SerializeObject(data, Formatting.Indented);
			File.WriteAllText(filePath + fileName, json);
		}
		public void DeleteGroup(string grr)
		{
			var t = LoadFromFile();
			List<Word> data = new List<Word>();
			for (int i = 0; i < t.Count; i++)
			{
				if(t[i].Group != grr)
				{
					data.Add(t[i]);
				}
			}
			string json = JsonConvert.SerializeObject(data, Formatting.Indented);
			File.WriteAllText(filePath + fileName, json);
		}
		public List<Word> LoadFromFile()
		{
			if (!File.Exists(filePath + fileName))
				return new List<Word>();

			string json = File.ReadAllText(filePath + fileName);
			return JsonConvert.DeserializeObject<List<Word>>(json);
		}
		
	}
}
