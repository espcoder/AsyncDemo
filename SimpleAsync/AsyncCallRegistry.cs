using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleAsync
{
    internal class AsyncCallRegistry
    {
        internal async Task<string> WriteLogAsync(string message)
        {
            await Task.Run(() =>
                {
                    Console.WriteLine("Starting to Log ... ");
                    Task.Delay(1000);
                    Console.WriteLine($"Write Message: {message}");
                    Task.Delay(1000);
                });

            return "Finished writing to Log.";
        }



    }
}
