using System;

namespace Project
{
    public class Picture
    {
        public Pixel[,] Pixels { get; set; }
        public UInt32 Width { get; }
        public UInt32 Depth { get;  }

        public Picture(UInt32 w, UInt32 d) // 1-st ctor
        {
            Width = w;
            Depth = d;
        }
        public Picture(Pixel[,] matrix, int zoomValue) // 2-nd ctor
        {
            Depth = matrix.GetLength(0) * zoomValue;
            Width = matrix.GetLength(1) * zoomValue;
            Pixels = new Pixel[Depth, Width];
        }
    }
}