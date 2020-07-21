using System;
using System.Drawing;
using System.IO;

namespace AvatarGenLib
{
	public class AvatarGenerator
	{
		public static async void GenerateSvg(string pathToSave,
		                                     int    width            = 4,
		                                     int?   height           = null,
		                                     Color? foregroundColour = null,
		                                     Color? backgroundColour = null)
		{
			// Set Stuff, need to use Nullable<T> (shorthand is T?) because default parameters must be compile-time consistent.
			foregroundColour ??= Color.FromArgb(194, 241, 255);
			backgroundColour ??= Color.FromArgb(109, 180, 213);
			height ??= width;

			var svg = string.Empty;
			
			WriteHeader(ref svg, height.GetValueOrDefault(width), width, backgroundColour.Value);
			WriteBody(ref svg, height.GetValueOrDefault(width), width, foregroundColour.Value);

			svg += "</svg>";
			
			// Boilerplate code to save files
			if (File.Exists(pathToSave)) File.Delete(pathToSave);
			Directory.CreateDirectory(Directory.GetParent(pathToSave).FullName);
			using (var sw = File.CreateText(pathToSave))
			{
				await sw.WriteAsync(svg);
				sw.Dispose();
			}
		}

		private static void WriteHeader(ref string svg, int height, int width, Color bg)
		{
			svg += "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>\n" +
					"<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\" \"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">\n" +
					
					"<svg version=\"1.1\" xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\"" +
					$" preserveAspectRatio=\"xMidYMid meet\" viewBox=\"0 0 {width} {height}\" width=\"{width}\" height=\"{height}\">\n" +
					
					$"\t<rect width=\"{width}\" height=\"{height}\" style=\"fill:rgb({bg.R}, {bg.G}, {bg.B});\"/>\n";
		}

		private static void WriteBody(ref string svg, int height, int width, Color fg)
		{
			var rand = new Random();

			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					switch (rand.Next(0, 3))
					{
						// If 0, do nothing
						case 1:
							// Filled
							svg += $"\t<rect width=\"1\" height=\"1\" x=\"{x}\" y=\"{y}\" style=\"fill:rgb({fg.R}, {fg.G}, {fg.B});\"/>\n";
							break;
						case 2:
							// Triangle!
							switch (rand.Next(0, 4))
							{
								case 0:
									// No top left
									svg += $"\t<polygon points=\"{x+1},{y} {x},{y+1} {x+1},{y+1}\" style=\"fill:rgb({fg.R}, {fg.G}, {fg.B});\"/>\n";
									break;
								case 1:
									// No top right
									svg += $"\t<polygon points=\"{x},{y+1} {x},{y} {x+1},{y+1}\" style=\"fill:rgb({fg.R}, {fg.G}, {fg.B});\"/>\n";
									break;
								case 2:
									// No bottom left
									svg += $"\t<polygon points=\"{x+1},{y} {x},{y} {x+1},{y+1}\" style=\"fill:rgb({fg.R}, {fg.G}, {fg.B});\"/>\n";
									break;
								case 3:
									// No bottom right
									svg += $"\t<polygon points=\"{x+1},{y} {x},{y+1} {x},{y}\" style=\"fill:rgb({fg.R}, {fg.G}, {fg.B});\"/>\n";
									break;
							}
							break;
					}
				}
			}
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