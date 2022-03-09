using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator2
{
    public class Calculator
    {
        public static int SumString(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
                return 0;

            string[] delimeters = new string[] { "\n", "," };

            if (s.StartsWith("//"))
            {
                string[] parts = s.Split('\n', 2);
                delimeters = delimeters.Concat(GetAdditionalDelimeters(parts[0])).ToArray();
                s = parts[1];
            }

            int[] numbers = s.Split(delimeters, StringSplitOptions.None)
                .Select(n => Int32.Parse(n))
                .Where(n => n <= 1000)
                .ToArray();

            if (numbers.Any(n => n < 0))
                throw new ArgumentException("Negative number present", nameof(s));

            return numbers.Sum();
        }

        private static IEnumerable<string> GetAdditionalDelimeters(string firstInputLine)
        {
            if (firstInputLine.Length > 3)
                return new string[] { firstInputLine[3..^1] };
            return new string[] { firstInputLine.Substring(2, 1) };
        }
    }
}
