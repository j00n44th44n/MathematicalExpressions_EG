using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Evaluador;

namespace AnalisisFinal
{
    public partial class Form1 : Form
    {

        public int Size = 1000;
        public float sinceX, untilX, sinceY, untilY;
        private bool graficar;


        // Valores de n
        private List<float> a_nValues;

        private List<int> n;

        // Evaluador
        private MathParser parser = new MathParser();

        public Form1()
        {
            InitializeComponent();
            a_nValues = new List<float>();
            n = new List<int>();
            graficar = false;
        }

        // Desarrolla los valores de a_k hasta el n_i máximo, permitiendo que se ingresen desde ningún valor de n_i hasta 3.
        private void CreateA_nValues()
        {
            var temp = 0;
            bool pudo = false;
            foreach (var i in enes.Lines)
            {
                pudo = int.TryParse(i, out temp);
                if (pudo) n.Add(temp);
            }

            int max = int.MinValue;
            for (int i = 0; i < n.Count; i++)
            {
                if (n[i] > max)
                    max = n[i];
            }

            for (int i = 0; i <= max; i++)
            {
                string exp = input.Text.Replace("n", "" + i);
                a_nValues.Add((float)parser.Parse(exp));
            }
        }

        // Registra en una lista los puntos de cada curva según la n y el tipo de función.
        private List<PointF> PointsOfCurve(int sup, string type)
        {
            List<PointF> pointsOfCurve = new List<PointF>();
            float x1 = float.Parse(tbSinceX.Text);
            float x2 = float.Parse(tbUntilX.Text);
            float dx = (x2 - x1) / Size;
            float sum = 0;
            PointF point;
            if (type == "function")
            {
                for (float i = x1; i <= x2; i += dx)
                {
                    for (int j = 0; j <= sup; j++)
                        sum += a_nValues[j] * (float)Math.Pow(i, j);
                    point = XAndYToGraphicPoint(i, sum, "Serie");
                    if (point.Y >= -1500 && point.Y <= 1500)
                        pointsOfCurve.Add(point);
                    sum = 0;
                }
            }
            if (type == "derivate")
            {
                for (float i = x1; i <= x2; i += dx)
                {
                    for (int j = 0; j <= sup; j++)
                        sum += a_nValues[j] * j * (float)Math.Pow(i, j - 1);
                    point = XAndYToGraphicPoint(i, sum, "Derivada");
                    if (point.Y >= -1500 && point.Y <= 1500)
                        pointsOfCurve.Add(point);
                    sum = 0;
                }
            }
            if (type == "integral")
            {
                for (float i = x1; i <= x2; i += dx)
                {
                    for (int j = 0; j <= sup; j++)
                        sum += a_nValues[j] * (float)Math.Pow(i, j + 1) / (j + 1);
                    point = XAndYToGraphicPoint(i, sum, "Integral");
                    if (point.Y >= -1500 && point.Y <= 1500)
                        pointsOfCurve.Add(point);
                    sum = 0;
                }
            }
            return pointsOfCurve;
        }

        // Ajusta la escala que representan las coordenadas que se pasan como parámetros a las dimensiones en píxeles del gráfico.
        private PointF XAndYToGraphicPoint(float x, float y, string Name)
        {
            float l1, l2, l3, l4, a1, a2, a3, a4;
            a1 = pbSerie.Width;
            l1 = pbSerie.Height;
            a2 = pbDerivada.Width;
            l2 = pbDerivada.Height;
            a3 = pbIntegral.Width;
            l3 = pbIntegral.Height;
            a4 = pbGrafico.Width;
            l4 = pbGrafico.Height;

            float x1 = float.Parse(tbSinceX.Text);
            float y2 = float.Parse(tbUntilY.Text);
            float dx = float.Parse(tbUntilX.Text) - x1;
            float dy = y2 - float.Parse(tbSinceY.Text);
            float relationPixelsPerDx = 0; // width
            float relationPixelsPerDy = 0; // heigth
            switch (Name)
            {
                case "Serie":
                    {
                        relationPixelsPerDx = a1 / dx; // width
                        relationPixelsPerDy = l1 / dy; // heigth
                    }
                    break;
                case "Derivada":
                    {
                        relationPixelsPerDx = a2 / dx; // width
                        relationPixelsPerDy = l2 / dy; // heigth
                    }
                    break;
                case "Integral":
                    {
                        relationPixelsPerDx = a3 / dx; // width
                        relationPixelsPerDy = l3 / dy; // heigth
                    }
                    break;
                case "Grafico":
                    {
                        relationPixelsPerDx = a4 / dx; // width
                        relationPixelsPerDy = l4 / dy; // heigth
                    }
                    break;
            }
            return new PointF((x - x1) * relationPixelsPerDx, (y2 - y) * relationPixelsPerDy);
        }

