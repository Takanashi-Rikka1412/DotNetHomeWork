using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//如果矩阵上每一条由左上到右下的对角线上的元素都相同，
//那么这个矩阵是托普利茨矩阵 。给定一个 M x N 的矩阵，
//当且仅当它是托普利茨矩阵时返回 True。

namespace Homework2_4
{
    class Toeplitz
    {
        static bool IsToeplitz(int[,] arr, int row, int col)
        {
            //先以第一行为基准
            for (int i = 0; i < col; i++)
            {
                for (int j = 1; j < row && i + j < col; j++)
                {
                    if (arr[0 + j, i + j] != arr[0, i])
                        return false;
                }
            }

            //再以第一列为基准
            for (int i = 0; i < row; i++)
            {
                for (int j = 1; j < col && i + j < row; j++)
                {
                    if (arr[i + j, 0 + j] != arr[i, 0])
                        return false;
                }
            }

            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个整数矩阵(每行的数用空格隔开)");
            Console.Write("行数：");
            int row = Int32.Parse(Console.ReadLine());
            Console.Write("列数：");
            int col = Int32.Parse(Console.ReadLine());

            int[,] arr = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                Console.Write("第{0}行：", i);
                string line = Console.ReadLine();
                string[] word = line.Split(' ');
                for (int j = 0; j < col; j++)
                {
                    arr[i, j] = Int32.Parse(word[j]);
                }
            }

            Console.WriteLine("\n你输入的整数矩阵为：");
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }


            if (IsToeplitz(arr, row, col))
                Console.WriteLine("\n该矩阵是一个托普利茨矩阵\n");
            else
                Console.WriteLine("\n该矩阵不是一个托普利茨矩阵\n");

        }
    }
}
