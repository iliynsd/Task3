using System;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("It's a chat bot");
            var chatBot = new ChatBot();

            do
            {
                var cmd = Console.ReadLine();
                chatBot.AnswerChatBot(cmd);
            } while (true);
        }
    }
}