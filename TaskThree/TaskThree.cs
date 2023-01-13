using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskThree
{
	public static class TaskThree
	{
		public static void Task3()
		{
			Console.Clear();
			Console.WriteLine("Task #3 has been choosen.");
			DirectoryInfo path = new DirectoryInfo(GetPath());
			long initialSpace = CalcSpace(path);
			DeleteUnused(path);
			long currentSpace = CalcSpace(path);
			long deletedSpace = initialSpace - currentSpace;
			Console.WriteLine($"\n Initial size was: {initialSpace} byte(s) \n Byte(s) deleted: {deletedSpace} \n Current space is: {currentSpace} byte(s) ");
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

		static void DeleteUnused(DirectoryInfo path)
		{
			DirectoryInfo[] dirs = path.GetDirectories();
			Console.WriteLine($"\n--->>> Directories <<<---\n Total directories in root: {dirs.Length}");
			foreach (DirectoryInfo dir in dirs)
			{


				if (DateTime.Now - dir.LastAccessTime >= TimeSpan.FromSeconds(10))
				{

					try
					{
						dir.Delete(true);
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}
				}
			}
			FileInfo[] files = path.GetFiles();
			Console.WriteLine($"\n--->>> Files <<<---\n Total files in root: {files.Length}");
			foreach (FileInfo file in files)
			{
				if (DateTime.Now - file.LastAccessTime >= TimeSpan.FromMinutes(10))
				{

					try
					{
						file.Delete();
					}
					catch (Exception e)
					{
						Console.WriteLine(e.Message);
					}

				}
			}
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
