using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TCylinder cylinder = new TCylinder();
            TCircle circle = new TCircle();

            ChooseMenu();

            int operation = Convert.ToInt32(Console.ReadLine());
            while (operation >= 0 && operation <= 8)
            {
                switch (operation)
                {
                    case 0:
                        Console.WriteLine("GoodBye!!!");
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.WriteLine("Enter the radius: ");
                        double radius = Convert.ToDouble(Console.ReadLine());
                        circle.SetR(radius);
                        cylinder.SetR(radius);
                        Divider();
                        break;
                    case 2:
                        Console.WriteLine("Radius: " + circle.GetR());
                        Divider();
                        break;
                    case 3:
                        Console.WriteLine("Circle square: " + circle.CalculateSquare());
                        Divider();
                        break;
                    case 4:
                        Console.WriteLine("Circle length: " + circle.CalculateCircleLength());
                        Divider();
                        break;
                    case 5:
                        Console.WriteLine("Enter the height: ");
                        double height = Convert.ToDouble(Console.ReadLine());
                        cylinder.SetHeight(height);
                        Divider();
                        break;
                    case 6:
                        Console.WriteLine("Volume: " + cylinder.CalculateVolume());
                        Divider();
                        break;
                    case 7:
                        Console.WriteLine("Cylinder square: " + cylinder.CalculateSquare());
                        Divider();
                        break;
                    case 8:
                        Console.WriteLine("Enter radius of new circle:");
                        double r = Convert.ToDouble(Console.ReadLine());
                        TCircle temp = new TCircle(R: r);
                        circle.Compare(temp);
                        Divider();
                        break;
                }
                ChooseMenu();

                operation = Convert.ToInt32(Console.ReadLine());

            }
        }

        private static void ChooseMenu()
        {
            Console.WriteLine("Choose the operation:");
            Console.WriteLine("1 - set radius");
            Console.WriteLine("2 - get radius");
            Console.WriteLine("3 - get circle square");
            Console.WriteLine("4 - get circle length");
            Console.WriteLine("5 - set cylinder height");
            Console.WriteLine("6 - get cylinder volume");
            Console.WriteLine("7 - get cylinder square");
            Console.WriteLine("8 - compare circles");
            Console.WriteLine("0 - exit");
            Divider();
        }

        private static void Divider()
        {
            Console.WriteLine("-------------------------------------");
        }

        class TCircle
        {
            private double radius = 1;

            public TCircle()
            {

            }

            public TCircle(double R)
            {
                this.radius = R;
            }

            public TCircle(TCircle tCircle)
            {
                this.radius = tCircle.radius;
            }

            public void SetR(double R)
            {
                this.radius = R;
            }

            public double GetR()
            {
                return this.radius;
            }

            public virtual double CalculateSquare() => Math.PI * Math.Pow(this.radius, 2);

            public double CalculateCircleLength() => 2 * Math.PI * this.radius;

            public void Compare(TCircle circle)
            {
                if (circle.radius > this.radius)
                {
                    Console.WriteLine("The given circle is bigger");
                }
                else if (circle.radius == this.radius)
                {
                    Console.WriteLine("Circles are equal");
                }
                else
                {
                    Console.WriteLine("The given circle is smaller");
                }
            }

            public static TCircle operator -(TCircle circle1, TCircle circle2)
            {
                TCircle temp = new TCircle();
                temp.SetR(circle1.GetR() - circle2.GetR());
                return temp;
            }

            public static TCircle operator +(TCircle circle1, TCircle circle2)
            {
                TCircle temp = new TCircle();
                temp.SetR(circle1.GetR() + circle2.GetR());
                return temp;
            }

            public static TCircle operator *(double num, TCircle circle)
            {
                TCircle temp = new TCircle();

                temp.SetR(circle.radius * num);
                return temp;
            }


        }
        class TCylinder : TCircle
        {
            double height = 1;

            public void SetHeight(double height)
            {
                this.height = height;
            }

            public double CalculateVolume()
            {
                return Math.Pow(GetR(), 2) * Math.PI * height;
            }

            public override double CalculateSquare()
            {
                return 2 * Math.PI * Math.Pow(GetR(), 2) + 2 * Math.PI * GetR() * height;
            }
        }
    }
}