        private void Done_Click(object sender, EventArgs e)
        {
            graficar = true;
            a_nValues.Clear();
            CreateA_nValues();
            pbSerie.Refresh();
            pbDerivada.Refresh();
            pbIntegral.Refresh();

            #region Agregado       
            pbDerivada.BackgroundImage = null;
            pbSerie.BackgroundImage = null;
            pbIntegral.BackgroundImage = null;
            #endregion

        }

        private void pbSerie_Paint(object sender, PaintEventArgs e)
        {
            if (graficar)
            {
                var g = e.Graphics;
                pbSerie.BackColor = Color.White;
                float ancho = pbSerie.Width;
                float largo = pbSerie.Height;
                untilX = float.Parse(tbUntilX.Text);
                untilY = float.Parse(tbUntilY.Text);
                sinceX = float.Parse(tbSinceX.Text);
                sinceY = float.Parse(tbSinceY.Text);
                #region Agregado
                float copiaSinceX = float.Parse(tbSinceX.Text);
                float copiaUntilY = float.Parse(tbUntilY.Text);
                #endregion
                float escalaAncho = ancho / (untilX - sinceX);
                float escalaLargo = largo / (untilY - sinceY);

                //#region Agregado
                //bool pintarX = false;
                //bool pintarY = false;
                //if (sinceX < 0 && untilX > 0)
                //    pintarX = true;
                //if (sinceY < 0 && sinceY > 0)
                //    pintarY = true;
                //#endregion      

                #region Modificado
                for (float i = 0; i < ancho; i += escalaAncho)
                {
                    if (copiaSinceX == 0)
                    {
                        g.DrawLine(Pens.Gray, new PointF(i, 0), new PointF(i, largo));
                    }
                    else
                    {
                        for (int j = 0; j < largo; j += 20)
                        {
                            g.DrawLine(Pens.Gray, new PointF(i, j), new PointF(i, j + 5));
                        }
                    }
                    copiaSinceX++;
                }
                //  ----->  largo
                for (float i = 0; i < largo; i += escalaLargo)
                {
                    if (copiaUntilY == 0)
                    {
                        g.DrawLine(Pens.Gray, new PointF(0, i), new PointF(ancho, i));
                    }
                    else
                    {
                        for (int j = 0; j < ancho; j += 20)
                        {
                            g.DrawLine(Pens.Gray, new PointF(j, i), new PointF(j + 5, i));
                        }
                    }
                    copiaUntilY--;
                }
                #endregion

                for (int i = 0; i < n.Count; i++)
                {
                    switch (i % 10)
                    {
                        case 0:
                            e.Graphics.DrawCurve(Pens.Red, PointsOfCurve(n[i], "function").ToArray());
                            break;
                        case 1:
                            e.Graphics.DrawCurve(Pens.Green, PointsOfCurve(n[i], "function").ToArray());
                            break;
                        case 2:
                            e.Graphics.DrawCurve(Pens.Blue, PointsOfCurve(n[i], "function").ToArray());
                            break;
                        case 3:
                            e.Graphics.DrawCurve(Pens.Yellow, PointsOfCurve(n[i], "function").ToArray());
                            break;
                        case 4:
                            e.Graphics.DrawCurve(Pens.Violet, PointsOfCurve(n[i], "function").ToArray());
                            break;
                        case 5:
                            e.Graphics.DrawCurve(Pens.Lime, PointsOfCurve(n[i], "function").ToArray());
                            break;
                        case 6:
                            e.Graphics.DrawCurve(Pens.Maroon, PointsOfCurve(n[i], "function").ToArray());
                            break;
                        case 7:
                            e.Graphics.DrawCurve(Pens.DarkOrange, PointsOfCurve(n[i], "function").ToArray());
                            break;
                        case 8:
                            e.Graphics.DrawCurve(Pens.DeepPink, PointsOfCurve(n[i], "function").ToArray());
                            break;
                        case 9:
                            e.Graphics.DrawCurve(Pens.MediumTurquoise, PointsOfCurve(n[i], "function").ToArray());
                            break;
                    }
                }
            }
        }

