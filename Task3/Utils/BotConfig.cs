using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Task3.Utils
{
    public static class BotConfig
    {
        private static string PathToBotSettings => Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\Resources\\botConfig.xml"));

        public static List<List<string>> SetCommands()
        {
            List<List<string>> commands = new List<List<string>>();
            
            foreach (var command in GetCommands())
            {
                var commandNames = command.Elements().Select(i => i.Name.LocalName.Replace('_',' ')).ToList();
                commands.Add(commandNames);
            }

            return commands;
        }

        public static List<List<string>> SetAnswers()
        {
            List<List<string>> answers = new List<List<string>>();
            
            foreach (var command in GetCommands())
            {
                var answerNames = command.Elements().Select(i => i.Value).ToList();
                answers.Add(answerNames);
            }

            return answers;
        }
        
        private static IEnumerable<XElement> GetCommands() => XDocument.Load(PathToBotSettings).Element("commands")?.Elements();
    }
}