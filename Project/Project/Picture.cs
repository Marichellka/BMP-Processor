using System;

namespace Project
{
    public class Picture
    {
        public Pixel[,] Pixels { get; set; }
        public UInt32 Width { get; }
        public UInt32 Depth { get;  }

        public Picture(UInt32 w, UInt32 d)
        {
            Width = w;
            Depth = d;
        }
    }
}