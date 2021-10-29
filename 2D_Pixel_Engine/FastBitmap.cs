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
            contents = new Bitmap(width, height, width * 4, PixelFormat.Format32bppPArgb, dataHandle.AddrOfPinnedObject());
        }

        public void SetPixel(int x, int y, Color newColour)
        {
            data[x + (y * width)] = newColour.ToArgb();
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