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
            Depth = Convert.ToUInt32(matrix.GetLength(0) * zoomValue);
            Width = Convert.ToUInt32(matrix.GetLength(1) * zoomValue);
            Pixels = new Pixel[Depth, Width];
        }
        public void Resize(Pixel[,] oldPixels)
        {
            float widthRatio = (float)(oldPixels.GetLength(1) - 1) / (Width - 1);
            float depthRatio = (float)(oldPixels.GetLength(0) - 1) / (Depth - 1);
            for (int i = 0; i < Depth; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    int x1 = Convert.ToInt32(Math.Floor(widthRatio * j));
                    int y1 = Convert.ToInt32(Math.Floor(depthRatio * i));
                    int x2 = Convert.ToInt32(Math.Ceiling(widthRatio * j));
                    int y2 = Convert.ToInt32(Math.Ceiling(depthRatio * i));
                    double xCost = (widthRatio * j) - x1;
                    double yCost = (depthRatio * i) - y1;
                    Pixel firstPixel = oldPixels[y1, x1];
                    Pixel secondPixel = oldPixels[y1, x2];
                    Pixel thirdPixel = oldPixels[y2, x1];
                    Pixel fourthPixel = oldPixels[y2, x2];
                    Pixel pixel = firstPixel * ((1 - xCost) * (1 - yCost)) + thirdPixel *((1 - xCost) * (yCost))  + secondPixel * ((xCost) * (1 - yCost)) + fourthPixel * (xCost * yCost);
                    Pixels[i, j] = pixel;
                }
            }
        }
    }
}