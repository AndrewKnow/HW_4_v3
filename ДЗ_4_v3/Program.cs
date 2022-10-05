using System;
using System.Collections.Generic;
using System.Text;


namespace ДЗ_4_v3
{
    public static class StackExtensions
    {
        public static void Merge(this ДЗ_4_v3.MyStack List, ДЗ_4_v3.MyStack myStack)
        {
            int i = 0;
            foreach (var n in myStack.List)
            {
                i++;
            }
            for (int j = 1; j <= i; j++)
            {
                List.Add(myStack.Top);
                myStack.Pop();
            }
        }
    }
    public class MyStack
    {
        public int Size;
        public string Top;
        public List<string> List = new List<string>();

        public MyStack(params string[] txt)
        {
            foreach (var n in txt)
            {
                Size ++;
                Top = n;
                List.Add(n);
            }
        }

        public void Pop()
        {
            try
            {
                if (List.Count == 0)
                {
                    throw new EmptyStackException();
                }

                List.Remove(Top.ToString());

                Size = 0;
                Top = null;
                foreach (var n in List)
                {
                    Size++;
                    Top = n;
                }
            }
            catch (EmptyStackException)
            {
                Console.WriteLine("Стэк пустой");
            }
        }

        public void Add(string str)
        {
            List.Add(str);
            Size = 0;
            Top = null;
            foreach (var n in List)
            {
                Size++;
                Top = n;
            }
        }


        public static MyStack Concat(params object[] obj)
        {
            var s = new MyStack();

            foreach (var MyStack in obj)
            {
                var MyStack_n = (MyStack)MyStack;
                while (MyStack_n.List.Count != 0)
                {
                    s.Add(MyStack_n.Top);
                    MyStack_n.Pop();
                }
            }

            return s;
        }


        /// <summary>
        /// вывод в консоль содержимого стэка (для проверки)
        /// </summary>
        public void Show()
        {
            StringBuilder sb = new StringBuilder();
            int i = 0;
            foreach (var n in List)
            {
                sb.Insert(i, n);
                i++;
            }
            Console.WriteLine($"в стэк [s] теперь элементы [{sb}]");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // основное задание
            var s = new MyStack("a", "b", "с");
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");

            var deleted = s.Top;
            s.Pop();
            Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}");

            s.Add("d");
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");

            s.Pop();
            s.Pop();
            s.Pop();
            Console.WriteLine($"size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");
            s.Pop();

            // доп. задание 1
            s = new MyStack("a", "b", "с");
            s.Merge(new MyStack("1", "2", "3"));

            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            s.Show();

            // доп. задание 2
            s.List.Clear();

            // new MyStack("Q", "W", "E") добавлено для проверки условия "неограниченное количество параметров типа Stack"

            s = MyStack.Concat(new MyStack("a", "b", "c"), new MyStack("1", "2", "3"), new MyStack("А", "Б", "В"), new MyStack("Q", "W", "E"));
            
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");
            s.Show();
        }
    }

    class EmptyStackException : Exception
    {
    }
}
