using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            var syncCalls = new SynchronousCalls();
            var asyncCalls = new AsyncCallRegistry();

            Console.Write("Press the any key to run synchro log writer");
            Console.ReadKey();

            string syncMessage = syncCalls.WriteLog("We already know about synchronous calls.");
            Console.WriteLine(syncMessage);


            Console.Write("Press the any key to await the asynchro log writer");
            Console.ReadKey();

            string asyncMessage = Task.Run(async () => await asyncCalls.WriteLogAsync("Now we are going to learn await")).Result;

            Console.Write("Press the any key again to quit.");
            Console.ReadKey();

        }




    }
}
