using System;

namespace Project
{
    public class Pixel
    {
        public Byte Red { get; }
        public Byte Green { get; }
        public Byte Blue { get; }

        public Pixel(Byte red, Byte green, Byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}