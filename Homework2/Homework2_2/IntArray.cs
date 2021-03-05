using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//编程求一个整数数组的最大值、最小值、平均值和所有数组元素的和。

namespace Homework2_2
{
    class IntArray
    {
        static void Main(string[] args)
        {
            int[] a = { 4, 7, 12, 9, 10 };
            int max = a[0], min = a[0];
            double sum = 0;

            Console.Write("数组");
            for (int i=0;i<a.Length;i++)
            {
                Console.Write(a[i] + ", ");
                if (a[i] > max)
                    max = a[i];
                if (a[i] < min)
                    min = a[i];
                sum += a[i];
            }
            double ave = sum / a.Length;

            Console.WriteLine("\n最大值为" + max);
            Console.WriteLine("最小值为" + min);
            Console.WriteLine("平均值为" + ave);
            Console.WriteLine("和为" + sum);
        }
    }
}
