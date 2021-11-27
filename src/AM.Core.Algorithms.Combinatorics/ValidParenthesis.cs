using System;
using System.Collections.Generic;

namespace AM.Core.Algorithms.Combinatorics;

public class ValidParenthesis
{
    public static IList<string> GenerateParenthesis(int n)
    {
        IList<string> result = new List<string>();
        GetValidPermuations(result, string.Empty, n, n);

        return result;
    }

    private static void GetValidPermuations(IList<string> result, string match, int openingBracesToAdd, int closingBracesToAdd)
    {
        if (openingBracesToAdd == 0 && closingBracesToAdd == 0)
            result.Add(match);

        if (openingBracesToAdd > 0)
            GetValidPermuations(result, match + "(", openingBracesToAdd - 1, closingBracesToAdd);

        if (closingBracesToAdd > openingBracesToAdd)
            GetValidPermuations(result, match + ")", openingBracesToAdd, closingBracesToAdd - 1);
    }
}