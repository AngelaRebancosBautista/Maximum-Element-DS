using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'getMax' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts STRING_ARRAY operations as parameter.
     */

    public static List<int> getMax(List<string> operations)
    {
        Stack<int> stack = new Stack<int>();
        Stack<int> maxStack = new Stack<int>();
        List<int> result = new List<int>();

        foreach (string op in operations)
        {
            string[] parts = op.Split(' ');

            if (parts[0] == "1")
            {
                int value = int.Parse(parts[1]);
                stack.Push(value);

                if (maxStack.Count == 0 || value >= maxStack.Peek())
                    maxStack.Push(value);
                else
                    maxStack.Push(maxStack.Peek());
            }
            else if (parts[0] == "2") 
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                    maxStack.Pop();
                }
            }
            else if (parts[0] == "3") 
            {
                if (maxStack.Count > 0)
                    result.Add(maxStack.Peek());
            }
        }

        return result;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> ops = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string opsItem = Console.ReadLine();
            ops.Add(opsItem);
        }

        List<int> res = Result.getMax(ops);

        textWriter.WriteLine(String.Join("\n", res));

        textWriter.Flush();
        textWriter.Close();
    }
}
