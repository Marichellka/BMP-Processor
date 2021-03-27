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
        public static Pixel operator *(Pixel item, double number)
        {
            byte nb = Convert.ToByte(number);
            byte red = Convert.ToByte(item.Red);
            byte green = Convert.ToByte(item.Green);
            byte blue = Convert.ToByte(item.Blue);
            return new Pixel((byte)(red * nb), (byte)(green * nb), (byte)(blue * nb));
        }
        public static Pixel operator +(Pixel item1, Pixel item2) => new Pixel((byte) (item1.Red + item2.Red), (byte) (item1.Green + item2.Green), (byte) (item1.Blue + item2.Blue));
    }
}