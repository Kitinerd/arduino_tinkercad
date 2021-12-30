using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lr_2_ser
{

    class Draw
    {
        public string infoAnswer;

        private PictureBox pictureBox;
        private Graphics graphics;
        Pen pen;
        Brush brush;
        Point point1, point2;

        public Draw(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);

            graphics = Graphics.FromImage(pictureBox.Image);
            graphics.Clear(System.Drawing.ColorTranslator.FromHtml("#ffffff"));
        }

        private bool OnlyHexInString(string test)
        {
            if (test[0] == '#')
            {
                test = test.Remove(0, 1);
                return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
            }
            else
            {
                return false;
            }
        }

        public GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc  
            path.AddArc(arc, 180, 90);

            // top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }


        public void ExFunc(int numF, List<string> Par)
        {
            while (Par.Count < 6)
            {
                Par.Add("0");
            }


            Color _color = Color.Empty;
            DateTime date = new DateTime();
            graphics.Clear(System.Drawing.ColorTranslator.FromHtml("#ffffff"));

            switch (numF)
            {
                case 0:
                    {
                        try
                        {
                            if (OnlyHexInString(Par[0]) && Par[0].Length == 7) // 1-6 a-f A-F
                            {
                                _color = System.Drawing.ColorTranslator.FromHtml(Par[0]);
                                graphics.Clear(_color);
                                infoAnswer = "Clear";
                            }
                            else
                            {
                                infoAnswer = "@";
                            }

                        }
                        catch (Exception)
                        {
                            infoAnswer = "@";
                        }

                        break;
                    }
                case 1:
                    {

                        try
                        {
                            point1.X = Convert.ToInt32(Par[0]);
                            point1.Y = Convert.ToInt32(Par[1]);
                            if (OnlyHexInString(Par[2]) && Par[2].Length == 7)
                            {
                                _color = System.Drawing.ColorTranslator.FromHtml(Par[2]);
                                pen = new Pen(_color, 3f);

                                graphics.DrawRectangle(pen, point1.X, point1.Y, 1, 1);
                                infoAnswer = "Pixel";
                            }
                            else
                            {
                                infoAnswer = "@";
                            }

                        }
                        catch (Exception)
                        {
                            infoAnswer = "@";
                        }


                        break;
                    }
                case 2:
                    {
                        try
                        {
                            point1.X = Convert.ToInt32(Par[0]);
                            point1.Y = Convert.ToInt32(Par[1]);
                            point2.X = Convert.ToInt32(Par[2]);
                            point2.Y = Convert.ToInt32(Par[3]);
                            if (OnlyHexInString(Par[4]) && Par[4].Length == 7)
                            {
                                _color = System.Drawing.ColorTranslator.FromHtml(Par[4]);
                                pen = new Pen(_color, 3f);

                                graphics.DrawLine(pen, point1, point2);
                                infoAnswer = "Line";
                            }
                            else
                            {
                                infoAnswer = "@";
                            }

                        }
                        catch (Exception)
                        {
                            infoAnswer = "@";
                        }


                        break;
                    }
                case 3:
                    {
                        try
                        {
                            point1.X = Convert.ToInt32(Par[0]);
                            point1.Y = Convert.ToInt32(Par[1]);
                            point2.X = Convert.ToInt32(Par[2]);
                            point2.Y = Convert.ToInt32(Par[3]);
                            if (OnlyHexInString(Par[4]) && Par[4].Length == 7)
                            {
                                _color = System.Drawing.ColorTranslator.FromHtml(Par[4]);
                                pen = new Pen(_color, 3f);

                                graphics.DrawRectangle(pen, point1.X, point1.Y, point2.X, point2.Y);
                                infoAnswer = "DrawRectangle";
                            }
                            else
                            {
                                infoAnswer = "@";
                            }

                        }
                        catch (Exception)
                        {
                            infoAnswer = "@";
                        }


                        break;
                    }
                case 4:
                    {
                        try
                        {
                            point1.X = Convert.ToInt32(Par[0]);
                            point1.Y = Convert.ToInt32(Par[1]);
                            point2.X = Convert.ToInt32(Par[2]);
                            point2.Y = Convert.ToInt32(Par[3]);
                            if (OnlyHexInString(Par[4]) && Par[4].Length == 7)
                            {
                                _color = System.Drawing.ColorTranslator.FromHtml(Par[4]);
                                brush = new SolidBrush(_color);

                                graphics.FillRectangle(brush, point1.X, point1.Y, point2.X, point2.Y);
                                infoAnswer = "FillRectangle";
                            }
                            else
                            {
                                infoAnswer = "@";
                            }

                        }
                        catch (Exception)
                        {
                            infoAnswer = "@";
                        }

                        break;
                    }
                case 5:
                    {
                        try
                        {
                            point1.X = Convert.ToInt32(Par[0]);
                            point1.Y = Convert.ToInt32(Par[1]);
                            point2.X = Convert.ToInt32(Par[2]);
                            point2.Y = Convert.ToInt32(Par[3]);
                            if (OnlyHexInString(Par[4]) && Par[4].Length == 7)
                            {
                                _color = System.Drawing.ColorTranslator.FromHtml(Par[4]);
                                pen = new Pen(_color, 3f);

                                graphics.DrawEllipse(pen, point1.X, point1.Y, point2.X, point2.Y);
                                infoAnswer = "DrawEllipse";
                            }
                            else
                            {
                                infoAnswer = "@";
                            }

                        }
                        catch (Exception)
                        {
                            infoAnswer = "@";
                        }

                        break;
                    }
                case 6:
                    {
                        try
                        {
                            point1.X = Convert.ToInt32(Par[0]);
                            point1.Y = Convert.ToInt32(Par[1]);
                            point2.X = Convert.ToInt32(Par[2]);
                            point2.Y = Convert.ToInt32(Par[3]);
                            if (OnlyHexInString(Par[4]) && Par[4].Length == 7)
                            {
                                _color = System.Drawing.ColorTranslator.FromHtml(Par[4]);
                                brush = new SolidBrush(_color);

                                graphics.FillEllipse(brush, point1.X, point1.Y, point2.X, point2.Y);
                                infoAnswer = "FillEllipse";
                            }
                            else
                            {
                                infoAnswer = "@";
                            }

                        }
                        catch (Exception)
                        {
                            infoAnswer = "@";
                        }

                        break;
                    }
                case 7:
                    {
                        try
                        {
                            point1.X = Convert.ToInt32(Par[0]);
                            point1.Y = Convert.ToInt32(Par[1]);
                            point2.X = Convert.ToInt32(Par[2]);
                            if (OnlyHexInString(Par[3]) && Par[3].Length == 7)
                            {
                                _color = System.Drawing.ColorTranslator.FromHtml(Par[3]);
                                pen = new Pen(_color, 3f);

                                graphics.DrawEllipse(pen, point1.X, point1.Y, point2.X, point2.X);
                                infoAnswer = "DrawCircle";
                            }
                            else
                            {
                                infoAnswer = "@";
                            }

                        }
                        catch (Exception)
                        {
                            infoAnswer = "@";
                        }

                        break;
                    }
                case 8:
                    {
                        try
                        {
                            point1.X = Convert.ToInt32(Par[0]);
                            point1.Y = Convert.ToInt32(Par[1]);
                            point2.X = Convert.ToInt32(Par[2]);
                            if (OnlyHexInString(Par[3]) && Par[3].Length == 7)
                            {
                                _color = System.Drawing.ColorTranslator.FromHtml(Par[3]);
                                brush = new SolidBrush(_color);

                                graphics.FillEllipse(brush, point1.X, point1.Y, point2.X, point2.X);
                                infoAnswer = "FillCircle";
                            }
                            else
                            {
                                infoAnswer = "@";
                            }

                        }
                        catch (Exception)
                        {
                            infoAnswer = "@";
                        }

                        break;
                    }
                case 9:
                    {
                        try
                        {
                            point1.X = Convert.ToInt32(Par[0]);
                            point1.Y = Convert.ToInt32(Par[1]);
                            point2.X = Convert.ToInt32(Par[2]);
                            point2.Y = Convert.ToInt32(Par[3]);
                            int rad = Convert.ToInt32(Par[4]);
                            if (OnlyHexInString(Par[5]) && Par[5].Length == 7)
                            {
                                _color = System.Drawing.ColorTranslator.FromHtml(Par[5]);
                                pen = new Pen(_color, 3f);

                                graphics.DrawPath(pen, RoundedRect(new Rectangle(point1.X, point1.Y, point2.X, point2.Y), rad));
                                infoAnswer = "DrawRoundedRectangle";
                            }
                            else
                            {
                                infoAnswer = "@";
                            }

                        }
                        catch (Exception)
                        {
                            infoAnswer = "@";
                        }

                        break;
                    }
                case 10:
                    {
                        try
                        {
                            point1.X = Convert.ToInt32(Par[0]);
                            point1.Y = Convert.ToInt32(Par[1]);
                            point2.X = Convert.ToInt32(Par[2]);
                            point2.Y = Convert.ToInt32(Par[3]);
                            int rad = Convert.ToInt32(Par[4]);
                            if (OnlyHexInString(Par[5]) && Par[5].Length == 7)
                            {
                                _color = System.Drawing.ColorTranslator.FromHtml(Par[5]);
                                brush = new SolidBrush(_color);

                                graphics.FillPath(brush, RoundedRect(new Rectangle(point1.X, point1.Y, point2.X, point2.Y), rad));
                                infoAnswer = "FillRoundedRectangle";
                            }
                            else
                            {
                                infoAnswer = "@";
                            }

                        }
                        catch (Exception)
                        {
                            infoAnswer = "@";
                        }

                        break;
                    }
                case 11:
                    {
                        try
                        {
                            point1.X = Convert.ToInt32(Par[0]);
                            point1.Y = Convert.ToInt32(Par[1]);
                            string str = Par[2];
                            if (OnlyHexInString(Par[3]) && Par[3].Length == 7)
                            {
                                _color = System.Drawing.ColorTranslator.FromHtml(Par[3]);
                                brush = new SolidBrush(_color);

                                string[] typeWr = { "Arial", "Times New Roman", "Cambria", "Impact" };
                                point2.X = Convert.ToInt32(Par[4]);
                                point2.Y = Convert.ToInt32(Par[5]);

                                if (point2.X > 3 || point2.X < 0)
                                {
                                    point2.X = 1;
                                }

                                Font drawFont = new Font(typeWr[point2.X], point2.Y);
                                StringFormat drawFormat = new StringFormat();

                                graphics.DrawString(str, drawFont, brush, point1.X, point1.Y, drawFormat);
                                drawFont.Dispose();
                                brush.Dispose();
                                drawFormat.Dispose();
                                infoAnswer = "DrawText";
                            }
                            else
                            {
                                infoAnswer = "@";
                            }

                        }
                        catch (Exception)
                        {
                            infoAnswer = "@";
                        }
                        break;
                    }
                case 12:
                    {
                        try
                        {
                            point1.X = Convert.ToInt32(Par[0]);
                            point1.Y = Convert.ToInt32(Par[1]);
                            point2.X = Convert.ToInt32(Par[2]);
                            point2.Y = Convert.ToInt32(Par[3]);
                            string[] pixs = Par[4].Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                            int k = 0;

                            for (int i = point1.X; point1.X <= point2.X; point1.X++)
                            {
                                for (int j = point1.Y; j <= point2.Y; j++)
                                {
                                    if (OnlyHexInString(pixs[Math.Abs(k - pixs.Length - 1) % pixs.Length]) && pixs[Math.Abs(k - pixs.Length - 1) % pixs.Length].Length == 7)
                                    //if (OnlyHexInString(pixs[0]) && pixs[0].Length == 6)
                                    {
                                        _color = System.Drawing.ColorTranslator.FromHtml(pixs[Math.Abs(k - pixs.Length - 1) % pixs.Length]);
                                        pen = new Pen(_color, 3f);

                                        graphics.DrawRectangle(pen, j + i, i + j, 1, 1);
                                        k++;
                                        infoAnswer = "DrawImage";
                                    }
                                    else
                                    {
                                        infoAnswer = "@";
                                    }

                                }
                            }

                        }
                        catch (Exception)
                        {
                            infoAnswer = "@";
                        }

                        break;
                    }
                case 13:
                    {
                        try
                        {
                            int orr = Convert.ToInt32(Par[0]);
                            Matrix myMatrix = new Matrix();

                            switch (orr)
                            {
                                case 1:
                                    {
                                        //graphics.RotateTransform(90);
                                        myMatrix.Rotate(90, MatrixOrder.Append);
                                        graphics.Transform = myMatrix;
                                        break;
                                    }
                                case 2:
                                    {
                                        myMatrix.Rotate(180, MatrixOrder.Append);
                                        graphics.Transform = myMatrix;
                                        //graphics.RotateTransform(180);
                                        break;
                                    }
                                case 3:
                                    {
                                        myMatrix.Rotate(270, MatrixOrder.Append);
                                        graphics.Transform = myMatrix;
                                        //graphics.RotateTransform(270);
                                        break;
                                    }
                                case 4:
                                    {
                                        myMatrix.Rotate(360, MatrixOrder.Append);
                                        graphics.Transform = myMatrix;
                                        //graphics.RotateTransform(360);
                                        break;
                                    }
                                default:
                                    {
                                        break;
                                    }
                            }
                            infoAnswer = "SetOrientation";
                        }
                        catch (Exception)
                        {
                            infoAnswer = "@";
                        }

                        break;
                    }
                case 14:
                    {
                        infoAnswer = Convert.ToString(pictureBox.Width);

                        break;
                    }
                case 15:
                    {
                        infoAnswer = Convert.ToString(pictureBox.Height);
                        break;
                    }
                case 16:
                    {
                        date = DateTime.Now;
                        infoAnswer = Convert.ToString(date);

                        break;
                    }
                default:
                    {
                        break;
                    }
            }

        }


    }
}
