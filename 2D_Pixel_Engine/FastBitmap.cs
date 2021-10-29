using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace _2D_Pixel_Engine
{
    public class FastBitmap
    {
        private readonly Bitmap contents;
        private readonly int[] data;
        private readonly int width;
        private readonly int height;

        protected GCHandle dataHandle;

        public FastBitmap(int newWidth, int newHeight)
        {
            width = newWidth;
            height = newHeight;
            data = new int[width * height];

            dataHandle = GCHandle.Alloc(data, GCHandleType.Pinned);
            contents = new Bitmap(width, height, width * 3, PixelFormat.Format24bppRgb, dataHandle.AddrOfPinnedObject());
        }

        public void SetPixel(int x, int y, byte r, byte g, byte b)
        {
            int colour = r << 16 + g << 8 + b;
            System.Diagnostics.Debug.WriteLine(Convert.ToString(colour, 16).PadLeft(6, '0'));

            data[x + (y * width)] = colour;
        }

        public Color GetPixel(int x, int y)
        {
            return Color.FromArgb(data[x + (y * width)]);
        }

        public Bitmap GetContents()
        {
            return contents;
        }
    }
}