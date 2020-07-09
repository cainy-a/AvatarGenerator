using System;
using System.Drawing;

namespace AvatarGenLib
{
    public class AvatarGenerator
    {
        public static void GenerateSvg(string pathToSave, int width = 4, int? height = null, Color? foregroundColour = null, Color? backgroundColour = null)
        {
            // Set Stuff, need to use Nullable<T> because default parameters must be compile-time consistent.
            if (!foregroundColour.HasValue) foregroundColour = Color.FromArgb(194, 241, 255);
            if (!backgroundColour.HasValue) backgroundColour = Color.FromArgb(109, 180, 213);
            if (!height.HasValue) height = width;

            throw new NotImplementedException("I don't know how to do SVGs :(");
        }
    }
}
