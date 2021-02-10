using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    abstract class BaseList
    {
        private int count = 0;
        private int[] data = null;
        private int errorCount = 0;
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
        public int ErrorCount
        {
            get { return errorCount; }
            private set { errorCount = value; }
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
            if (this is MasList)
            {
                for (int i = 0; i < Count; i++)
                {
                    Console.Write($"{Data[i]}; ");
                }
            }
            else if (this is ChainList)
            {
                for (int i = 0; i < Count; i++)
                {
                    Console.Write($"{(this as ChainList)[i]}; ");
                }
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
                while ((mass[left] <= mass[pivot]) && (left < right))
                {//находим число слева больше опорного
                    left++;
                }
                while ((mass[right] >= mass[pivot]) && (left < right))
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
        /// <summary>
        /// Заменяет элементы текущего списка, элементами другого списка
        /// </summary>
        /// <param name="list">Другой список</param>
        public virtual void Assign(BaseList list)
        {
            Count = list.Count;
            Data = new int[Count];
            for (int i = 0; i < Count; i++)
            {                
                if (list is MasList)
                {
                    Data[i] = list.Data[i];
                }
                else if (list is ChainList)
                {   
                    Data[i] = (list as ChainList)[i];
                }
            }
        }
        /// <summary>
        /// Заменяет элементы другого списка элементами списка
        /// </summary>
        /// <param name="list">Другой список</param>
        public void AssignTo(BaseList list)
        {
            list.Assign(this);
        }
        /// <summary>
        /// Копирует список
        /// </summary>
        /// <returns></returns>
        public abstract BaseList Clone();

        /// <summary>
        /// Сохранение списка в файл
        /// </summary>
        /// <param name="filename">Имя файла</param>
        public void Save(string filename)
        {
            string path = @"D:\Study\Технологии программирования\Lab_1\";
            try
            {
                using (StreamWriter sw = new StreamWriter(path + filename))
                {
                    if (this is MasList)
                    {
                        for (int i = 0; i < Count; i++)
                        {
                            sw.Write($"{Data[i]} ");
                        }
                    }
                    else if (this is ChainList)
                    {
                        for (int i = 0; i < Count; i++)
                        {
                            sw.Write($"{(this as ChainList)[i]} ");
                        }
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ErrorCount++;
            }
        }
        /// <summary>
        /// Загрузка списка из файла
        /// </summary>
        /// <param name="filename">Имя файла</param>
        public void Load(string filename)
        {
            string path = @"D:\Study\Технологии программирования\Lab_1\";
            try
            {
                using (StreamReader sr = new StreamReader(path + filename))
                {
                    string line = null;
                    char[] charSeparators = new char[] { ' ', ',', '.', ';' };
                    while (!sr.EndOfStream)
                    {
                        line += sr.ReadLine() + " ";
                    }
                    Console.WriteLine(line);
                    Console.WriteLine();
                    string[] smass = line.Split(charSeparators);
                    for (int i = 0; i < smass.Length; i++)
                    {
                        if (smass[i] != "")
                        {
                            this.Add(int.Parse(smass[i]));
                            Console.Write(smass[i] + " ");
                        }                        
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ErrorCount++;
            }
        }
    }
}
