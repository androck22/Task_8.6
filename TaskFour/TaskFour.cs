using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace TaskFour
{
	public static class TaskFour
	{
		public static void Task4()
		{
			Console.Clear();
			Console.WriteLine("Task #4 has been choosen.");
			BinaryFormatter formatter = new BinaryFormatter();
			using FileStream fs = new FileStream(GetFile(), FileMode.OpenOrCreate);
			{
				try
				{
					Student[] st = (Student[])formatter.Deserialize(fs);
					string destopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
					DirectoryInfo dirinfo = new DirectoryInfo(destopPath + "/Students/");
					if (!dirinfo.Exists) dirinfo.Create();

					string dirFullName = dirinfo.FullName;

					foreach (Student stud in st)
					{
						string filePath = dirFullName + stud.Group + ".txt";
						string strToWrite = stud.Name + ", " + stud.DateOfBirth.ToString();
						if (!File.Exists(filePath))
						{
							using (StreamWriter sw = File.CreateText(filePath)) ;
						}
						else
						{
							FileInfo fileInfo = new FileInfo(filePath);
							using (StreamWriter sw = fileInfo.AppendText())
							{
								sw.WriteLine(strToWrite);
							}

						}

					}
					Console.WriteLine("Sorting complete.");
					Console.ReadKey();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
		}

		static string GetFile()
		{
			Console.WriteLine("Input correct path to file, please.");
			string path = Console.ReadLine();
			try
			{
				FileInfo fileInfo = new FileInfo(path);
				if (fileInfo.Exists)
				{
					path = fileInfo.FullName;
					return path;
				}
				else
				{
					Console.Clear();
					Console.WriteLine("Path is incorrect.");

				}
			}


			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}


			return GetFile();
		}
	}
}
