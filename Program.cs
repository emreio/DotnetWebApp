using System;
using System.Reflection;
using System.Threading.Tasks;

namespace EmreDotnetTest
{
    class Program
    {
        static Program()
        {
            //TODO app emre  domain changed.
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main thread idsler: " + System.Threading.Thread.CurrentThread.ManagedThreadId);
            // Main
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
            //TODO emre1
            throw new Exception("Hata var....");
        }

        private static void FeatureFunc()
        {

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
                //TODO emre
            }
        }
    }
}
