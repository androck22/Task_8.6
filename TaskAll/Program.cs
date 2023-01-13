using System;

namespace TaskAll
{
	internal class Program
	{
		static void Main(string[] args)
		{
			ChooseTask();
		}

		static void ChooseTask()
		{
			Console.Clear();
			Console.WriteLine("Choose task \n 1 - Task #1 \n 2 - Task #2 \n 3 - Task #3 \n 4 - Task #4");

			switch (Console.ReadLine())
			{
				case "1":
					TaskOne.TaskOne.Task1();
					break;

				case "2":
					TaskTwo.TaskTwo.Task2();
					break;

				case "3":
					TaskThree.TaskThree.Task3();
					break;
				case "4":
					TaskFour.TaskFour.Task4();
					break;
				default:

					ChooseTask();
					break;
			}
		}
	}
}
