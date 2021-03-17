using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3_1
{
    public abstract class Shape
    {
        protected double length;
        protected double width;
        public string Type { get; set; }

        public Shape(double length, double width)
        {
            this.length = length;
            this.width = width;
        }
        public abstract double Area { get; }
        public abstract bool IsValid { get; }
    }

    public class Rectangle : Shape
    {
        public Rectangle(double length, double width) : base(length, width)
        {
            Type = "Rectangle";
        }
        public override double Area
        {
            get { return length * width; }
        }
        public override bool IsValid
        {
            get { return length > 0 && width > 0; }
        }
    }

    public class Square : Shape
    {
        public Square(double length) : base(length, length)
        {
            Type = "Square";
        }
        public override double Area
        {
            get { return length * length; }
        }
        public override bool IsValid
        {
            get { return length > 0; }
        }
    }

    public class Triangle : Shape
    {
        private double width2;
        public Triangle(double length, double width, double width2) : base(length, width)
        {
            this.width2 = width2;
            Type = "Triangle";
        }
        public override double Area
        {
            get
            {
                double p = 0.5 * (length + width + width2);
                return Math.Sqrt(p * (p - length) * (p - width) * (p - width2));
            }
        }
        public override bool IsValid
        {
            get
            {
                return length > 0 && width > 0 && width2 > 0
                    && length + width > width2
                    && length + width2 > width
                    && width + width2 > length;
            }
        }
    }
    class ShapeTest
    {
        static void Main(string[] args)
        {
            Shape[] shape = new Shape[6];
            shape[0] = new Rectangle(3, 4);
            shape[1] = new Rectangle(-3, 4);
            shape[2] = new Square(3);
            shape[3] = new Square(0);
            shape[4] = new Triangle(3, 4, 5);
            shape[5] = new Triangle(3, 4, 7);

            for (int i = 0; i < shape.Length; i++)
            {
                if (shape[i].IsValid)
                    Console.WriteLine("第" + (i + 1) + "个形状合法，面积为" + shape[i].Area);
                else
                    Console.WriteLine("第" + (i + 1) + "个形状不合法");
            }
        }
    }
}
