using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace _2D_Pixel_Engine
{
    public partial class Window : Form
    {
        private static int width = 800;
        private static int height = 300;

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

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    display.SetPixel(i, j, Color.FromArgb(i % 255, j % 255, 0));
                }
            }


            outputPictureBox.Image = display.GetContents();
        }
    }
}
