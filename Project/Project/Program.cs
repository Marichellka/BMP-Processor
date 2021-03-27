using System;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            BMP_File initialPicture = new BMP_File(args[0]);
            BMP_File resizedPicture = new BMP_File(Convert.ToDouble(args[2]), initialPicture);
            resizedPicture.Writer(args[1]);
        }
    }
}