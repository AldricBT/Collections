﻿using System;
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
                    if (Mas_1.View(j) != Mas_2.View(j))
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
            //Автотест
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
                    operate = rand.Next(4);
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
                        default:
                            //Mas_1[pos] = A;
                            //Mas_2[pos] = A;
                            //Console.WriteLine("Index");
                            Mas_1.Clear();
                            Mas_2.Clear();
                            Console.WriteLine("Clear");
                            Console.WriteLine("New");
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
