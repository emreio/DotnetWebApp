using System;
using System.Reflection;
using System.Threading.Tasks;

namespace EmreDotnetTest
{
    class Program
    {
        static Program()
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main thread idsler: " + System.Threading.Thread.CurrentThread.ManagedThreadId);

            CallAsync();

            Console.ReadLine();
        }

        public static async void CallAsync()
        {
            string returnVal = await GetStringAsync();
            Console.WriteLine(returnVal);
        }

        public static async Task<string> GetStringAsync()
        {
            throw new Exception("hata var hata");
            return await Task.Run(() => { Console.WriteLine("Background thread id: " + System.Threading.Thread.CurrentThread.ManagedThreadId); return "test"; });
        }


        private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Hataaaaa:");
            Console.WriteLine(e);
            throw new Exception("yeni hata");
        }

        private static void ProduceException()
        {
            throw new Exception("Hata var..");
        }

        static int CallMethod()
        {
            try
            {
                return 5;
            }
            finally
            {
                Console.WriteLine("finally");
            }
        }
    }
}
