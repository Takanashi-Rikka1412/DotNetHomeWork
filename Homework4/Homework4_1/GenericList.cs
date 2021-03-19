using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4_1
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public GenericList()
        {
            Tail = Head = null;
        }
        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (Tail == null)
            {
                Tail = Head = n;
            }
            else
            {
                Tail.Next = n;
                Tail = n;
            }
        }
        public void ForEach(Action<T> action)
        {
            Node<T> node = Head;
            while (node != null)
            {
                action(node.Data);
                node = node.Next;
            }
        }

    }

    public class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>();
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                list.Add(rand.Next(100));
            }

            Console.WriteLine("链表中元素有：");
            list.ForEach(x => Console.Write(x + "\t"));

            int max = list.Head.Data, min = list.Head.Data, sum = 0;
            list.ForEach(x => { if (x > max) max = x; });
            list.ForEach(x => { if (x < min) min = x; });
            list.ForEach(x => sum += x);
            Console.WriteLine("\n最大值为：" + max);
            Console.WriteLine("最小值为：" + min);
            Console.WriteLine("和为" + sum);
        }
    }
}
