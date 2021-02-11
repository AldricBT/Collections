using System;
using System.Collections.Generic;
using System.Text;

namespace Collections
{
    class ChainList : BaseList
    {
        
        private class Elem
        {
            public Elem(int data)
            {
                Data = data;
            }
            public int Data { get; set; }
            public Elem Next { get; set; }            
        }

        public override int this[int index]
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
               

        /// <summary>
        /// Нахождение элемента (значения и на что он ссылается) по индексу
        /// </summary>
        /// <param name="pos">Индекс</param>
        /// <returns>Элемент (значение и ссылку на следующий)</returns>
        private Elem Find(int pos)
        {//нет смысла использовать try-catch так как сюда уже должны подаваться
            Elem current = first;
            for (int i = 0; i < pos; i++)
            {
                if (current != null)
                {
                    current = current.Next;
                }
                else
                {
                    throw new Exception();                    
                }                        
            }            
            return current;
        }

        /// <summary>
        /// Добавляет элемент в конец массива
        /// </summary>
        /// <param name="A">Элемент</param>
        public override void Add(int A)
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
        public override void Delete(int pos)
        {
            try
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
                else
                {
                    Find(pos - 1).Next = Find(pos + 1);
                    Count--;
                }
            }
            catch (Exception)
            {
                ErrorCount++;
            }
        }
        /// <summary>
        /// Вставка элемента в позицию, определяемую индексом
        /// </summary>
        /// <param name="A">Элемент списка</param>
        /// <param name="pos">Индекс позиции</param>
        public override void Insert(int A, int pos)
        {
            try
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
                else
                {
                    Elem current = new Elem(A);
                    current.Next = Find(pos);
                    Find(pos - 1).Next = current;
                    Count++;
                }
            }
            catch (Exception)
            {
                ErrorCount++;
            }            
        }
        /// <summary>
        /// Меняет местами два элемента списка
        /// </summary>
        /// <param name="i1">Индекс первого элемента</param>
        /// <param name="i2">Индекс второго элемента</param>
        private void Swap(int i1, int i2)
        {
            int mem = Find(i1).Data;
            if (i1 == 0)
            {
                first = Find(i2);
                Insert(mem, i2);
                Count--;
            }
            else
            {               
                Find(i1 - 1).Next = Find(i2);
                Insert(mem, i2);
                Count--;
            }
            
        }
        /// <summary>
        /// Сортировка списка пузырьком
        /// </summary>
        public override void Sort()
        {
            int inc = 0;

            while (inc < Count - 1)
            {
                inc++;
                if (Find(inc - 1).Data > Find(inc).Data)
                {
                    Swap(inc - 1, inc);
                    inc = 0;
                }
                
            }
        }
        /// <summary>
        /// Удаление списка
        /// </summary>
        public override void Clear()
        {
            Count = 0;
            first = null;
        }        
        /// <summary>
        /// Заменяет элементы экземпляра списка элементами нового списка
        /// </summary>
        /// <param name="list">Новый список</param>
        public override void Assign(BaseList list)
        {
            Clear();
            for (int i = 0; i < list.Count; i++)
            {
                Add(list[i]);
            }
        }

        public override BaseList Clone()
        {
            ChainList a = new ChainList();
            a.Assign(this);
            return a;
        }
    }
}
