using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Project
{
    public class BMP_File
    {
        private UInt32 filesize;
        private Picture _picture;
        private List<Byte> headerInfo;

        public BMP_File(string path)
        {
            headerInfo = new List<byte>();
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                reader.ReadBytes(2);//BM
                filesize = reader.ReadUInt32();
                headerInfo.AddRange(reader.ReadBytes(12));//reserved[2], headersize, infoSize
                UInt32 width = reader.ReadUInt32();
                UInt32 depth = reader.ReadUInt32();
                _picture = new Picture(width, depth);
                headerInfo.AddRange(reader.ReadBytes(28));//other info
                CreatePicture(reader);
            }
            
        }

        private void CreatePicture(BinaryReader br)
        {
            _picture.Pixels = new Pixel[_picture.Depth, _picture.Width];
<<<<<<< HEAD
            int countOfIgnoreBits = 4-Convert.ToInt32(_picture.Width)*3%4;
=======
            int countOfIgnoreBits = Convert.ToInt32(_picture.Width)%4;
>>>>>>> BMP_File
            for (int i = 0; i < _picture.Depth; i++)
            {
                for (int j = 0; j < _picture.Width; j++)
                {
                    _picture.Pixels[i, j] = new Pixel(br.ReadByte(), br.ReadByte(), br.ReadByte());
                }
                br.ReadBytes(countOfIgnoreBits);
            }
        }

        public BMP_File(int numberOfTimes, BMP_File previousFile)
        {
            headerInfo = previousFile.headerInfo;
            _picture = new Picture(previousFile._picture.Pixels, numberOfTimes);
            filesize = Convert.ToUInt32(previousFile.filesize * numberOfTimes);
        }

        public void Writer(string path)
        {
<<<<<<< HEAD
            int countOfZeroBits = 4-Convert.ToInt32(_picture.Width)*3%4;
=======
            int countOfZeroBits = Convert.ToInt32(_picture.Width)%4;
>>>>>>> BMP_File
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                writer.Write('B');
                writer.Write('M');
                writer.Write(filesize);
                for (int i = 0; i < 12; i++) //reserved[2], headersize, infoSize
                {
                    writer.Write(headerInfo[i]);
                }
                writer.Write(_picture.Width);
                writer.Write(_picture.Depth);
                for (int i = 12; i < headerInfo.Count; i++) //other info
                {
                    writer.Write(headerInfo[i]);
                }
                for (int i = 0; i < _picture.Depth; i++)
                {
                    for (int j = 0; j < _picture.Width; j++)
                    {
                        writer.Write(_picture.Pixels[i,j].Red);
                        writer.Write(_picture.Pixels[i,j].Green);
                        writer.Write(_picture.Pixels[i,j].Blue);
                    }
                    for (int j = 0; j < countOfZeroBits; j++)
                    {
                        writer.Write(Convert.ToByte(0));
                    }
                }
            }
        }
    }
}