using System;
using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

/*
 * ANSWER TO QUESTIONS:
 * 1)   The stack stores value types in such a way that if you wish to access the second item from the top, 
 *      the top one first needs to move, i.e. last-in, first-out access to items. 
 *      The heap stores reference types in scattered form where everything is available at once, or
 *      as needed, kind of like in a warehouse. You can access the item you need without ever moving any
 *      other items.
 *      
 * 2)   A value type holds/contains a value within its own memory space, i.e. a = 10 
 *      The system stores 10 in the memory space allocated for the variable a.
 *      A reference type doesn't store its value directly. It stores the address on the heap where the 
 *      value is being stored. So we can say that a reference type contains a pointer to another memory 
 *      location that holds the data. 
 *      
 * 3)   In the first method (ReturnValue), only value types are used. 
 *      The line stating "y = x" does nothing else but give y the same value as x (which is 3). 
 *      The next line "y = 4" just sets the value of y to 4, it has no effect on the value of x (which is still 3).   
 *      
 *      In the second method (ReturnValue2) an object with the property MyValue is created. 
 *      The line stating "y = x" tells y to point to the same object that x already points to (which is 3). 
 *      The next line sets MyValue to 4 with "y.MyValue = 4". 
 *      After that x.MyValue is returned and it points to the same value as y (which is 4).
 */

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        private static bool ChangeCtrl(int val1, int val2, out int change)
        {
            change = val1 - val2;
            return change != 0;
        }
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application");
                char input = ' '; // Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; // Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) // If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List 
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            var aList = new List<string>();

            Console.Clear();

            Console.WriteLine("\nList initalized");
            Console.WriteLine($"Capacity: {aList.Capacity} Count: {aList.Count}\n");

            var running = true;
            while (running)
            {
                Console.WriteLine("\nPlease enter some valid input.");
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                var capacityBefore = aList.Capacity;
                var countBefore = aList.Count;

                char oi = input[0];
                string value = input.Substring(1);

                switch (oi)
                {
                    case '+':
                        aList.Add(value);
                        break;
                    case '-':
                        aList.Remove(value);
                        break;
                    case '0':
                    case 'e':
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please use only \"+\" or \"-\" as an operator");
                        Console.WriteLine("To return to main menu, please enter \"0\"");
                        continue;
                }

                /*
                 * 2) Once the last element in the array has been written to, the capacity of the list increases.
                 * 3) Its growth is exponential.
                 * 4) Its inefficient to resize the list, because it has to create a new array and copy the elements over for each size increase.
                 * 5) No, the list will keep its size when elements are removed.
                 * 6) When you know what size of an array you need beforehand, it is preferable to use a specific sized array to avoid reallocation and memory overhead.
                */

                if (!running) break;

                var capacityAfter = aList.Capacity;
                var countAfter = aList.Count;

                Console.Write("\n");

                if (ChangeCtrl(capacityBefore, capacityAfter, out int capacityChange))
                    Console.WriteLine($"Capacity {(capacityChange > 0 ? "decreased" : "increased")} by {(capacityChange < 0 ? -1 : 1) * capacityChange}");
                else
                    Console.WriteLine("Capacity did not change");

                if (ChangeCtrl(countBefore, countAfter, out int countChange))
                    Console.WriteLine($"Count {(countChange > 0 ? "decreased" : "increased")} by {(countChange < 0 ? -1 : 1) * countChange}");
                else
                    Console.WriteLine("Count didn't change");

            }

            Console.WriteLine("\n\nFinal list size");
            Console.WriteLine($"Capacity: {aList.Capacity} Count: {aList.Count}");

            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            var aQueue = new Queue<string>();

            Console.Clear();
            Console.WriteLine("\nQueue initalized");

            var running = true;
            while (running)
            {
                Console.WriteLine("\nPlease enter some valid input.");
                var input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                char oi = input[0];
                string value = input.Substring(1);

                switch (oi)
                {
                    case '+':
                        aQueue.Enqueue(value);
                        Console.WriteLine($"Customer {value} has been added to the line");
                        break;
                    case '-':
                        Console.WriteLine($"Customer {aQueue.Dequeue()} has been handled");
                        break;
                    case '0':
                    case 'e':
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please use only \"+\" or \"-\" as an operator");
                        Console.WriteLine("To return to the main menu, please enter \"0\"");
                        continue;
                }

                if (!running) break;

                Console.WriteLine($"Queue size: {aQueue.Count}");

                if (aQueue.Count > 0) Console.WriteLine($"Next customer in line: {aQueue.Peek()}");
            }

            if (aQueue.Count > 0)
            {   Console.WriteLine("\nStore forgot to handle these customers:");
                while (aQueue.Count > 0)
                {   Console.WriteLine(aQueue.Dequeue());  }
            }
            else  { Console.WriteLine("\nNo customers waiting in line");
            }

            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
        }
    

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            bool running = true;
            Stack<string> stack = new Stack<string>();
            
            System.Console.WriteLine(
                "Enter + to add or - to remove from the stack. \nPress any key to return to main menu..."
            );
            do
            {
                string input = Console.ReadLine()!;
                char navi = input![0];
                string value = input.Substring(1);
                switch (navi)
                {
                    case '+':
                        stack.Push(value);
                        Console.WriteLine($"{value} has been added to the stack.");
                        break;
                    case '-':
                        stack.Pop();
                        Console.WriteLine($"{stack.Pop()} has been taken care of.");
                        break;
                    default:
                        running = false;
                        break;
                }
            } while (running);

            /*
                Stack is not a great datastructure to represent a customer line in a store or first in, first out.
                The last customer to join the line is the first to be attended too.
                Customers that join first will have to wait the longest.
            */
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Console.Clear();
            string? inputStr;

            do
            {
                Console.WriteLine("\nPlease enter a string containing parantheses.");
                inputStr = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(inputStr));

            // Store what types of parantheses/brackets to check for.
            char[] startParantheses = ['(', '[', '{'];
            char[] endParantheses = [')', ']', '}'];
            bool isCorrect = true;
            var stack = new Stack<char>();

            for (int i = 0; i < inputStr.Length; i++)
            {
                // Starting paranthesis
                if (startParantheses.Contains(inputStr[i]))
                {
                    stack.Push(inputStr[i]);
                }

                // Ending paranthesis
                if (endParantheses.Contains(inputStr[i]))
                {
                    if (stack.Count > 0)
                    {
                        if (!paranthesesMatch(stack.Pop(), inputStr[i]))
                        {
                            isCorrect = false;
                            break;
                        }
                    }
                    else
                    {
                        isCorrect = false;
                        break;
                    }
                }
            }
            // Print user feedback
            if (isCorrect) { Console.WriteLine("\nYour input has the correct format!"); }
            else
            {
                Console.WriteLine("\nSorry! Your input DOES NOT have the correct format.");
            }
            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
        }

        // Parantheses match
        static bool paranthesesMatch(char openChar, char closeChar)
        {
            switch (openChar)
            {
                case '(':
                    return closeChar == ')';
                case '[':
                    return closeChar == ']';
                case '{':
                    return closeChar == '}';
                default:
                    return false;
            }
        }     
    }
}

