using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class ChatBot
    {
        private List<List<Tuple<string, Action>>> _answers;

        public ChatBot()
        {
            _answers = new List<List<Tuple<string, Action>>>
        {
            new List<Tuple<string, Action>>
            {
                new Tuple<string, Action>("Привет", () => Console.WriteLine("Привет")),
                new Tuple<string, Action>("Здраствуй", () => Console.WriteLine("Здраствуй")),
                new Tuple<string, Action>("Здраствуйте", () => Console.WriteLine("Здраствуйте")),
                new Tuple<string, Action>("Добрый день", () => Console.WriteLine("Добрый день")),
                new Tuple<string, Action>("Добрый вечер", () => Console.WriteLine("Добрый вечер")),
                new Tuple<string, Action>("Доброе утро", () => Console.WriteLine("Доброе утро")),
                new Tuple<string, Action>("Доброй ночи", () => Console.WriteLine("Доброй ночи"))
            },
            new List<Tuple<string, Action>>
            {
                new Tuple<string, Action>("Как тебя зовут?", () => Console.WriteLine("Шарпик"))
            },
            new List<Tuple<string, Action>>
            {
                new Tuple<string, Action>("Анекдот", () => Console.WriteLine("Купил мужик диван. Тащит через лестничную дверь в квартиру, Диван застрял, на площадку выходит сосед. - Слушай, сосед, помоги протащить этот чертов диван. Стали тащить вдвоем. Пыхтят, упираются, диван ни с места. Тот, кто купил: - Ладно, хватит. Чувствую, мы его никогда не втащим. Сосед: - Втащим?..."))
            },
            new List<Tuple<string, Action>>
            {
                new Tuple<string, Action>("Который час?", () => Console.WriteLine($"Время - {DateTime.Now:t}")),
                new Tuple<string, Action>("Сколько времени?", () => Console.WriteLine($"Время - {DateTime.Now:t}"))
            },
            new List<Tuple<string, Action>>
            {
                new Tuple<string, Action>("Пока", () =>
                {
                    Console.WriteLine("Пока");
                    Environment.Exit(0);
                }),
                new Tuple<string, Action>("До свидания", () =>
                {
                    Console.WriteLine("До свидания");
                    Environment.Exit(0);
                })
            },
            new List<Tuple<string, Action>>
            {
                new Tuple<string, Action>("", () => Console.WriteLine("Каждый слышит только то, что он понимает"))
            }
        };
        }
        
        public void AnswerChatBot(string cmd)
        {
            var index = _answers.FindIndex(i => i.Select(i => i.Item1).ToList().Contains(cmd));
            if (index < 0)
            {
                cmd = "";
                index = _answers.FindIndex(i => i.Select(i => i.Item1).ToList().Contains(cmd));
            }

            _answers[index].Find(i => i.Item1 == cmd).Item2.Invoke();
        }
    }
}