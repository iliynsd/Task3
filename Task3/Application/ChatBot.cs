using System;
using System.Collections.Generic;
using System.Linq;
using Task3.Utils;

namespace Task3
{
    public class ChatBot
    {
        private List<List<string>> _correctInputs;
        private List<List<string>> _answers;
        private List<string> _notUsedCommands = new List<string>();
        private readonly Dictionary<int, Func<string>> _functional;

        public ChatBot()
        {
            _correctInputs = BotConfig.SetCommands();
            _answers = BotConfig.SetAnswers();
            
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

        public string TellTheTime() => _answers[3][new Random().Next(0, _answers[3].Count)] + DateTime.Now.ToString("t");

        public string TellGoodBye() => _answers[4][new Random().Next(0, _answers[4].Count)];
        
        public string TellAphorism() => _answers[5][new Random().Next(0, _answers[5].Count)];

        public string Answer(string cmd)
        {
            var index = _correctInputs.FindIndex(i => i.Select(i => i).ToList().Contains(cmd.ToLower()));
            if (index > -1)
            {
                _correctInputs[index].ForEach(i => _notUsedCommands.Remove(i));
            }
            
            return _functional[index].Invoke();
        }

        public bool IsStop(string cmd) => _correctInputs.FindIndex(i => i.Select(i => i).ToList().Contains(cmd.ToLower())) == 4;
        
        public List<string> GetNotUsedCommands() => _notUsedCommands;
    }
}