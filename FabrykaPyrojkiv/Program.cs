using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace FabrikaPirojkov
{
    class Program
    {
        private static int testoCount;
        private static int pirojkiCount;
        private static int productCount;
        static void Main(string[] args)
        {
            testoCount = 0;
            pirojkiCount = 0;
            productCount = 0;


            Thread vasyaThread = new Thread(VasyaWork);
            Thread petyaThread = new Thread(PetyaWork);
            Thread vadimThread = new Thread(VadimWork);

            vasyaThread.Start();
            petyaThread.Start();
            vadimThread.Start();
            Console.ReadKey(true);
        }
        static void Log(string text,string person,ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine($"[{DateTime.Now}] [{person}] {text}");
            Console.ForegroundColor = ConsoleColor.White;
            
        }
        static void VasyaWork(object obj)
        {
            while (true)
            {
                Thread.Sleep(3500);
                testoCount++;
                Log($"Testo na podhode! U nas uje {testoCount} testa!", "Vasya", ConsoleColor.Red);
            }
        }
        static void PetyaWork(object obj)
        {
            while (true)
            {
                if (testoCount > 0)
                {
                    Thread.Sleep(5000);
                    pirojkiCount++;
                    testoCount--;
                    Log($"Pirojok zdelan! Testa ostalos {testoCount}, Pirojkov - {pirojkiCount}", "Petya", ConsoleColor.Yellow);
                }
            }
        }
        static void VadimWork(object obj)
        {
            while (true)
            {
                if (pirojkiCount > 0)
                {
                    Thread.Sleep(15000);
                    productCount++;
                    pirojkiCount--;
                    Log($"Pyrojok zapechen! Gotovyh pyrojkov - {productCount}, zagotovok - {pirojkiCount}", "Vadim", ConsoleColor.Green);
                }
            }
        }
    }
}
