﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    class MasList
    {
        /// <summary>
        /// Поля
        /// </summary>
        private int count = 0;
        private int[] data = null;
        private int maslength = 0;  //длина выделенной памяти под массив

        /// <summary>
        /// Количетво элементов массива
        /// </summary>
        public int Count
        {
            get { return count; }
            private set { count = value; }
        }
        public int[] Data
        {
            get { return data; }
            set { data = value; }
        }
        private int MasLength
        {
            get { return maslength; }
            set { maslength = value; }
        }
        /// <summary>
        /// Индексатор
        /// </summary>
        /// <param name="index">Индекс</param>
        /// <returns>Элемент массива</returns>
        public int this[int index]
        {
            get
            {
                if (index < Count)
                {
                    return Data[index];
                }
                else return 0;
            }
            set
            {
                if (index < Count)
                {
                    Data[index] = value;
                }                 
            }
        }

        /// <summary>
        /// Расширение
        /// </summary>
        private void Extend()
        {
            if (MasLength == 0)
            {
                MasLength = 1;
                Data = new int[MasLength];
            }
            else
            {
                MasLength *= 2;
                int[] Data_help = new int[MasLength];
                for (int i = 0; i < Count; i++)
                {
                    Data_help[i] = Data[i];
                }                
                Data = Data_help;
            }
            
        }
        /// <summary>
        /// Вывод всего массива
        /// </summary>        
        public void Print()
        {
            for (int i = 0; i < Count; i++)
            {
                Console.Write($"{Data[i]}; ");
            }            
        }
        /// <summary>
        /// Добавление элемента в конец массива
        /// </summary>
        /// <param name="Elem">Элемент</param>
        public void Add(params int[] Elem)
        {            
            for (int i = 0; i < Elem.Length; i++)
            {
                if (MasLength == Count)
                {
                    Extend();
                }
                Data[Count] = Elem[i];
                Count++;
            }            
            
        }
        /// <summary>
        /// Удаление массива
        /// </summary>
        public void Clear()
        {
            MasLength = 0;
            Count = 0;
            Data = null;
        }
        /// <summary>
        /// Удаление элемента по индексу
        /// </summary>
        /// <param name="pos">Индекс</param>
        public void Delete(int pos)
        {
            if ((Count == 1)&&(pos == 0))
            {
                Clear();
            }
            else if (pos == Count - 1)
            {                
                Count--;
            }
            else if ((pos < Count) && (pos >= 0))
            {
                for (int i = pos; i < Count - 1; i++)
                {
                    Data[i] = Data[i + 1];
                }
                Count--;
            }
            else
            {
                Console.WriteLine("Операция Delete не выполнена (неправильно указан индекс)");
            }
           
        }
        /// <summary>
        /// Вставка элемента массива в позицию, определяемую индексом
        /// </summary>
        /// <param name="Elem">Элемент массива</param>
        /// <param name="pos">Индекс позиции</param>
        public void Insert(int Elem, int pos)
        {
            if ((pos <= Count)&&(pos >= 0))
            {
                if (MasLength == Count)
                {
                    Extend();
                }
                for (int i = Count - 1; i >= pos; i--)
                {
                    Data[i + 1] = Data[i];
                }
                Data[pos] = Elem;
                Count++;
            }
            else
            {
                Console.WriteLine("Операция Insert не выполнена (неправильно указан индекс)");
            }
            
        }
        /// <summary>
        /// Возвращает элемент ячейки
        /// </summary>
        /// <param name="pos">Индекс ячейки</param>
        /// <returns>Элемент</returns>
        public int View(int pos)
        {
            return Data[pos];
        }
    }
}