using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAsync
{
    internal class SynchronousCalls
    {

        internal String WriteLog(string message)
        {
            Console.WriteLine("Starting to Log ... ");
            Console.WriteLine($"Write Message: {message}");

            return "Finished writing to Log.";

        }

    }
}
