using System.Collections.Generic;
using System.Linq;
using Game339.Shared.Diagnostics;

namespace Game339.Shared.Services.Implementation
{
    public class StringService : IStringService
    {
        private readonly IGameLog _log;

        public StringService(IGameLog log)
        {
            _log = log;
        }

        public string Reverse(string input)
        {
            var output = new string(input.Reverse().ToArray());
            _log.Info($"{nameof(StringService)}.{nameof(Reverse)} - {nameof(input)}: {input} - {nameof(output)}: {output}");
            return output;
        }

        public string ReverseWords(string input)
        {
            string output = "";

            (string text, bool isSeparator) currentWord = ("", false);

            foreach (char letter in input)
            {
                if (isWordSeparator(letter) != currentWord.isSeparator)
                {
                    currentWord.isSeparator = isWordSeparator(letter);
                    output = currentWord.text + output;
                    currentWord.text = "";
                }
                
                currentWord.text += letter;
            }
            
            return output;

            bool isWordSeparator(char c) => char.IsSeparator(c);
        }
    }
}