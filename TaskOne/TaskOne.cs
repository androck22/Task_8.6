using System;
using System.IO;

namespace TaskOne
{
	public static class TaskOne
	{
		public static void Task1()
		{
			Console.Clear();
			Console.WriteLine("Task #1 has been choosen.");
			DirectoryInfo path = new DirectoryInfo(GetPath());
			DeleteUnused(path);
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
					Console.WriteLine("Path is incorrect, the folder does not exist at this address.");
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}


			return GetPath();
		}
		//static string GetFile()
		//{
		//	Console.WriteLine("Input correct path to file, please.");
		//	string path = Console.ReadLine();
		//	try
		//	{
		//		FileInfo fileInfo = new FileInfo(path);
		//		if (fileInfo.Exists)
		//		{
		//			path = fileInfo.FullName;
		//			return path;
		//		}
		//		else
		//		{
		//			Console.Clear();
		//			Console.WriteLine("Path is incorrect.");

		//		}
		//	}


		//	catch (Exception e)
		//	{
		//		Console.WriteLine(e.Message);
		//	}


		//	return GetFile();
		//}
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
				if (DateTime.Now - file.LastAccessTime >= TimeSpan.FromSeconds(10))
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
	}
}
