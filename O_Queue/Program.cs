using System;

namespace O_Queue
{

    public class Steuerung
    {
        public static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();    
            queue.enqueue(1);
            queue.enqueue(2);
            queue.enqueue(3);
            
            queue.printQueue();

            Console.WriteLine($"Weg damit {queue.dequeue()}");
            
            queue.printQueue();
        }
        
    }
    
    
    internal class Queue<T>
    {
        private Element<T> firstElement;

        public void enqueue(T elem)
        {
            if (firstElement != null)
            {
                Element<T> next = firstElement;
                while (next.NextElem != null)
                {
                    next = next.NextElem;
                }
                next.NextElem = new Element<T> (elem,null);
            }
            else
            {
                firstElement = new Element<T>(elem, null);
            }
        }

        public T dequeue()
        {
            T dataFromFirst = firstElement.Data;
            if (firstElement.NextElem != null)
            {
                firstElement = firstElement.NextElem;
            }
            
            return dataFromFirst;
        }

        public void printQueue()
        {
            string res = "";
            Element<T> next = firstElement;
            while (next.NextElem != null)
            {
                res += next.ToString();
                next = next.NextElem;
            }

            res += next.ToString();
            Console.WriteLine(res);
        }
    }

    public class Element<T>
    {
        private T data;
        private Element<T> nextElem;

        public Element<T> NextElem
        {
            get => nextElem;
            set => nextElem = value;
        }

        public T Data
        {
            get => data;
            set => data = value;
        }

        public Element(T data, Element<T> nextElem)
        {
            this.data = data;
            this.nextElem = nextElem;
        }

        public override string ToString()
        {
            return $"{data},";
        }
    }
}