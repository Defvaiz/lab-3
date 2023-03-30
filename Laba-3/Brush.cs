using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Laba_3
{
    abstract class Brush
    {
        public Color BrushColor { get; set; }
        public int Size { get; set; }
        public Brush(Color brushColor, int size)
        {
            BrushColor = brushColor;
            Size = size;
        }
        public abstract void Draw(Bitmap image, int x, int y);  
    }
    class Circle : Brush
    {
        public Circle(Color brushColor, int size) : base(brushColor, size)
        {

        }
        public override void Draw(Bitmap image, int x, int y)
        {
            for (int y0= - Size; y0 <= Size; y0++)
            {
                int x0 = Convert.ToInt32(Math.Sqrt(Math.Pow(Size, 2) - Math.Pow(y0, 2)));
                image.SetPixel(x0 + x, y0 + y, BrushColor);
                image.SetPixel(-x0 + x, y0 + y, BrushColor);
            }
            for (int x0 = -Size; x0 <= Size; x0++)
            {
                int y0 = Convert.ToInt32(Math.Sqrt(Math.Pow(Size, 2) - Math.Pow(x0, 2)));
                image.SetPixel(x0 + x, y0 + y, BrushColor);
                image.SetPixel(x0 + x, -y0 + y, BrushColor);
            }
        }
    }
    class FillCircle : Brush
    {
        public FillCircle(Color brushColor, int size) : base(brushColor, size)
        {
        }
        public override void Draw(Bitmap image, int x, int y)
        {
            for (int y0= -Size; y0 <= Size; y0++)
            {
                for (int x0= -Size; x0 <= Size; x0++)
                {
                    if ((x0*x0) + (y0*y0) <= (Size * Size))
                    {
                        image.SetPixel(x0+x, y0+y, BrushColor);
                    }
                }
            }
        }
    }
    class Rectangle : Brush
    {
        public Rectangle(Color brushColor, int size) : base(brushColor, size)
        {

        }
        public override void Draw(Bitmap image, int x, int y)
        {
            for (int y0= y -Size; y0 < y + Size; y0++)
            {
                for (int x0 = x - Size; x0 < x + Size + 10; x0++)
                {
                    image.SetPixel(x0, y0, BrushColor);
                }
            }
        }
    }
}
