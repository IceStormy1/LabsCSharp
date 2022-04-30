using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace LabsCSharp.Laba6
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = GetSplitString("abcdef");
            var test2 = ArrayDiff(new int[] { 1, 2, 2, 2, 3 }, new int[] { 2 });
            var test3 = IsPrime(7);
            var test4 = IpsBetween("10.0.0.0", "10.0.0.50");
            var test5 = GetReadableTime(359999);
            var test6 = ValidParentheses("())(()");
            var test7 = Mix("fasdgahadfgasdf4124fadsg", "fdasga4r1lhldlfgpppery");
        }

        /// <summary>
        /// 6 уровень
        /// https://www.codewars.com/kata/515de9ae9dcfc28eb6000001/train/csharp
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string[] GetSplitString(string str)
        {
            var length = str.Length;
            var result = new List<string>(length);

            for (var i = 0; i < length; i++)
            {
                try
                {
                    var item = $"{str[i]}{str[++i]}";
                    result.Add(item);
                }
                catch (Exception)
                {
                    var item = $"{str[i - 1]}_";
                    result.Add(item);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// 6 уровень
        /// https://www.codewars.com/kata/523f5d21c841566fde000009/train/csharp
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int[] ArrayDiff(int[] a, int[] b) 
            => a.Where(x => !b.Contains(x)).ToArray();

        /// <summary>
        /// 6 уровень
        /// https://www.codewars.com/kata/5262119038c0985a5b00029f/train/csharp
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static bool IsPrime(int n)
        {
            if (n == 0 || n == 1)
                return false;

            var isPrime = true;

            for (var i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            return isPrime;
        }

        /// <summary>
        /// 5 уровень
        /// https://www.codewars.com/kata/526989a41034285187000de4/train/csharp
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static long IpsBetween(params string[] a)
        => Math.Abs(a
            .Select(b => b
                .Split('.')
                .Select(long.Parse)
                .Aggregate((c, d) => c * 256 + d))
            .Aggregate((e, f) => e - f));

        /// <summary>
        /// 5 уровень
        /// https://www.codewars.com/kata/52685f7382004e774f0001f7/train/csharp
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static string GetReadableTime(int seconds)
        => $"{seconds / 3600:d2}:{seconds / 60 % 60:d2}:{seconds % 60:d2}";

        /// <summary>
        /// 5 уровень
        /// https://www.codewars.com/kata/52774a314c2333f0a7000688/csharp
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ValidParentheses(string input)
        {
            var result = 0;
            Console.WriteLine(input);
            foreach (var symbol in input)
            {
                switch (symbol)
                {
                    case '(':
                        result++;
                        break;
                    case ')':
                        result--;
                        break;
                }

                if (result < 0)
                    return false;
            }

            return result == 0;
        }

        /// <summary>
        /// 4 уровень https://www.codewars.com/kata/525f4206b73515bffb000b21/train/csharp
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string Add(string a, string b) => $"{BigInteger.Parse(a) + BigInteger.Parse(b)}";

        #region 4 уровень https://www.codewars.com/kata/5629db57620258aa9d000014/
        /// <summary>
        /// 4 уровень
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static string Mix(string s1, string s2)
        {
            if (s1.Equals(s2, StringComparison.Ordinal))
                return string.Empty;

            var s1Info = GetDifferenceFromStringInfo(CountLowercaseSymbols(s1), "1");
            var s2Info = GetDifferenceFromStringInfo(CountLowercaseSymbols(s2), "2");

            var results = MergeDifferences(s1Info, s2Info).Select(difference =>
                $"{difference.Identifier}:{new string(difference.Symbol, difference.Count)}");

            return string.Join("/", results);
        }

        private static IEnumerable<Difference> MergeDifferences(params IEnumerable<Difference>[] differences) =>
            differences
                .SelectMany(enumerable => enumerable)
                .Where(difference => difference.Count > 1)
                .GroupBy(difference => difference.Symbol,
                    (_, enumerable) =>
                    {
                        var local = enumerable
                                    .OrderByDescending(difference => difference.Count)
                                    .ToArray();

                        var maxCount = enumerable.First().Count;

                        var taked = local.TakeWhile(difference => difference.Count == maxCount);

                        var first = local.First();
                        if (taked.Count() > 1)
                            first.Identifier = Difference.EqualityIdentifier;

                        return first;
                    })
                .OrderByDescending(difference => difference.Count)
                .ThenBy(difference => difference.Identifier, StringComparer.Ordinal)
                .ThenBy(difference => difference.Symbol);


        private static IEnumerable<Difference> GetDifferenceFromStringInfo(Dictionary<char, int> info,
            string identifier)
            => info.Select(arg => new Difference
            {
                Identifier = identifier,
                Symbol = arg.Key,
                Count = arg.Value
            });


        private static Dictionary<char, int> CountLowercaseSymbols(string input)
            => input
                .Where(char.IsLower)
                .GroupBy(c => c)
                .Select(chars => new
                {
                    Symbol = chars.Key,
                    Count = chars.Count()
                })
                .ToDictionary(arg => arg.Symbol, arg => arg.Count);


        private sealed class Difference
        {
            public const string EqualityIdentifier = "=";

            public string? Identifier { get; set; }
            public char Symbol { get; set; }
            public int Count { get; set; }
        }
        #endregion
    }
}
