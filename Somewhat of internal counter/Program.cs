using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {

            var counter = Properties.Settings.Default.Counter;
            if (counter == 0)
            {
                Console.WriteLine("Program will run 5 times");
                IncreaseCounter();
                Console.ReadKey();
                Environment.Exit(0);
            }

            if (counter <= 5)
            {
                IncreaseCounter();
                Console.WriteLine($"Hello there,\nApp ran {counter} times, you have {5 - counter} times left");
            }
            else
            {
                Console.WriteLine("license is over\nType key");
                var key = Console.ReadLine();
                if (key == "123456")
                    Properties.Settings.Default.Reset();
                Environment.Exit(0);
            }

            Console.ReadKey();
            

        }

        static void IncreaseCounter()
        {
            Properties.Settings.Default.Counter++;
            Properties.Settings.Default.Save();
        }




    }
}
