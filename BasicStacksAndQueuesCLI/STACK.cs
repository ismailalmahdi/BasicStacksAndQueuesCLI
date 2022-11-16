using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStacksAndQueuesCLI
{

    // LIFO 
    internal class STACK : IQueuable
    {
        string[] array;
        private int top = -1;
        public STACK(int maxSize)
        {
            this.array = new string[maxSize];
        }

        // POP 
        public string dequeue()
        {
            if (top < 0)
                return "Stack is EMPTY!";

            // no really needed if this class is not returning it array as it is a
            // requirement to return an array it is best to remove the values that been dequeued 
            string temp = array[top];
            array[top] = "";
            top--;
            return temp;
            
            // alternative way it just to move the pointer "top" after getting the value as follows
            // as next time we enqueue to the array it will be replace by a new value
            //return array[top--];

        }

        // PUSH  
        public string[] enqueue(string value)
        {
            try
            {
                array[++top] = value;
            }
            catch (System.IndexOutOfRangeException e) { 
                Console.WriteLine("!!! -> Your Stack is Full Already!");
                top--;
            }
            return array;
        }


        // PEEK
        public string peek()
        {
            return array[top];
        }

        public string[] getQueue()
        {
           return array;
        }

        public int size()
        {
           return top + 1;
        }


        // TO DISPLAY ARRAY OF THE STACK
        public override string ToString()
        {
            string s = "{";
            for (int i = 0; i < array.Length; i++)
            {   
                s += (top == i)? "[*" + i + "] => " : "[" + i + "] => ";
                
                if(i + 1 == array.Length)
                {
                    s += string.IsNullOrEmpty(array[i])? "EMPTY": array[i];
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
