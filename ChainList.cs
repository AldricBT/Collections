using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    class ChainList
    {
        private int count = 0;
        private class Elem
        {
            public Elem(int data)
            {
                Data = data;
            }
            public int Data { get; set; }
            public Elem Next { get; set; }            
        }

        public int this[int index]
        {
            get
            {
                if (index < Count)
                {
                    return Find(index).Data;
                }
                else return 0;
            }
            set
            {
                if (index < Count)
                {
                    Find(index).Data = value;
                }
            }
                
        }

        private Elem first = null; 

        public int Count
        {
            get { return count; }
            private set { count = value; }
        }

        /// <summary>
        /// Нахождение элемента (значения и на что он ссылается) по индексу
        /// </summary>
        /// <param name="pos">Индекс</param>
        /// <returns>Элемент (значение и ссылку на следующий)</returns>
        private Elem Find(int pos)
        {
            Elem current = first;
            for (int i = 0; i < pos; i++)
            {
                current = current.Next;
            }
            return current;
        }

        /// <summary>
        /// Добавляет элемент в конец массива
        /// </summary>
        /// <param name="A">Элемент</param>
        public void Add(int A)
        {
            Elem elem = new Elem(A);    //создаем ссылку на новый элемент
            if (first == null)  //если список пуст
            {
                first = elem;   //то первый становится этим элементом
            }
            else
            {                
                Find(Count - 1).Next = elem;  //иначе последний начинает хранить ссылку на новый элемент
            }
            Count++;
        }
        /// <summary>
        /// Удаляет элемент с выбранным индексом
        /// </summary>
        /// <param name="pos">Индекс</param>
        public void Delete(int pos)
        {
            if ((pos == 0) && (Count > 1))
            {
                first = Find(1);    //для удаления 0 элемента (при условии, что он не единственный), 0ый становится 1ый
                Count--;
            }
            else if (((pos == 0) && (Count == 1)))            
            {
                Clear();    //если элемент единственный, то удаляется весь список
            }
            else if (pos == Count - 1)
            {
                Find(pos - 1).Next = null;
                Count--;
            }
            else if ((pos > 0) && (pos < Count))
            {
                Find(pos - 1).Next = Find(pos + 1);
                Count--;
            }
            else
            {
                Console.WriteLine("Операция Delete не выполнена (неправильно указан индекс)");
            }
        }
        /// <summary>
        /// Вставка элемента в позицию, определяемую индексом
        /// </summary>
        /// <param name="A">Элемент списка</param>
        /// <param name="pos">Индекс позиции</param>
        public void Insert(int A, int pos)
        {
            if (pos == 0)
            {
                Elem current = new Elem(A);
                current.Next = first;
                first = current;
                Count++;
            }
            else if (pos == Count)
            {
                Add(A);
            }
            else if ((pos > 0) && (pos < Count))
            {
                Elem current = new Elem(A);
                current.Next = Find(pos);
                Find(pos - 1).Next = current;
                Count++;
            }
            else
            {
                Console.WriteLine("Операция Insert не выполнена (неправильно указан индекс)");
            }
        }
        /// <summary>
        /// Удаление списка
        /// </summary>
        public void Clear()
        {
            Count = 0;
            first = null;
        }
        /// <summary>
        /// Вывод всего списка
        /// </summary>
        public void Print()
        {
            Elem current = first;   //текущий элемент становится первым
            while (current != null) //пока текущий не станет ссылаться на null (пока он не станет последним)
            {
                Console.Write(current.Data + "; ");
                current = current.Next;
            }
        }
        /// <summary>
        /// Возвращает элемент ячейки
        /// </summary>
        /// <param name="pos">Индекс ячейки</param>
        /// <returns>Элемент</returns>
        public int View(int pos)
        {
            return Find(pos).Data;
        }
    }
}
