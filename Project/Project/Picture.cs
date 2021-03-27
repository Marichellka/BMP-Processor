using System;

namespace Project
{
    public class Picture
    {
        public Pixel[,] Pixels { get; set; }
        public UInt32 Width { get; }
        public UInt32 Depth { get; }

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
        public Pixel[,] Resize(Pixel[,] oldPixels)
        {
            float widthRatio = (float)(oldPixels.GetLength(1) - 1) / (Width - 1);
            float depthRatio = (float)(oldPixels.GetLength(0) - 1) / (Depth - 1);
            for (int i = 0; i < Depth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int x1 = Math.Floor(widthRatio * j);
                    int y1 = Math.Floor(depthRatio * i);
                    int x2 = Math.Ceiling(widthRatio * j);
                    int y2 = Math.Ceiling(depthRatio * i);
                    float xCost = (widthRatio * j) - x1;
                    float yCost = (depthRatio * i) - y1;
                    UInt32 a = oldPixels[y1, x1];
                    UInt32 b = oldPixels[y1, x2];
                    UInt32 c = oldPixels[y2, x1];
                    UInt32 d = oldPixels[y2, x2];
                    float pixel = a * (1 - xCost) * (1 - yCost) + b * (xCost) * (1 - yCost) + c * (1 - xCost) * (yCost) + d * xCost * yCost;
                    Pixels[i, j] = pixel;
                }
            }
            return Pixels;
        }
    }
}