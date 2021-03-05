using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//编写程序输出用户指定数据的所有素数因子

namespace Homework2_1
{
    class PrimeFactor
    {
        static void Main(string[] args)
        {
            string s;
            int num;
            Console.WriteLine("请输入一个正整数");

            while (true)
            {
                s = Console.ReadLine();
                if (Int32.TryParse(s, out num))
                    break;
                else
                    Console.WriteLine("输入错误！请重新输入！");
            }

            Console.WriteLine("该数的素数因子为：");
            for (int i = 2; i <= num; i++)
            {
                if (num % i == 0)
                {
                    Console.Write(i + " ");
                    while (num % i == 0)
                    {
                        num /= i;
                    }
                }
            }
            Console.WriteLine();

        }
    }
}
