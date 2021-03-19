using System;
using System.IO;

namespace Project
{
    public class BMP_File
    {
        private UInt32 filesize;
        private UInt32 width;
        private UInt32 depth;

        BMP_File(string path)
        {
            using (StreamReader streamReader = new StreamReader(path))
            {
                Reader(streamReader, 2);//BM
                filesize = UInt32.Parse(Reader(streamReader, 4));
                Reader(streamReader, 12);//reserved[2], headersize, infoSize
                width = UInt32.Parse(Reader(streamReader, 4));
                depth = UInt32.Parse(Reader(streamReader, 4));
                Reader(streamReader, 28);//other info
            }
        }

        private string Reader(StreamReader sr, int numberOfBites)
        {
            string info = "";
            while (numberOfBites!=0)
            {
                info += sr.Read();
            }
            return info;
        }

        BMP_File(string path, double numberOfTimes){}
    }
}