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
            Byte red, green, blue;
            if (item.Red * number > Byte.MaxValue)
            {
                red=Byte.MaxValue;
            }
            else
            {
                red = Convert.ToByte(item.Red*number);
            }
            if (item.Green * number > Byte.MaxValue)
            {
                green=Byte.MaxValue;
            }
            else
            {
                green = Convert.ToByte(item.Green*number);
            }
            if (item.Blue * number > Byte.MaxValue)
            {
                blue=Byte.MaxValue;
            }
            else
            {
                blue = Convert.ToByte(item.Blue*number);
            }
            return new Pixel(red, green, blue);
        }

        public static Pixel operator +(Pixel item1, Pixel item2)
        {
            Byte red, green, blue;
            if (item1.Red + item2.Red > Byte.MaxValue)
            {
                red=Byte.MaxValue;
            }
            else
            {
                red = Convert.ToByte(item1.Red+item2.Red);
            }

            if (item1.Green + item2.Green > Byte.MaxValue)
            {
                green=Byte.MaxValue;
            }
            else
            {
                green = Convert.ToByte(item1.Green+item2.Green);
            }

            if (item1.Blue + item2.Blue > Byte.MaxValue)
            {
                blue=Byte.MaxValue;
            }
            else
            {
                blue = Convert.ToByte(item1.Blue+item2.Blue);
            }
            return new Pixel(red, green, blue);
        }
    }
}