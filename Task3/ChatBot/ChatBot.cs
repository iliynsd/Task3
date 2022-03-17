using System;
using System.Collections.Generic;
using Task3.Application;
using Task3.Utils;

namespace Task3
{
    
    
    public class ChatBot
    {
        private List<Command> _correctInputs;
        private List<Command> _answers;
        private readonly Dictionary<string, Func<string, string>> _functional;

        public ChatBot()
        {
            _correctInputs = BotConfig.SetCommands();
            _answers = BotConfig.SetAnswers();
            
            _functional = new Dictionary<string, Func<string,string>>()
            {
                {"hello", Answer},
                {"name", Answer},
                {"jokes", Answer},
                {"aphorism", Answer},
                {"time", TellTheTime},
                {"goodbye", Answer},
            };
        }

        public string Answer(string commandName)
        {
           var answers = _answers.Find(i => i.CommandName == commandName)?.CorrectInputs;
           return answers?[new Random().Next(0, answers.Count)];
        }
        public string TellTheTime(string time) =>  "Время - " + DateTime.Now.ToString("t");
        
        public string GetAnswer(string cmd)
        {
            var commandName = _correctInputs.Find(i => i.CorrectInputs.Contains(cmd.ToLower()))?.CommandName;
            if (commandName != null)
                return _functional[commandName].Invoke(commandName);
            
            return _functional["aphorism"].Invoke("aphorism");
        }

        public bool IsStop(string cmd) => _correctInputs.Find(i => i.CorrectInputs.Contains(cmd.ToLower()))?.CommandName == "goodbye";

        public List<string> GetCommands()
        {
            var cmds = new List<string>();
            _correctInputs.ForEach(i => i.CorrectInputs.ForEach(cmds.Add));
            return cmds;
        }  
    }
}