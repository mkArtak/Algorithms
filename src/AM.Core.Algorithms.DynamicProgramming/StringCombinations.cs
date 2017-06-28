using System;
using System.Collections.Generic;
using System.Linq;

namespace AM.Core.Algorithms.DynamicProgramming
{
    public static class StringCombinations
    {
        public static string[] GetCombinations(string[] map)
        {
            if (map == null)
            {
                throw new ArgumentNullException(nameof(map));
            }

            IList<string> result = new List<string>();
            GetCombinationsForLevel(map, string.Empty, 0, result);

            return result.ToArray();
        }

        private static void GetCombinationsForLevel(string[] map, string prefix, int currentLevel, IList<string> results)
        {
            if (currentLevel == map.Length)
            {
                if (prefix != string.Empty)
                    results.Add(prefix);

                return;
            }

            foreach (char currentCharToVariateWith in map[currentLevel])
            {
                GetCombinationsForLevel(map, prefix + currentCharToVariateWith, currentLevel + 1, results);
            }
        }
    }
}
