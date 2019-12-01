using System;
using System.Collections.Generic;
using System.Text;

namespace SimplyCalculator_v2
{
    public class Logger
    {
        public static void Log(Exception exec)
        {
            Console.WriteLine("##########################");
            Console.WriteLine("ERROR LOG:");

            Console.WriteLine(exec.Message);

            Console.WriteLine("##########################");

        }
    }
}
