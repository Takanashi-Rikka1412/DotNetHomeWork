using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Homework3_1;

namespace Homework3_2
{
    class ShapeFactory
    {
        private Shape shape = null;
        public Shape CreateShape(int shapeType, params double [] args)
        {
            switch(shapeType)
            {
                case 0:
                    shape = new Rectangle(args[0], args[1]);
                    break;
                case 1:
                    shape = new Square(args[0]);
                    break;
                case 2:
                    shape = new Triangle(args[0], args[1], args[2]);
                    break;
                default:
                    break;
            }
            if (!shape.IsValid)
                shape = null;

            return shape;
        }
    }


    class ShapeTest2
    {
        static void Main(string[] args)
        {
            Shape[]shape =new Shape[10];
            Random rand1 = new Random();
            Random rand2 = new Random();

            ShapeFactory factory = new ShapeFactory();
            double totalArea =0;

            for (int i=0;i<10;i++)
            {
                shape[i]=factory.CreateShape(rand1.Next(3), rand2.Next(1, 10), rand2.Next(1, 10), rand2.Next(1, 10));
                if (shape[i] != null)
                {
                    totalArea += shape[i].Area;
                    Console.WriteLine("第" + (i + 1) + "个图形为" + shape[i].Type + "，面积为" + shape[i].Area);
                }
                else
                    Console.WriteLine("第" + (i + 1) + "个图形不合法，未计入面积");
            }

            Console.WriteLine("\n总面积为" + totalArea);
            Console.WriteLine();
        }
    }
}
