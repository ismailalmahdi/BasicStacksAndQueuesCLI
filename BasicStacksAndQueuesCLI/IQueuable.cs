using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BasicStacksAndQueuesCLI
{
    internal interface IQueuable
    {
        // add value to queue and returns new queue 
        string[] enqueue(string value);
        
        // removes item from queue, and returns the item removed 
        string dequeue();

        // returns a list of all the items in the queue 
        string[] getQueue();


        // return the number of the items in the queue
        int size();
    }
}
