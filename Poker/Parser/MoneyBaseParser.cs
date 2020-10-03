using System;
using System.Linq;

namespace Parser
{
    public class MoneyBaseParser
    {
        public double Parse(string line, char separator)
        {
            if (!line.Contains(separator))
                return 0;

            var separatorIndex = line.IndexOf(separator);
            var subLine = line.Substring(separatorIndex, line.Length - separatorIndex);

            var firstIndexOfNumber = subLine.ToList().FindIndex(char.IsNumber);
            var lastIndexOfNumber = subLine.ToList().FindLastIndex(char.IsNumber);

            var money = Convert.ToDouble(subLine.Substring(firstIndexOfNumber, lastIndexOfNumber - firstIndexOfNumber + 1));

            return money;
        }
    }
}