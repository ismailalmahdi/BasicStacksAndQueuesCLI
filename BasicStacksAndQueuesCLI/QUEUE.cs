using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStacksAndQueuesCLI
{
    internal class QUEUE : IQueuable
    {
        private String[] array;
        private int head = -1;
        private int tail = -1;

        public QUEUE(int maxSize)
        {
            array = new String[maxSize];
        }
        public string dequeue()
        {
            string result = "";

            try
            {
                if (head == tail)
                {
                    return "!!! -> Your Queue is empty already!";
                }
                else
                {
                    result = array[head];
                    array[head] = "";
                    head++;
                }
                
          
            }
            catch (System.IndexOutOfRangeException e)
            {
                result = array[head % array.Length];
                array[head % array.Length] = "";
                head++;

            }







            return result;

        }

        public string[] enqueue(string value)
        {
            if (head < 0 && tail < 0) // first element added 
            {
                head++;
                tail++;
            }

            // double check if there is empty slots within the array.
            if (Math.Abs(tail - head) < array.Length )
            {
                try
                {
                        array[tail] = value;
                        tail++;
                }
                catch (System.IndexOutOfRangeException e)
                {
                    array[tail % array.Length] = value;
                    tail++;
                }
            }
            else
            {
                Console.WriteLine("!!! -> Your Queue is full already!");
            }
            return array;
        }

        public string[] getQueue()
        {
            return array;
        }

        public int size()
        {
            return Math.Abs(tail - head);
        }

        public override string ToString()
        {
            string s = "{";
            for (int i = 0; i < array.Length; i++)
            {
                s += "[";
                if ((tail == i) || (tail % array.Length == i))
                {
                    s += "T";
                }
                if (head == i || (head % array.Length == i))
                {
                    s += "H";
                }

                s += " " + i + "] => ";

                if (i + 1 == array.Length)
                {
                    s += string.IsNullOrEmpty(array[i]) ? "EMPTY" : array[i];
                }
                else
                {
                    s += string.IsNullOrEmpty(array[i]) ? "EMPTY, " : array[i] + ", ";
                }
            }
            s += "}";
            return s;
        }
    }

}