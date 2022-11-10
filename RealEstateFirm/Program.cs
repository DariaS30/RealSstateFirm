using PL;
using System;

namespace RealEstateFirm
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandHandler handler = new CommandHandler();
            handler.CommandHandle();
            Console.ReadKey();
        }
    }
}
