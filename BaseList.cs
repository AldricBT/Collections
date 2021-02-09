using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    abstract class BaseList
    {
        private int count = 0;
        private int[] data = null;
        public int Count
        {
            get { return count; }
            protected set { count = value; }
        }
        public virtual int[] Data
        {
            get { return data; }
            set { data = value; }
        }

        abstract public int this[int index] { get; set; }

        /// <summary>
        /// Добавление элемента в конец списка
        /// </summary>
        /// <param name="a">Элемент</param>
        abstract public void Add(int a);

        /// <summary>
        /// Удаление элемента по индексу
        /// </summary>
        /// <param name="pos">Индекс элемента</param>
        abstract public void Delete(int pos);
        /// <summary>
        /// Вставка элемента по индексу
        /// </summary>
        /// <param name="a">Элемент</param>
        /// <param name="pos">Индекс</param>
        abstract public void Insert(int a, int pos);

        /// <summary>
        /// Вывод списка на экран
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.Write($"{Data[i]}; ");
            }
        }

        abstract public void Clear();

        /// <summary>
        /// Быстрая сортировка
        /// </summary>
        /// <param name="mass">Сортируемый массив</param>
        /// <param name="left">Индекс первого элемента</param>
        /// <param name="right">Индекс последнего элемента</param>
        private void Qsort(int[] mass, int left, int right)
        {
            if (right - left < 1) return;       //если подается массив из 1 элемента            
            int pivot = right;  //индекс опорного элемента (последний)
            right--;
            int left_b = left;
            int mem;

            while (left < right)
            {
                while ((mass[left] <= mass[pivot])&&(left < right))
                {//находим число слева больше опорного
                    left++;
                }
                while ((mass[right] >= mass[pivot])&&(left < right))
                {//находим число справа меньше опорного
                    right--;
                }
                if (left != right)
                {//меняем их местами
                    mem = mass[left];
                    mass[left] = mass[right];
                    mass[right] = mem;
                }
            }
            if (mass[left] > mass[pivot])
            {
                mem = mass[left];
                mass[left] = mass[pivot];
                mass[pivot] = mem;
                Qsort(mass, left_b, left - 1);
                Qsort(mass, left + 1, pivot);
            }
            else
            {
                Qsort(mass, left_b, left);
            }

            

        }
        /// <summary>
        /// Сортирует список по возрастанию
        /// </summary>
        public virtual void Sort()
        {
            Qsort(Data, 0, Count - 1);
        }
        


    }
}
