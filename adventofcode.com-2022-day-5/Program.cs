using System;
using System.Collections.Generic;
using System.Collections;

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
            liste.Add(todos);

            return liste;
        }
        static Hashtable hashListCreator(List<List<string>> liste)
        {
            List<string> containers = liste[0];
            List<string> todos = liste[1];

            Hashtable hashtable = new Hashtable();
            List<List<char>> items = new List<List<char>>();



            for (int i = 0; i < (containers.Count); i++)
            {
                hashtable.Add(i, new List<List<char>>());
            }

            char[] helper;
            List<char> container = new List<char>();

            for (int i = 0; i < containers.Count; i++)
            {
                helper = containers[i].ToCharArray();
                for (int k = 0; k < helper.Length+1; k=k+4)
                {
                    if (helper[k] == '[')
                    {
                        container.Add(helper[k]);
                        container.Add(helper[k + 1]);
                        container.Add(helper[k + 2]);
                        if ((List<List<char>>)hashtable[k / 4]!=null)
                        {
                            items = (List<List<char>>)hashtable[k / 4];
                        }

                        items.Add(container);
                        hashtable[k / 4] = items;
                    }
                    container.Clear();
                }
            }
            return hashtable;
        }
        static void part1calculator(Hashtable hashtable, List<string> todos)
        {
            string splitter = " ";
            List<List<int>> numbers = new List<List<int>>();
            List<int> tryout = new List<int>();
            string[] str;


            List<List<char>> listTmp1 = new List<List<char>>();
            List<List<char>> listTmp2 = new List<List<char>>();

            int containerCount = 0;

            numbers.Clear();
            for (int i = 0; i < todos.Count; i++)
            {
                List<int> newlist = new List<int>();
                str = todos[i].Split(splitter, 6);
                newlist.Add(int.Parse(str[1]));
                newlist.Add(int.Parse(str[3]));
                newlist.Add(int.Parse(str[5]));
                numbers.Insert(i, newlist);
            }
            for (int i = 0; i < todos.Count; i++)
            {
                tryout = numbers[i];
                listTmp1 = (List<List<char>>)hashtable[tryout[2]-1];
                containerCount = tryout[i];
                listTmp2 = (List<List<char>>)hashtable[tryout[1]-1];
                for (int k = 0; k < containerCount; k++)
                {
                    listTmp1.Add(listTmp2[listTmp2.Count - 1]);
                    listTmp2.RemoveAt(listTmp2.Count - 1);
                    hashtable[tryout[2]-1] = listTmp1;
                    hashtable[tryout[1]-1] = listTmp2;
                }
                hashtable[tryout[2]-1] = listTmp1;
                hashtable[tryout[1]-1] = listTmp2;
            }
            for (int i = 0; i < hashtable.Count; i++)
            {
                Console.WriteLine(((List<List<char>>)hashtable[i])[0]);
            }
        }
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\0omer_ilhan\codeTestNewYear\adventofcode.com-2022-day-5\input.txt");

            List<List<string>> liste = inputSplitter(lines);

            part1calculator(hashListCreator(inputSplitter(lines)), liste[1]);

            Console.ReadLine();
        }
    }
}
