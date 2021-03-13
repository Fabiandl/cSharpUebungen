using System;
using System.Runtime.CompilerServices;

namespace L_OperatorUeberladung
{
    public class Komplex : IComparable
    {

        public static void Main(string[] args)
        {
            Komplex k1 = new Komplex(1, 2);
            Komplex k2 = new Komplex(1, 0);

            k1 += k2;
            k1 -= k2;
            k1 *= k2;
            k1 /= k2;
            var komplex = k1 + k2;
            komplex = k1 - k2;
            komplex = k1 * k2;
            komplex = k1 / k2;

            var d = komplex[0];
        }
        private double img, real;

        public Komplex(double real, double img)
        {
            this.img = img;
            this.real = real;
        }

        public Komplex(double real)
        {
            this.real = real;
            this.img = 0;
        }

        public double Img => img;

        public double Real => real;

        public static Komplex operator +(Komplex k1, Komplex k2)
        {
            return new Komplex(k1.real + k2.real, k1.img + k2.img);
        }

        public static Komplex operator -(Komplex k1, Komplex k2)
        {
            return k1 + (-1 * k2);
        }

        public static Komplex operator *(Komplex k1, Komplex k2)
        {
            return new Komplex((k1.real * k2.real - k1.img * k2.img), (k1.real * k2.img + k2.real * k1.img));
        }
        
        public static Komplex operator *(Komplex k1, double d)
        {
            return new Komplex(k1.real * d, k1.img * d);
        }
        
        public static Komplex operator *(double d, Komplex k1)
        {
            return k1 * d;
        }
        
        public static Komplex operator /(Komplex k1, Komplex k2)
        {
            return new Komplex((k1.real * k2.real + k1.img * k2.img) / (k2.real * k2.real + k2.img * k2.img), 
                               (k1.img*k2.real - k1.real*k2.img)/(k2.real * k2.real + k2.img * k2.img));
        }

        public static bool operator ==(Komplex k1, Komplex k2)
        {
            return (k1.real == k2.real && k1.img == k2.img);
        }

        public static bool operator !=(Komplex k1, Komplex k2)
        {
            return !(k1 == k2);
        }

        public double this[int index]
        {
            get { return index == 0 ? real : img; }
            set
            {
                if (index == 0)
                {
                    real = value;
                }
                else
                {
                    img = value;
                }
            }
        }

        public override string ToString()
        {
            if (this.img > 0)
            {
                return $"{real} + i{img}";
            }
            else if (this.img == 0)
            {
                return $"{real}";
            }
            else
            {
                return $"{real} - i{-1*img}";
            }
        }

        public int CompareTo(object obj)
        {
            Komplex k1 = obj as Komplex;
            return (this == k1) ? 0 : 1;
        }
    }
}