        private void pbDerivada_Paint(object sender, PaintEventArgs e)
        {
            if (graficar)
            {
                var g = e.Graphics;
                pbDerivada.BackColor = Color.White;
                float ancho = pbDerivada.Width;
                float largo = pbDerivada.Height;
                untilX = float.Parse(tbUntilX.Text);
                untilY = float.Parse(tbUntilY.Text);
                sinceX = float.Parse(tbSinceX.Text);
                sinceY = float.Parse(tbSinceY.Text);

                #region Agregado
                float copiaSinceX = float.Parse(tbSinceX.Text);
                float copiaUntilY = float.Parse(tbUntilY.Text);
                #endregion

                float escalaAncho = ancho / (untilX - sinceX);
                float escalaLargo = largo / (untilY - sinceY);

                #region Modificado
                for (float i = 0; i < ancho; i += escalaAncho)
                {
                    if (copiaSinceX == 0)
                    {
                        g.DrawLine(Pens.Gray, new PointF(i, 0), new PointF(i, largo));
                    }
                    else
                    {
                        for (int j = 0; j < largo; j += 20)
                        {
                            g.DrawLine(Pens.Gray, new PointF(i, j), new PointF(i, j + 5));
                        }
                    }
                    copiaSinceX++;
                }
                //  ----->  largo
                for (float i = 0; i < largo; i += escalaLargo)
                {
                    if (copiaUntilY == 0)
                    {
                        g.DrawLine(Pens.Gray, new PointF(0, i), new PointF(ancho, i));
                    }
                    else
                    {
                        for (int j = 0; j < ancho; j += 20)
                        {
                            g.DrawLine(Pens.Gray, new PointF(j, i), new PointF(j + 5, i));
                        }
                    }
                    copiaUntilY--;
                }
                #endregion

                for (int i = 0; i < n.Count; i++)
                {
                    switch (i % 10)
                    {
                        case 0:
                            e.Graphics.DrawCurve(Pens.Red, PointsOfCurve(n[i], "derivate").ToArray());
                            break;
                        case 1:
                            e.Graphics.DrawCurve(Pens.Green, PointsOfCurve(n[i], "derivate").ToArray());
                            break;
                        case 2:
                            e.Graphics.DrawCurve(Pens.Blue, PointsOfCurve(n[i], "derivate").ToArray());
                            break;
                        case 3:
                            e.Graphics.DrawCurve(Pens.Yellow, PointsOfCurve(n[i], "derivate").ToArray());
                            break;
                        case 4:
                            e.Graphics.DrawCurve(Pens.Violet, PointsOfCurve(n[i], "derivate").ToArray());
                            break;
                        case 5:
                            e.Graphics.DrawCurve(Pens.Lime, PointsOfCurve(n[i], "derivate").ToArray());
                            break;
                        case 6:
                            e.Graphics.DrawCurve(Pens.Maroon, PointsOfCurve(n[i], "derivate").ToArray());
                            break;
                        case 7:
                            e.Graphics.DrawCurve(Pens.DarkOrange, PointsOfCurve(n[i], "derivate").ToArray());
                            break;
                        case 8:
                            e.Graphics.DrawCurve(Pens.DeepPink, PointsOfCurve(n[i], "derivate").ToArray());
                            break;
                        case 9:
                            e.Graphics.DrawCurve(Pens.MediumTurquoise, PointsOfCurve(n[i], "derivate").ToArray());
                            break;
                    }
                }
            }
        }

