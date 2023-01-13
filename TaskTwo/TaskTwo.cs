using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTwo
{
	public static class TaskTwo
	{
		public static void Task2()
		{
			Console.Clear();
			Console.WriteLine("Task #2 has been choosen.");
			DirectoryInfo path = new DirectoryInfo(GetPath());


			Console.WriteLine($"Directory size = {CalcSpace(path)} byte(s)");
			Console.ReadKey();
		}
		static string GetPath()
		{
			Console.WriteLine("Input correct path to directory, please.");
			string path = Console.ReadLine();
			try
			{
				DirectoryInfo dirInfo = new DirectoryInfo(path);
				if (dirInfo.Exists)
				{
					path = dirInfo.FullName;
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


			return GetPath();
		}

		static long CalcSpace(DirectoryInfo path)
		{
			long space = 0;
			FileInfo[] files = path.GetFiles();

			foreach (FileInfo file in files)
			{
				try
				{
					space += file.Length;
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			DirectoryInfo[] dirs = path.GetDirectories();

			foreach (DirectoryInfo dir in dirs)
			{
				try
				{
					space += CalcSpace(dir);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}
			}
			return space;
		}
	}
}
