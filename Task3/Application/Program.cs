using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("It's a chat bot");
            var chatBot = new ChatBot();
            string cmd;
            do 
            { 
                Console.WriteLine("Enter command or -help to see bot commands"); 
                cmd = Console.ReadLine();
                if (cmd == "-help")
                {
                    chatBot.GetCommands().ForEach(Console.WriteLine);
                }
                else
                {
                    Console.WriteLine(chatBot.GetAnswer(cmd));
                }
            } while (!chatBot.IsStop(cmd));
        }
    }
}