using System;
using System.Collections.Generic;

namespace adventofcode.com_2022_day_5
{
    class Program
    {
        static List<List<string>> inputSplitter(string[] lines)
        {
            List<List<string>> liste = new List<List<string>>();
            List<string> containers = new List<string>();
            List<string> stackNumbers = new List<string>();
            List<string> todos = new List<string>();
            int current = 0;


            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("move"))
                {
                    todos.Add(lines[i]);
                }
                else if (lines[i].Contains("1"))
                {
                    stackNumbers.Add(lines[i]);
                }

                else
                {
                    containers.Add(lines[i]);
                }
                current++;
            }
            containers.RemoveAt(containers.Count - 1);

            liste.Add(containers);
            liste.Add(stackNumbers);
            liste.Add(todos);

            return liste;
        }
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\0omer_ilhan\codeTestNewYear\adventofcode.com-2022-day-5\input.txt");

            inputSplitter(lines);




            Console.ReadLine();
        }
    }
}
