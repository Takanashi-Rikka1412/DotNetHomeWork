using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1_1
{
    class ConsoleCalculator
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("操作数1：");
                    string str1 = Console.ReadLine();
                    double op1 = Double.Parse(str1);

                    Console.Write("操作数2：");
                    string str2 = Console.ReadLine();
                    double op2 = Double.Parse(str2);

                    while (true)
                    {
                        Console.Write("运算符：");
                        string str = Console.ReadLine();

                        switch (str)
                        {
                            case "+": Console.WriteLine($"\n{op1} + {op2} = {op1 + op2}\n"); break;
                            case "-": Console.WriteLine($"\n{op1} - {op2} = {op1 - op2}\n"); break;
                            case "×":
                            case "*": Console.WriteLine($"\n{op1} * {op2} = {op1 * op2}\n"); break;
                            case "÷":
                            case "/":
                                if (op2 == 0 && op1 == 0)
                                    Console.WriteLine($"\n{op1} / {op2} 结果未定义\n");
                                else if (op2 == 0 && op1 != 0)
                                    Console.WriteLine($"\n{op1} / {op2} 除数不能为0\n");
                                else
                                    Console.WriteLine($"\n{op1} / {op2} = {op1 / op2}\n");
                                break;
                            default: Console.WriteLine("\n运算符输入错误，请重新输入！\n"); continue;
                        }

                        break;
                    }

                }
                catch (FormatException)   //当输入的操作数非法时
                {
                    Console.WriteLine("\n请输入合法数字！\n");
                    continue;
                }

                break;
            }
        }
    }
}
