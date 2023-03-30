using System.Drawing.Text;

namespace Laba_3
{
    public partial class Form1 : Form
    {
        int _x;
        int _y;
        bool _mouseClicked = false;
        Color SelectedColor
        {
            get { return Color.Red; }
        }
        int SelectedSize
        {
            get { return Ïîëçóíîê.Value; }
        }
        Brush _selectedBrush;
        Color DefaultColor
        {
            get { return Color.White; }
        }
        void CreateBlank(int width, int height)
        {
            var oldImage = pictureBox1.Image;
            var bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j<height;j++ ) 
                {
                    bmp.SetPixel(i, j, DefaultColor);
                }
            }
            pictureBox1.Image = bmp;
            if (oldImage != null)
            {
                oldImage.Dispose();
            }
        }
        public Form1()
        {
            InitializeComponent();
            CreateBlank(pictureBox1.Width, pictureBox1.Height);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _selectedBrush = new QuadBrush(SelectedColor, SelectedSize);
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (_selectedBrush == null)
            {
                return;
            }
            _selectedBrush.Draw(pictureBox1.Image as Bitmap, _x, _y);
            pictureBox1.Refresh();
            _mouseClicked = true;
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseClicked = false;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            _x = e.X > 0 ? e.X : 0;
            _y = e.Y > 0 ? e.Y : 0;
            if (_mouseClicked)
            {
                try
                {
                    _selectedBrush?.Draw(pictureBox1.Image as Bitmap, _x, _y);
                }
                catch
                {

                }
                
                pictureBox1.Refresh();
            }
        
        }

        private void âûõîäToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        class ImageSizeForm
        {

        }

        private void ñîçäàòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            if (form.Canceled==false)
            {
                CreateBlank(form.W, form.H);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _selectedBrush = new Circle(SelectedColor, SelectedSize);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _selectedBrush = new FillCircle(SelectedColor, SelectedSize);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _selectedBrush = new Rectangle(SelectedColor, SelectedSize);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateBlank(1000,1000);
        }
    }
}
