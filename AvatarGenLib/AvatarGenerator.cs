using System;
using System.Drawing;

namespace AvatarGenLib
{
	public class AvatarGenerator
	{
		public static void GenerateSvg(string pathToSave,
		                               int    width            = 4,
		                               int?   height           = null,
		                               Color? foregroundColour = null,
		                               Color? backgroundColour = null)
		{
			// Set Stuff, need to use Nullable<T> (shorthand is T?) because default parameters must be compile-time consistent.
			foregroundColour ??= Color.FromArgb(194, 241, 255);
			backgroundColour ??= Color.FromArgb(109, 180, 213);
			height ??= width;

			throw new NotImplementedException("I don't know how to do SVGs :(");
		}

		public static void GenerateSvgArgb(string pathToSave,
		                                   int    width   = 4,
		                                   int?   height  = null,
		                                   int?   fgRed   = null,
		                                   int?   fgGreen = null,
		                                   int?   fgBlue  = null,
		                                   int?   bgRed   = null,
		                                   int?   bgGreen = null,
		                                   int?   bgBlue  = null)
		{
			Color? fgColour = null;
			if (fgBlue  != null &&
			    fgGreen != null &&
			    fgRed   != null)
				fgColour = Color.FromArgb(fgRed.Value, fgGreen.Value, fgBlue.Value);

			Color? bgColour = null;
			if (bgBlue  != null &&
			    bgGreen != null &&
			    bgRed   != null)
				bgColour = Color.FromArgb(bgRed.Value, bgGreen.Value, bgBlue.Value);

			GenerateSvg(pathToSave, width, height, fgColour, bgColour);
		}
	}
}