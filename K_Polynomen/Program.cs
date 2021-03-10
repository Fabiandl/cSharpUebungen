using System;
using System.Data;

namespace Polynomen12
{
    public class Test
    {
        public static void Main(string[] args)
        {
            Polynom pol = new Polynom(new double[4]);
        }
    }
    
    public class Polynom
    {

        private int degree;
        private double[] koeefizienten;

        public Polynom(double[] koeffs)
        {
            this.koeefizienten = koeffs;
            degree = koeffs.Length - 1;
        }

        public int Degree => degree;
        
        public double[] Koeefizienten => koeefizienten;

        public double eval(double x)
        {
            double res = 0;
           for (int i = 0; i < koeefizienten.Length-1; i++)
            {
                double potenz = Convert.ToDouble(degree);
                res += koeefizienten[i] * Math.Pow(x,potenz);
                degree--;
            }
           res += koeefizienten[koeefizienten.Length - 1];
           return res;
        }
        
        public bool IsZero()
        {
            return (Degree == 1) && (Math.Abs(koeefizienten[0]) < 1e-15);
        }
            
        public override String ToString()
        {
            return string.Format($"pol {Degree} [{string.Join(", ", koeefizienten)}].");
        }
        
    }
}