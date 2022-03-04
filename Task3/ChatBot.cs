using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class ChatBot
    {
        private List<List<Tuple<string, Action<string>>>> answers = new List<List<Tuple<string, Action<string>>>>
        {
            new List<Tuple<string, Action<string>>>
            {
                new Tuple<string, Action<string>>("Привет", i => Console.WriteLine("Привет")),
                new Tuple<string, Action<string>>("Здраствуй", i => Console.WriteLine("Здраствуй")),
                new Tuple<string, Action<string>>("Здраствуйте", i => Console.WriteLine("Здраствуйте")),
                new Tuple<string, Action<string>>("Добрый день", i => Console.WriteLine("Добрый день")),
                new Tuple<string, Action<string>>("Добрый вечер", i => Console.WriteLine("Добрый вечер")),
                new Tuple<string, Action<string>>("Доброе утро", i => Console.WriteLine("Доброе утро")),
                new Tuple<string, Action<string>>("Доброй ночи", i => Console.WriteLine("Доброй ночи"))
            },
            new List<Tuple<string, Action<string>>>
            {
                new Tuple<string, Action<string>>("Как тебя зовут?", i => Console.WriteLine("Шарпик"))
            },
            new List<Tuple<string, Action<string>>>
            {
                new Tuple<string, Action<string>>("Анекдот", i => Console.WriteLine("Купил мужик диван. Тащит через лестничную дверь в квартиру, Диван застрял, на площадку выходит сосед. - Слушай, сосед, помоги протащить этот чертов диван. Стали тащить вдвоем. Пыхтят, упираются, диван ни с места. Тот, кто купил: - Ладно, хватит. Чувствую, мы его никогда не втащим. Сосед: - Втащим?..."))
            },
            new List<Tuple<string, Action<string>>>
            {
                new Tuple<string, Action<string>>("Который час?", i => Console.WriteLine($"Время - {DateTime.Now:t}")),
                new Tuple<string, Action<string>>("Сколько времени?", i => Console.WriteLine($"Время - {DateTime.Now:t}"))
            },
            new List<Tuple<string, Action<string>>>
            {
                new Tuple<string, Action<string>>("Пока", i =>
                {
                    Console.WriteLine("Пока");
                    Environment.Exit(0);
                }),
                new Tuple<string, Action<string>>("До свидания", i =>
                {
                    Console.WriteLine("До свидания");
                    Environment.Exit(0);
                })
            },
            new List<Tuple<string, Action<string>>>
            {
                new Tuple<string, Action<string>>("", i => Console.WriteLine("Каждый слышит только то, что он понимает"))
            }
        };
        
        public void AnswerChatBot(string cmd)
        {
            var index = answers.FindIndex(i => i.Select(i => i.Item1).ToList().Contains(cmd));
            if (index < 0)
            {
                cmd = "";
                index = answers.FindIndex(i => i.Select(i => i.Item1).ToList().Contains(cmd));
            }

            answers[index].Find(i => i.Item1 == cmd).Item2.Invoke("");
        }
    }
}