using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naidis
{
    public class Tringle
    {
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double h { get; set; }

        public Tringle(double A, double B, double C)
        {
            a = A;
            b = B;
            c = C;
        }

        public Tringle(double A, double B, double C, double H)
        {
            a = A;
            b = B;
            c = C;
            h = H;
        }

        public string OutputA()
        {
            return Convert.ToString(a);
        }
        public string OutputB()
        {
            return Convert.ToString(b);
        }
        public string OutputC()
        {
            return Convert.ToString(c);
        }
        public double Perimete() //периметр
        {
            double p = a + b + c;
            return p;
        }
        public double Surface() //площадь
        {
            double p = (a + b + c) / 2;
            double s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            return s;
        }
        public double Height(double side) //высота
        {
            double p = (a + b + c) / 2;
            double s = Math.Sqrt((p * (p - a) * (p - b) * (p - c)));
            double h = (2 * s) / side;
            if(side==0)
            {
                h = 0;
            }
            return h;
        }

        public double SurfaceH()
        {
            double s = 0.5 * a * h;
            return s;
        }
        public double GetSetA
        {
            get { return a; }
            set { a = value; }
        }
        public double GetSetB
        {
            get { return b; }
            set { b = value; }
        }
        public double GetSetC
        {
            get { return c; }
            set { c = value; }
        }
        public bool ExistTrinage
        {
            get
            {
                if ((a < b + c) && (b < a + c) && (c < a + b))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
