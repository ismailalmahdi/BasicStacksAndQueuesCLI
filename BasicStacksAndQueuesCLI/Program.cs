

using BasicStacksAndQueuesCLI;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Xml;

var MainCommands = new Dictionary<int, string>()
{
    [1] = "Stack",
    [2] = "Queue",
    [3] = "Quit",
};


var subCommands = new Dictionary<int, string>()
{
    [1] = "Dequeue",
    [2] = "Enqueue",
    [3] = "GetQueue",
    [4] = "Size",
    [5] = "Back To Main Menu Options"
};




void WelcomeDisplay()
{
    Console.WriteLine("Welcome to Basic Stacks and Queues CLI");
}


void displayOptions(Dictionary<int, string> options)
{
    foreach (var option in options)
    {
        Console.WriteLine(string.Format("[{0}] - {1}", option.Key, option.Value));
    }
}

STACK CreateStackPrompt()
{

    displayHeader("Initialize your stack prompt");
    Console.WriteLine("Please define the length of your stack:");
    int leng = readCommand();
    if (leng < 0)
    {
        MainMenu();
        return null;
    }
    STACK stack = new STACK(leng);
    Console.WriteLine(stack.ToString());
    Console.WriteLine("Your stack has been initialized successfully");

    return stack;
}


void StackMenu(STACK stack)
{
    pressToProcessed();

    displayHeader("Stack Menu");
    Console.WriteLine("Your Current Stack Values : " + stack.ToString());
    Console.WriteLine("Please Select an operation you want to perform to your stack:");
    displayOptions(subCommands);
    int cmd = readCommand();
    string[] results;

    switch (cmd)
    {

        case 1:// Dequeue
            Console.WriteLine("Dequeue return value: " + stack.dequeue());
            StackMenu(stack);
            break;

        case 2: //Enqueue
            string value = readValue();
            results = stack.enqueue(value);
            Console.WriteLine("Enqueue return value: " + displayArrayValues(results));
            StackMenu(stack);
            break;

        case 3: // GetQueue
            results = stack.getQueue();
            Console.WriteLine("GetQueue return value: " + displayArrayValues(results));
            StackMenu(stack);
            break;
        case 4: // Size
            Console.WriteLine("Size return value: " + stack.size());
            StackMenu(stack);
            break;
        case 5:
            MainMenu();
            break;

        default:
            Console.WriteLine(cmd + " is not an options please try again.");
            StackMenu(stack);
            break;
    }


}




QUEUE CreateQueuePrompt()
{

    displayHeader("Initialize your queue prompt");
    Console.WriteLine("Please define the length of your queue:");
    int leng = readCommand();
    if (leng < 0)
    {
        MainMenu();
        return null;
    }
    QUEUE queue = new QUEUE(leng);
    Console.WriteLine(queue.ToString());
    Console.WriteLine("Your stack has been initialized successfully");

    return queue;
}

void QueueMenu(QUEUE queue)
{
    pressToProcessed();

    displayHeader("Stack Menu");
    Console.WriteLine("Your Current Stack Values : " + queue.ToString());
    Console.WriteLine("Please Select an operation you want to perform to your stack:");
    displayOptions(subCommands);
    int cmd = readCommand();
    string[] results;

    switch (cmd)
    {

        case 1:// Dequeue
            Console.WriteLine("Dequeue return value: " + queue.dequeue());
            QueueMenu(queue);
            break;
        case 2: //Enqueue
            string value = readValue();
            results = queue.enqueue(value);
            Console.WriteLine("Enqueue return value: " + displayArrayValues(results));

            QueueMenu(queue);
            break;
        case 3: // GetQueue
            results = queue.getQueue();
            Console.WriteLine("GetQueue return value: " + displayArrayValues(results));

            QueueMenu(queue);
            break;
        case 4: // Size
            Console.WriteLine("Size return value: " + queue.size());
            QueueMenu(queue);
            break;
        case 5:
            MainMenu();
            break;

        default:
            Console.WriteLine(cmd + " is not an options please try again.");
            QueueMenu(queue);
            break;
    }
}


void MainMenu()
{
    displayHeader("Main Menu");
    Console.WriteLine("Pick an Operation:");
    displayOptions(MainCommands);
    int cmd = readCommand();

    switch (cmd)
    {
        case 1: // stack
            STACK stack = CreateStackPrompt();
            StackMenu(stack);
            break;
        case 2: // queue
            QUEUE queue = CreateQueuePrompt();
            QueueMenu(queue);
            break;
        case 3: // quit
            Console.WriteLine(" Thank you for testing this simple CLI Application Have an nice day!");
            break;
        default:
            Console.WriteLine(cmd + " is not an options please try again.");
            MainMenu();
            break;
    }
}


void displayHeader(string title)
{
    Console.WriteLine("\n\n\n\n__________________________________________");
    Console.WriteLine(string.Format("\n    {0}  ", title));
    Console.WriteLine("__________________________________________");
}



int readCommand()
{
    Console.Write("> ");

    string val = Console.ReadLine();
    int cmd = -1;
    if (string.IsNullOrEmpty(val))
    {
        Console.WriteLine("value can't be empty or null");
    }


    try
    {
        cmd = Convert.ToInt32(val);
    }
    catch (System.FormatException e)
    {
        Console.WriteLine("!! Options should be a number !!");
    }

    return cmd;
}

void pressToProcessed()
{
    Console.Write("... press enter to processed ...");
    Console.ReadLine();

}
string readValue()
{
    Console.Write("Please enter a value: > ");

    string val = Console.ReadLine();
    if (string.IsNullOrEmpty(val))
    {
        Console.WriteLine("!!! Input Should have a value");
        return "";
    }
    return val;
}

string displayArrayValues(String[] array)
{
    string s = "[ ";
    for (int i = 0; i < array.Length; i++)
    {
        if (i + 1 == array.Length)
        {
            s += string.IsNullOrEmpty(array[i]) ? "EMPTY" : array[i];
        }
        else
        {
            s += string.IsNullOrEmpty(array[i]) ? "EMPTY, " : array[i] + ", ";
        }
    }
    s += "]";
    return s;
}

// Start Application 
WelcomeDisplay();
MainMenu();




