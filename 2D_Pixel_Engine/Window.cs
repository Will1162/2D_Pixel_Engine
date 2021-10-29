using System.Drawing;
using System.Windows.Forms;

namespace _2D_Pixel_Engine
{
    public partial class Window : Form
    {
        private static readonly int width = 320;
        private static readonly int height = 288;

        public Window()
        {
            InitializeComponent();

            FastBitmap display = new FastBitmap(width, height);
            outputPictureBox.Width = width;
            outputPictureBox.Height = height;

            this.Width = width;
            this.Width = width + (width - ClientRectangle.Width);
            this.Height = height;
            this.Height = height + (height - ClientRectangle.Height);




            display.SetPixel(10, 10, 0x16, 0xd5, 0xd1);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    //display.SetPixel(i, j, 255, 128, 0);
                }
            }

            outputPictureBox.Image = display.GetContents();
        }
    }
}
