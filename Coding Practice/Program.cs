using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Transactions;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public static void Main(string[] args)
    {
        //int test = solution(1610612737);
        //int test2 = solution(6291457);
        //int test3 = solution(66561);
        //int[] test4 = solution2(new int[] { 1, 2, 3, 4 }, 3);
        //Console.WriteLine(test3);
        //foreach (var i in test4)
        //{
        //    Console.WriteLine(i);
        //}
        int[] test = { 3,1,2,4,3 };
        Console.WriteLine(solution6(test));

    }
    public static int solution(int N)
    {
        int max = 0;
        int currentGap = 0;
        bool opened = false;
        string binary = Convert.ToString(N, 2);
        foreach (char c in binary)
        {
            if (c == '1')
            {
                if (!opened)
                {
                    opened = true;
                }
                else
                {
                    if (currentGap > max)
                    {
                        max = currentGap;
                    }
                    currentGap = 0;
                }
            }
            else if (opened)
            {
                currentGap++;
            }
        }
        return max;
    }
    public static int[] solution2(int[] A, int K)
    {   
        if (A.Length == 0) { return new int[] {}; }
        var list = A.ToList();
        for (int i = 0; i < K; i++)
        {
            var removed = list.Last();
            list.Insert(0, removed);
            list.RemoveAt(list.Count - 1);
        }
        return list.ToArray();
    }
    public int solution3(int[] A)
    {
        var clone = A;
        var dict = new Dictionary<int, int>();
        var output = 0;
        foreach (var i in clone)
        {   
            if (dict.ContainsKey(i))
            {
                dict[i] += 1;
            }
            else
            {
                dict.Add(i, 1);
            }
        }
        foreach (var i in dict)
        {
            if (i.Value % 2 == 1)
            {
                output = i.Key;
            }
        }
        return output;
    }

    public int solution4(int X, int Y, int D)
    {
        int rem = (Y - X) % D;
        int jumps = (Y - X - rem) / D;
        if (rem != 0)
        {
            jumps++;
        }
        return jumps;
    }

    public static int solution5(int[] A)
    {
        long sum = A.Sum(v => (long)v);
        return (int)((((long)A.Length + 2) * ((long)A.Length + 1) / 2) - sum);
    }

    public static int solution6(int[] A)
    {
        int min = -1;
        for (int P = A.Length - 1; P >= 1; P--)
        {
            var diff = Math.Abs(A.Sum() - 2 * A.Take(P).Sum());
            if (min < 0 || min > diff)
            {
                min = diff;
            }
        }
        return min;
    }

}
