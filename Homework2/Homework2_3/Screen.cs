using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//用“埃氏筛法”求2~ 100以内的素数。
//2~ 100以内的数，先去掉2的倍数，再去掉3的倍数，
//再去掉4的倍数，以此类推...最后剩下的就是素数。

namespace Homework2_3
{
    class Screen
    {
        static void Main(string[] args)
        {
            int[] state = new int[99]; 
            //用于表示2-100内的99个数的状态,0表示素数，1表示筛选掉的合数

            for(int i=2;i*i<=100;i++)
            {
                for(int j=2;i*j<=100;j++)
                {
                    state[i * j - 2] = 1;
                }
            }

            Console.WriteLine("2-100内的素数有：");
            for(int i=0;i<state.Length;i++)
            {
                if(state[i]==0)
                {
                    Console.Write(i + 2 + " ");
                }
            }
            Console.WriteLine();

        }
    }
}
