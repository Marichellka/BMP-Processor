using System;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            BMP_File initialPicture = new BMP_File(args[0]);
            Console.Write("Enlarging image "+args[2]+" times... ");
            BMP_File resizedPicture = new BMP_File(Convert.ToDouble(args[2]), initialPicture);
            Console.WriteLine("Done.");
            resizedPicture.Writer(args[1]);
            Console.WriteLine("Written result to "+args[1] + ".");
        }
    }
}
