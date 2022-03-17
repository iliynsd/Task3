using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Task3.Application;

namespace Task3.Utils
{
    public static class BotConfig
    {
        public static List<Command> SetCommands()
        {
            List<Command> correctInputs = new List<Command>();
            
            foreach (var command in GetCommands())
            {
                var commands = command.Elements().Select(i => i.Name.LocalName.Replace('_',' ')).ToList();
                correctInputs.Add(new Command(){CommandName = command.Name.LocalName, CorrectInputs = commands});
            }

            return correctInputs;
        }

        public static List<Command> SetAnswers()
        {
            List<Command> answers = new List<Command>();
            
            foreach (var command in GetCommands())
            {
                var commands = command.Elements().ToList().FindAll(i => i.Value != String.Empty).Select(i => i.Value).ToList();
                answers.Add(new Command(){CommandName = command.Name.LocalName, CorrectInputs = commands});
            }

            return answers;
        }
        
        private static IEnumerable<XElement> GetCommands() => XDocument.Load("Resources\\botConfig.xml").Element("commands")?.Elements();
    }
}