        private void pbIntegral_Paint(object sender, PaintEventArgs e)
        {
            if (graficar)
            {
                var g = e.Graphics;
                pbIntegral.BackColor = Color.White;
                float ancho = pbIntegral.Width;
                float largo = pbIntegral.Height;
                untilX = float.Parse(tbUntilX.Text);
                untilY = float.Parse(tbUntilY.Text);
                sinceX = float.Parse(tbSinceX.Text);
                sinceY = float.Parse(tbSinceY.Text);

                #region Agregado
                float copiaSinceX = float.Parse(tbSinceX.Text);
                float copiaUntilY = float.Parse(tbUntilY.Text);
                #endregion

                float escalaAncho = ancho / (untilX - sinceX);
                float escalaLargo = largo / (untilY - sinceY);

                #region Modificado
                for (float i = 0; i < ancho; i += escalaAncho)
                {
                    if (copiaSinceX == 0)
                    {
                        g.DrawLine(Pens.Gray, new PointF(i, 0), new PointF(i, largo));
                    }
                    else
                    {
                        for (int j = 0; j < largo; j += 20)
                        {
                            g.DrawLine(Pens.Gray, new PointF(i, j), new PointF(i, j + 5));
                        }
                    }
                    copiaSinceX++;
                }
                //  ----->  largo
                for (float i = 0; i < largo; i += escalaLargo)
                {
                    if (copiaUntilY == 0)
                    {
                        g.DrawLine(Pens.Gray, new PointF(0, i), new PointF(ancho, i));
                    }
                    else
                    {
                        for (int j = 0; j < ancho; j += 20)
                        {
                            g.DrawLine(Pens.Gray, new PointF(j, i), new PointF(j + 5, i));
                        }
                    }
                    copiaUntilY--;
                }
                #endregion

                for (int i = 0; i < n.Count; i++)
                {
                    switch (i % 10)
                    {
                        case 0:
                            e.Graphics.DrawCurve(Pens.Red, PointsOfCurve(n[i], "integral").ToArray());
                            break;
                        case 1:
                            e.Graphics.DrawCurve(Pens.Green, PointsOfCurve(n[i], "integral").ToArray());
                            break;
                        case 2:
                            e.Graphics.DrawCurve(Pens.Blue, PointsOfCurve(n[i], "integral").ToArray());
                            break;
                        case 3:
                            e.Graphics.DrawCurve(Pens.Yellow, PointsOfCurve(n[i], "integral").ToArray());
                            break;
                        case 4:
                            e.Graphics.DrawCurve(Pens.Violet, PointsOfCurve(n[i], "integral").ToArray());
                            break;
                        case 5:
                            e.Graphics.DrawCurve(Pens.Lime, PointsOfCurve(n[i], "integral").ToArray());
                            break;
                        case 6:
                            e.Graphics.DrawCurve(Pens.Maroon, PointsOfCurve(n[i], "integral").ToArray());
                            break;
                        case 7:
                            e.Graphics.DrawCurve(Pens.DarkOrange, PointsOfCurve(n[i], "integral").ToArray());
                            break;
                        case 8:
                            e.Graphics.DrawCurve(Pens.DeepPink, PointsOfCurve(n[i], "integral").ToArray());
                            break;
                        case 9:
                            e.Graphics.DrawCurve(Pens.MediumTurquoise, PointsOfCurve(n[i], "integral").ToArray());
                            break;
                    }
                }
            }
        }

        private void pbGrafico_Paint(object sender, PaintEventArgs e)
        {

        }

        private void restart_Click(object sender, EventArgs e)
        {

        }

        private void ayuda_Click(object sender, EventArgs e)
        {

        }

        #region Pacotilla Visual

        private void pbDerivada_MouseEnter(object sender, EventArgs e)
        {
            if (!graficar)
            {
                this.pbDerivada.BackgroundImage = new Bitmap(@"derivadaConTile.jpg");
                pbDerivada.Height -= 1;
            }
        }

