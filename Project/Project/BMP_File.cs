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
                CreatePicture(reader);
            }
            
        }

        private void CreatePicture(BinaryReader br)
        {
            _picture.Pixels = new Pixel[_picture.Width, _picture.Depth];
            for (int i = 0; i < _picture.Width; i++)
            {
                for (int j = 0; j < _picture.Depth; j++)
                {
                    _picture.Pixels[i, j] = new Pixel(br.ReadByte(), br.ReadByte(), br.ReadByte());
                }
            }
        }

        BMP_File(string path, double numberOfTimes, BMP_File previousFile)
        {
            
        }
    }
}