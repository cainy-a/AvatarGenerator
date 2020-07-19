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

		private static void Interactive()
		{
		}
	}
}