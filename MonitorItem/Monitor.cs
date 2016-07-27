using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorItem
{
    public class Monitor
    {
        public string Name;
        public int pixelW;
        public int pixelH;
        public decimal diagonalInch;

        public decimal diagonalPixel
        {
            get
            {
                return Convert.ToDecimal(Math.Sqrt((pixelW * pixelW) + (pixelH * pixelH)));
            }
        }

        public decimal PPI
        {
            get
            {
                decimal temp = diagonalPixel / diagonalInch;
                temp = Math.Round(temp, 2);
                return temp;
            }
        }
        
        public double Width
        {
            get { return GetWidth(); }
        }

        public double Height
        {
            get { return GetHeight(); }
        }

        public double PixelArea
        {
            get
            {
                return Math.Round(Convert.ToDouble(this.pixelH * this.pixelW), 0);
            }
        }

        private double GetWidth()
        {
            decimal pW = Convert.ToDecimal(this.pixelW);
            decimal pH = Convert.ToDecimal(this.pixelH);
            return Math.Round(Math.Sqrt(Convert.ToDouble((diagonalInch*diagonalInch)*(pW/pH)))*2.54,1);
        }

        private double GetHeight()
        {
            decimal pW = Convert.ToDecimal(this.pixelW);
            decimal pH = Convert.ToDecimal(this.pixelH);
            return Math.Round(Math.Sqrt(Convert.ToDouble((diagonalInch * diagonalInch) * (pH / pW))) * 2.54,1);
        }



        public override string ToString()
        {
            string result="";
            result = string.Format("{0} {1}x{2} {3}inch PPI:{4} Width:{5}cm Height:{6}cm Pixel Area:{7}", Name,pixelW,pixelH,diagonalInch,PPI,Width,Height,PixelArea);
            return result;
        }

        public static string GetCSVHeader()
        {
            return "Name;Pixel Width;Pixel Height;inch;PPI;Cm Width;Cm Height;Pixel Area;";
        }

        public string GetCSVString()
        {
            return string.Format("{0};{1};{2};{3};{4};{5};{6};{7};", Name, pixelW, pixelH, diagonalInch, PPI, Width, Height, PixelArea);
        }

        public Monitor(decimal DiagonalInch, int PixelW, int PixelH)
        {
            this.Name = "";
            this.diagonalInch = DiagonalInch;
            this.pixelW = PixelW;
            this.pixelH = PixelH;
        }
    }

   
}
