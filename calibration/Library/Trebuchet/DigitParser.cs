using System.Collections.Generic;
using System.Linq;

namespace WeatherMachine.Library.Trebuchet
{
    interface DigitParser
    {
        int[] Parse(string text);
    }
    internal class TextDigitParser : DigitParser
    {
        record Token (string token, int Value)
        {
            public int Length => token.Length;

            public bool IsNextIn(string text)
            {
                return text.StartsWith(token);
            }
        }

        public int[] Parse(string text)
        {
            List<int> result = new();
            List<Token> tokenList = new()
            {
                new Token("one", 1),
                new Token("two", 2),
                new Token("three", 3),
                new Token("four", 4),
                new Token("five", 5),
                new Token("six", 6),
                new Token("seven", 7),
                new Token("eight", 8),
                new Token("nine", 9)
            };

            int tokenLength = 1;

            for (int index = 0; index < text.Length; index += tokenLength)
            {
                tokenLength = 1;

                if (char.IsDigit(text[index]))
                {
                    result.Add(int.Parse(text[index] + ""));
                }
                else
                {
                    var currentText = text[index..];
                    var matchingToken = tokenList.SingleOrDefault(t => t.IsNextIn(currentText));

                    if(matchingToken != null)
                    {
                        result.Add(matchingToken.Value);
                        // tokenLength = matchingToken.Length;
                    }
                }
            }

            return result.ToArray();
        }
    }
}