using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class ChatBot
    {
        private List<List<Tuple<string, string>>> _answers;
        private List<string> _notUsedCommands = new List<string>();

        public ChatBot()
        {
            _answers = new List<List<Tuple<string, string>>>
        {
            new List<Tuple<string, string>>
            {
                new Tuple<string, string>("Привет",  "Привет"),
                new Tuple<string, string>("Здраствуй", "Здраствуй"),
                new Tuple<string, string>("Здраствуйте", "Здраствуйте"),
                new Tuple<string, string>("Добрый день", "Добрый день"),
                new Tuple<string, string>("Добрый вечер", "Добрый вечер"),
                new Tuple<string, string>("Доброе утро", "Доброе утро"),
                new Tuple<string, string>("Доброй ночи", "Доброй ночи")
            },
            new List<Tuple<string, string>>
            {
                new Tuple<string, string>("Как тебя зовут?", "Шарпик")
            },
            new List<Tuple<string, string>>
            {
                new Tuple<string, string>("Анекдот", "Купил мужик диван. Тащит через лестничную дверь в квартиру, Диван застрял, на площадку выходит сосед. - Слушай, сосед, помоги протащить этот чертов диван. Стали тащить вдвоем. Пыхтят, упираются, диван ни с места. Тот, кто купил: - Ладно, хватит. Чувствую, мы его никогда не втащим. Сосед: - Втащим?...")
            },
            new List<Tuple<string, string>>
            {
                new Tuple<string, string>("Который час?", $"Время - {DateTime.Now:t}"),
                new Tuple<string, string>("Сколько времени?", $"Время - {DateTime.Now:t}")
            },
            new List<Tuple<string, string>>
            {
                new Tuple<string, string>("Пока", "Пока"),
                new Tuple<string, string>("До свидания", "До свидания")
            },
            new List<Tuple<string, string>>
            {
                new Tuple<string, string>("", "Каждый слышит только то, что он понимает")
            },
        };
            _answers.ForEach(i => i.ForEach(i => _notUsedCommands.Add(i.Item1)));
        }
        
        public string AnswerChatBot(string cmd)
        {
            var index = _answers.FindIndex(i => i.Select(i => i.Item1).ToList().Contains(cmd));
            if (index < 0)
            {
                cmd = "";
                index = _answers.FindIndex(i => i.Select(i => i.Item1).ToList().Contains(cmd));
            }
            
            _answers[index].ForEach(i => _notUsedCommands.Remove(i.Item1));
            return _answers[index].Find(i => i.Item1 == cmd).Item2;
        }

        public bool IsStop(string cmd) => cmd == "Пока" || cmd == "До свидания";

        public List<string> GetNotUsedCommands() => _notUsedCommands;
    }
}