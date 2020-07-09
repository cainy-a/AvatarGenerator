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

        static void StartGenerator(string[] args)
        {
            // warning, bad code ahead

        }

        static void Interactive()
        {

        }
    }
}
