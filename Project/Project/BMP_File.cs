using System;
using System.IO;

namespace Project
{
    public class BMP_File
    {
        private UInt32 filesize;
        private Picture _picture;

        BMP_File(string path)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                reader.ReadBytes(2);//BM
                filesize = reader.ReadUInt32();
                reader.ReadBytes(12);//reserved[2], headersize, infoSize
                UInt32 width = reader.ReadUInt32();
                UInt32 depth = reader.ReadUInt32();
                _picture = new Picture(width, depth);
                reader.ReadBytes(28);//other info
            }
            
        }
        
        BMP_File(string path, double numberOfTimes, BMP_File previousFile)
        {
            
        }
    }
}