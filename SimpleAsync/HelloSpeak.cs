using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleAsync
{
    class HelloSpeak
    {

        public static void RunHelloSpeak()
        {
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();

            HelloWorld();

            //HelloSpeak.HelloAsyncWorld_v3();
            //HelloSpeak.HelloAsyncWorld_v4();
            //HelloSpeak.HelloAsyncWorld_v45();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static void HelloAsyncWorld_v45()
        {
            Task t = Task.Run(() => SpeakAsync());

            Console.WriteLine("Waiting for my Task");
            t.Wait();
        }

        public static void HelloAsyncWorld_v4()
        {
            Task t = Task.Factory.StartNew(SpeakAsync);

            Console.WriteLine("Waiting for my Task");
            t.Wait();
        }

        public static void HelloAsyncWorld_v3()
        {
            Task t = new Task(SpeakAsync);
            t.Start();
            Console.WriteLine("Waiting for my Task");
            t.Wait();
        }

        public static void HelloWorld()
        {
            Speak();
        }

        private static void SpeakAsync()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Hello Async World!");

        }

        private static void Speak()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Hello World!");
        }

    }
}
