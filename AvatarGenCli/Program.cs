using System;
using System.Linq;
using System.Drawing;
using static AvatarGenLib.AvatarGenerator;

namespace AvatarGenCli
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Any(x => x.Contains("--help")))
			{
				Console.WriteLine(
				                  @"-- Avatar Generator CLI Help --
Usage: AvatarGenCli <width> <height> <path to save SVG> <(optional) foreground Red> <(opt) fg Green> <(opt) fg Blue> <(optional) background Red> <(opt) bg Green> <(opt) bg Blue>

Width & Height are NOT PIXELS, they should be somewhere around 4-16. Multiples of 4 look the nicest IMO.

If you don't have write access to the save path, this will fail.

Colours are optional, we have our own defaults.

Made by Cain Atkinson");
				return;
			}

			if (args.Length == 0)
			{
				Interactive();
				return;
			}

			StartGenerator(args);
		}

		/// <summary>
		/// Based on the length of args[], automatically calls GenerateSvg().
		/// </summary>
		/// <param name="args">command line arguments</param>
		private static void StartGenerator(string[] args)
		{
			// warning, bad code ahead
			switch (args.Length)
			{
				case 9:
					GenerateSvg(args[2], int.Parse(args[0]), int.Parse(args[1]),
					            Color.FromArgb(
					                           int.Parse(args[3]), int.Parse(args[4]), int.Parse(args[5])),
					            Color.FromArgb(
					                           int.Parse(args[6]), int.Parse(args[7]), int.Parse(args[8])));
					break;
				case 8:
				case 7:
				case 6:
					GenerateSvg(args[2], int.Parse(args[0]), int.Parse(args[1]),
					            Color.FromArgb(
					                           int.Parse(args[3]), int.Parse(args[4]), int.Parse(args[5])));
					break;
				case 5:
				case 4:
				case 3:
					GenerateSvg(args[2], int.Parse(args[0]), int.Parse(args[1]));
					break;
				default:
					Console.WriteLine("Wrong number of arguments");
					Environment.Exit(1);
					break;
			}
		}

		/// <summary>
		/// Asks the user for parameter values, and then calls GenerateSvg()
		/// </summary>
		private static void Interactive()
		{
			widthEntry:
			Console.Write("How many units wide should the avatar be? Leave blank for default of 4 ");
			var width    = 4;
			var response = Console.ReadLine().Trim();
			if (response != string.Empty)
				if (int.TryParse(response, out var _int))
				{
					width = _int;
				}
				else
				{
					Console.WriteLine("That was not a number.");
					goto widthEntry;
				}

			heightEntry:
			Console.Write("How many units tall should the avatar be? Leave blank for same as width ");
			var height = width;
			response = Console.ReadLine().Trim();
			if (response != string.Empty)
				if (int.TryParse(response, out var _int))
				{
					height = _int;
				}
				else
				{
					Console.WriteLine("That was not a number.");
					goto heightEntry;
				}

			pathEntry:
			Console.Write("Where should I save it?");
			string path;
			response = Console.ReadLine().Trim();
			if (response == string.Empty)
			{
				Console.WriteLine("You must enter a value");
				goto pathEntry;
			}
			else
				path = response;

			fgColourEntry:
			int? fgRed = null,
			     fgBlue = null,
			     fgGreen = null;
			Console.Write("What should the value of the foreground colour be? Your answer should be in RGB formatted as: \"255:255:255\". Leave blank for default.");
			response = Console.ReadLine().Trim();

			if (response != string.Empty)
			{
				var split = response.Split(':');
				if (split.Length    == 3 &&
				    split[0].Length == 3 &&
				    split[1].Length == 3 &&
				    split[2].Length == 3)
				{
					fgRed = int.Parse(split[0]);
					fgBlue = int.Parse(split[2]);
					fgGreen = int.Parse(split[1]);
				}
				else
				{
					Console.WriteLine("Incorrectly Formatted Response.");
					goto fgColourEntry;
				}
			}
			
			bgColourEntry:
			int? bgRed   = null,
			     bgBlue  = null,
			     bgGreen = null;
			Console.Write("What should the value of the background colour be? Your answer should be in RGB formatted as: \"255:255:255\". Leave blank for default.");
			response = Console.ReadLine().Trim();

			if (response != string.Empty)
			{
				var split = response.Split(':');
				if (split.Length    == 3 &&
				    split[0].Length == 3 &&
				    split[1].Length == 3 &&
				    split[2].Length == 3)
				{
					bgRed = int.Parse(split[0]);
					bgBlue = int.Parse(split[2]);
					bgGreen = int.Parse(split[1]);
				}
				else
				{
					Console.WriteLine("Incorrectly Formatted Response.");
					goto bgColourEntry;
				}
			}
			
			GenerateSvgArgb(path, width, height, fgRed, fgGreen, fgBlue, bgRed, bgGreen, bgBlue);
		}
	}
}