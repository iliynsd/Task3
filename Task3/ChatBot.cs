using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public class ChatBot
    {
        private List<List<string>> _correctInputs;
        private List<List<string>> _answers;
        private List<string> _notUsedCommands = new List<string>();
        private Dictionary<int, Func<string>> _functional;

        public ChatBot()
        {
            _correctInputs = new List<List<string>>()
            {
                new List<string>()
                {
                    "Привет", "Здраствуй", "Здраствуйте", "Добрый день", "Добрый вечер", "Доброе утро", "Доброй ночи"
                },
                new List<string>()
                {
                    "Как тебя зовут?"
                },
                new List<string>()
                {
                    "Анекдот"
                },
                new List<string>()
                {
                    "Который час?", "Сколько времени?"
                },
                new List<string>()
                {
                    "Пока", "До свидания"
                }
            };
            _answers = new List<List<string>>()
            {
                new List<string>()
                {
                    "Привет", "Здраствуй", "Здраствуйте", "Добрый день", "Добрый вечер", "Доброе утро", "Доброй ночи"
                },
                new List<string>()
                {
                    "Шарпик"
                },
                new List<string>()
                {
                    "Купил мужик диван. Тащит через лестничную дверь в квартиру, Диван застрял, на площадку выходит сосед. - Слушай, сосед, помоги протащить этот чертов диван. Стали тащить вдвоем. Пыхтят, упираются, диван ни с места. Тот, кто купил: - Ладно, хватит. Чувствую, мы его никогда не втащим. Сосед: - Втащим?..."
                },
                new List<string>()
                {
                    $"Время - {DateTime.Now:t}"
                },
                new List<string>()
                {
                    "Пока", "До свидания"
                },
                new List<string>()
                {
                    "Каждый слышит только то, что он понимает"
                }
            };
            _functional = new Dictionary<int, Func<string>>()
            {
                {0, Greet},
                {1, TellName},
                {2,TellJoke},
                {3, TellTheTime},
                {4, TellGoodBye},
                {-1, TellAphorism}
            };
            _correctInputs.ForEach(i => i.ForEach(i => _notUsedCommands.Add(i)));
        }
        
        public string Greet() => _answers[0][new Random().Next(0, _answers[0].Count)];
        
        public string TellName() => _answers[1][new Random().Next(0, _answers[1].Count)];
        
        public string TellJoke() => _answers[2][new Random().Next(0, _answers[2].Count)];

        public string TellTheTime() => _answers[3][new Random().Next(0, _answers[3].Count)];

        public string TellGoodBye() => _answers[4][new Random().Next(0, _answers[4].Count)];
        
        public string TellAphorism() => _answers[5][new Random().Next(0, _answers[5].Count)];

        public string Answer(string cmd)
        {
            var index = _correctInputs.FindIndex(i => i.Select(i => i).ToList().Contains(cmd));
            if (index > -1)
            {
                _correctInputs[index].ForEach(i => _notUsedCommands.Remove(i));
            }
            
            return _functional[index].Invoke();
        }

        public bool IsStop(string cmd) => _correctInputs.FindIndex(i => i.Select(i => i).ToList().Contains(cmd)) == 4;
        public List<string> GetNotUsedCommands() => _notUsedCommands;
    }
}