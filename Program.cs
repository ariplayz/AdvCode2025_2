using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvCode2025_2
{
    class Program
    {
        static List<List<long>> Parse(string input)
        {
            List<List<long>> output = new List<List<long>>();
            List<string> parts = input.Split(',').ToList();

            for (int i = 0; i < parts.Count; i++)
            {
                List<long> sublist = parts[i].Split('-').ToList().ConvertAll(long.Parse);
                output.Add(sublist);
            }

            return output;
        }

        static bool IsInvalidId(long id)
        {
            string idStr = id.ToString();
            int len = idStr.Length;
            
            for (int i = 1; i <= len / 2; i++)
            {
                if (len % i == 0)
                {
                    string repeatPattern = idStr.Substring(0, i);
                    int repeatCount = len / i;
                    string repeatedString = string.Concat(Enumerable.Repeat(repeatPattern, repeatCount));

                    if (repeatedString == idStr) return true;
                }
            }

            return false; // Not a repeated pattern
        }


        static int Main(string[] args)
        {
            Console.WriteLine("Paste console input:");
            string input = Console.ReadLine();
            
            List<List<long>> ranges = Parse(input);
            long sumOfInvalidIds = 0;
            
            foreach (var range in ranges)
            {
                long start = range[0];
                long end = range[1];
                
                for (long id = start; id <= end; id++)
                {
                    if (IsInvalidId(id))
                    {
                        sumOfInvalidIds += id;
                    }
                }
            }

            Console.WriteLine($"Sum of all invalid IDs: {sumOfInvalidIds}");
            return 0;
        }
    }
}
