using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading
{
    class Program
    {
        private static bool task1Ended = false;
        private static bool task2Ended = false;
        private static bool task3Ended = false;
        private static bool bremseEnded = false;

        static void Main(string[] args)
        {

            Parallel.Invoke(task1, task2, task3, Bremse);
            Console.WriteLine("AfterParalellInvoke");
            Console.ReadKey();
        }


        static void task1()
        {
            do
            {
                if (bremseEnded)
                {
                    Console.WriteLine("Task1");
                }
                
            } while (!bremseEnded);

            
            task1Ended = true;
        }

        static void task2()
        {
            task2Ended = true;
        }

        static void task3()
        {
            Console.WriteLine("Task3");
            task3Ended = true;
        }

        static void Bremse()
        {
            for(int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.WriteLine("ThreadSleep for 500milliSec " + "/" + i);
            }
            bremseEnded = true;
        }



    }
}