        private void pbDerivada_MouseLeave(object sender, EventArgs e)
        {
            if (!graficar)
            {
                this.pbDerivada.BackgroundImage = new Bitmap(@"derivadaSinTile.jpg");
                pbDerivada.Height += 1;
            }
        }

        private void pbSerie_MouseEnter(object sender, EventArgs e)
        {
            if (!graficar)
                this.pbSerie.BackgroundImage = new Bitmap(@"serieConTile.jpg");
        }

        private void pbSerie_MouseLeave(object sender, EventArgs e)
        {
            if (!graficar)
                this.pbSerie.BackgroundImage = new Bitmap(@"serieSinTile.jpg");
        }

        private void pbIntegral_MouseEnter(object sender, EventArgs e)
        {
            if (!graficar)
            {
                this.pbIntegral.BackgroundImage = new Bitmap(@"integralConTile.jpg");
                pbIntegral.Width -= 4;
            }
        }

        private void pbIntegral_MouseLeave(object sender, EventArgs e)
        {
            if (!graficar)
            {
                this.pbIntegral.BackgroundImage = new Bitmap(@"integralSinTile.jpg");
                pbIntegral.Width += 4;
            }

        }

        private void pbGrafico_MouseEnter(object sender, EventArgs e)
        {
            if (!graficar)
            {
                this.pbGrafico.BackgroundImage = new Bitmap(@"graficoConTile.jpg");
                pbGrafico.Height -= 1;
            }
        }

        private void pbGrafico_MouseLeave(object sender, EventArgs e)
        {
            if (!graficar)
            {
                this.pbGrafico.BackgroundImage = new Bitmap(@"graficoSinTile.jpg");
                pbGrafico.Height += 1;
            }
        }

        private void Done_MouseEnter(object sender, EventArgs e)
        {
            Hecho.ForeColor = Color.LimeGreen;
            Hecho.BackColor = Color.DarkSlateGray;
        }

        private void Done_MouseLeave(object sender, EventArgs e)
        {
            Hecho.ForeColor = Color.White;
            Hecho.BackColor = Color.Black;
        }

        private void Settings_MouseEnter(object sender, EventArgs e)
        {
            Ayuda.ForeColor = Color.LimeGreen;
            Ayuda.BackColor = Color.DarkSlateGray;
        }

        private void Settings_MouseLeave(object sender, EventArgs e)
        {
            Ayuda.ForeColor = Color.White;
            Ayuda.BackColor = Color.Black;
        }

        private void Help_MouseEnter(object sender, EventArgs e)
        {
            Reiniciar.ForeColor = Color.LimeGreen;
            Reiniciar.BackColor = Color.DarkSlateGray;
        }

        private void Help_MouseLeave(object sender, EventArgs e)
        {
            Reiniciar.ForeColor = Color.White;
            Reiniciar.BackColor = Color.Black;
        }
        #endregion

        private void Ayuda_MouseEnter(object sender, EventArgs e)
        {
            this.Ayuda.BackgroundImage = new Bitmap(@"helpEnter.jpg");
        }

        private void Ayuda_MouseLeave(object sender, EventArgs e)
        {
            this.Ayuda.BackgroundImage = new Bitmap(@"helpLeave.jpg");
        }

        private void Reiniciar_MouseEnter(object sender, EventArgs e)
        {
            this.Reiniciar.BackgroundImage = new Bitmap(@"restartEnter.jpg");
        }

        private void Reiniciar_MouseLeave(object sender, EventArgs e)
        {
            this.Reiniciar.BackgroundImage = new Bitmap(@"restartLeave.jpg");
        }

        private void Hecho_MouseEnter(object sender, EventArgs e)
        {
            this.Hecho.BackgroundImage = new Bitmap(@"doneEnter.jpg");
        }

        private void Hecho_MouseLeave(object sender, EventArgs e)
        {
            this.Hecho.BackgroundImage = new Bitmap(@"doneLeave.jpg");
        }
    }
}
