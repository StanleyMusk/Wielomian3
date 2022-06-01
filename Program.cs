using System;
using System.Collections.Generic;

namespace Wiel3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj argumenty równania wielomianowego trzeciego stopnia");
            double[] tab = Array.ConvertAll<string, double>(Console.ReadLine().Split(' '), double.Parse);

            // tab[0] = a , tab[1] = b , tab[2] = c , tab[3] = d

            double w, p, q;

            w = -tab[1] / (3 * tab[0]);
            p = (3 * tab[0] * Math.Pow(w, 2) + 2*tab[1]*w + tab[2]) / tab[0];
            q = (tab[0]*Math.Pow(w,3) + tab[1]*Math.Pow(w,2) + tab[2]*w + tab[3]) / tab[0];

            double d = Delta(p, q);

            if (d > 0)
            {
                Plus(d, w, p, q); 
            }else if(d == 0)
            {
                Zero(d, w, p, q);
            }
            else
            {
                Minus(d, w, p, q);
            }

             
        }

        static double Delta(double p, double q)
        {
            return Math.Round(Math.Pow(q,2)/4,15) + Math.Round(Math.Pow(p,3)/27,15,MidpointRounding.ToEven);
        }

        static void Plus(double d, double w, double p, double q)
        {
            double u, v;
            u = -q / 2 + Math.Sqrt(d);
            v = -q / 2 - Math.Sqrt(d);

            u = u/Math.Abs(u) * Math.Pow(Math.Abs(u),1D/3);
            v = v/Math.Abs(v) * Math.Pow(Math.Abs(v),1D/3);

            string[] tab = new string[3];
            tab[0] = (u + v + w).ToString();
            tab[1] = (-(u + v)/2 + w).ToString() + " + " + (Math.Sqrt(3) / 2 * (u - v)).ToString() + "i";
            tab[2] = (-(u + v)/2 + w).ToString() + " - " + (Math.Sqrt(3) / 2 * (u - v)).ToString() + "i";

            for(int i = 1; i < 4; i++)
            {
                Console.WriteLine("x"+i+" = "+tab[i-1]);
            }
        }


        static void Minus(double d, double w, double p, double q)
        {
            double x1, x2, x3;

            double fi = Math.Acos((3*q)/(2*p*Math.Sqrt(-p/3)));

            x1 = w + 2 * Math.Sqrt(-p / 3) * Math.Cos(fi / 3);
            x2 = w + 2 * Math.Sqrt(-p / 3) * Math.Cos(fi / 3 + Math.PI*2/3);
            x3 = w + 2 * Math.Sqrt(-p / 3) * Math.Cos(fi / 3 + Math.PI * 4 / 3);

            string[] tab = new string[] {x1.ToString(),x2.ToString(), x3.ToString()};
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine("x" + (i+1) + " = " + tab[i]);
            }

        }

        static void Zero(double d, double w, double p, double q)
        {
            double x1, x2,temp;
            temp = q / Math.Abs(q) * Math.Pow(Math.Abs(q/2), 1D / 3);

            x1 = w - 2 * temp;
            x2 = w + temp;

            Console.WriteLine("x1 = "+x1.ToString());
            Console.WriteLine("x2,3 = "+x2.ToString());
        }
    }
}
