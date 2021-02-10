using System;
using System.Threading;

namespace Collections
{
    class Program
    {
        /// <summary>
        /// Проверяет одинаковость массивов
        /// </summary>
        /// <param name="Mas_1">MasList</param>
        /// <param name="Mas_2">ChainList</param>
        /// <returns>bool</returns>
        public static bool Check(MasList Mas_1, ChainList Mas_2)
        {
            
            if (Mas_1.Count == Mas_2.Count)
            {
                for (int j = 0; j < Mas_1.Count; j++)
                {
                    if (Mas_1[j] != Mas_2[j])
                    {
                        return false;
                    }
                }
            }
            else return false;
            return true;
        }
        public static void Right(int i, int test_length)
        {
            if (i == test_length - 1)
            {
                Console.WriteLine("___________________");
                Console.WriteLine("|     SUCCESS!     |");
                Console.WriteLine("|__________________|");
            }
        }
        static void Main(string[] args)
        {            
            //Тестирование метода Save and Load
            BaseList b = new MasList();
            //for (int i = 0; i < 10; i++)
            //{
            //    b.Add(i + 10);
            //}            
            b.Load("dat");
            Console.WriteLine();            
            b.Print();

            ////Тестирование метода Clone
            //BaseList b = new MasList();
            //for (int i = 0; i < 10; i++)
            //{
            //    b.Add(i + 10);
            //}

            //b.Print();
            //Console.WriteLine();
            //BaseList a = b.Clone();
            //a.Print();

            ////Тестирование методов Assign и AssignTo
            //BaseList b = new MasList();            
            //BaseList a = new ChainList();
            //a.Add(1);
            //a.Add(2);
            //for (int i = 0; i < 10; i++)
            //{
            //    b.Add(i+10);
            //}

            //a.Print();
            //Console.WriteLine();
            //b.Print();
            //Console.WriteLine();
            //b.AssignTo(a);
            //a.Print();

            return;
            //Автотест методов Add, Delete, Insert, Sort + индексатор
            MasList Mas_1 = new MasList();
            ChainList Mas_2 = new ChainList();            
            int test_length = 1000;
            Random rand = new Random();            
            int operate;
            int A;
            int pos;

            for (int i = 0; i < test_length; i++)
            {
                if (Check(Mas_1,Mas_2))
                {
                    operate = rand.Next(5);
                    Thread.Sleep(1);
                    A = rand.Next(50) - 25;
                    Thread.Sleep(1);
                    pos = rand.Next(1000);
                    switch (operate)
                    {
                        case 0:
                            Mas_1.Add(A);
                            Mas_2.Add(A);
                            Console.WriteLine("Add");
                            break;
                        case 1:
                            Mas_1.Delete(pos);
                            Mas_2.Delete(pos);
                            Console.WriteLine("Delete");
                            break;
                        case 2:
                            Mas_1.Insert(A, pos);
                            Mas_2.Insert(A, pos);
                            Console.WriteLine("Insert");
                            break;
                        case 3:
                            Mas_1.Sort();
                            Mas_2.Sort();
                            Console.WriteLine("Sort");
                            break;
                        default:
                            Mas_1[pos] = A;
                            Mas_2[pos] = A;
                            Console.WriteLine("Index");
                            //Mas_1.Clear();
                            //Mas_2.Clear();
                            //Console.WriteLine("Clear");
                            break;
                    }
                    Mas_1.Print();
                    Console.WriteLine();
                    Mas_2.Print();
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("TEST ERROR");
                    break;
                }
                Right(i, test_length);
            }           
        }
    }
}
