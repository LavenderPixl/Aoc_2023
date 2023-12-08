using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day1
    {
        string[] input = File.ReadAllLines("../../../Day_1/Day1Input.txt");
        string[] testInput = { "two1nine", "eightwothree" };
        #region Day 1 - Part 1
        string collection;
        int result;
        #endregion
        public Day1()
        {
            // DAY - 1
            foreach (var line in input)
            {
                List<char> chars = new List<char>();

                //Converts the (string) line into a Char Array.
                char[] charArray = line.ToCharArray();
                foreach (var item in charArray)
                {
                    //Checks if each Char in the Array is a number, and then Adds them to a char list.
                    if (Char.IsNumber(item))
                    {
                        chars.Add(item);
                    }
                }
                //Seperates with a comma.
                collection += chars[0].ToString() + "" + chars[chars.Count() - 1].ToString() + ",";
            }
            string[] resArr = collection.Split(',');
            foreach (var item in resArr)
            {
                Int32.TryParse(item, out int val);
                result += val;
            }
            Console.WriteLine("Day 1, Part 1: " + result);
            //END OF DAY 1


            //DAY - 2
            var sum = new List<int>();
            foreach (var item in input)
            {
                var replaced = item;
                replaced = replaced
                    .Replace("one", "one1one")
                    .Replace("two", "two2two")
                    .Replace("three", "three3three")
                    .Replace("four", "four4four")
                    .Replace("five", "five5five")
                    .Replace("six", "six6six")
                    .Replace("seven", "seven7seven")
                    .Replace("eight", "eight8eight")
                    .Replace("nine", "nine9nine");
                var numbers = replaced.ToCharArray().Where(x => char.IsNumber(x)).ToList();
                sum.Add(int.Parse($"{numbers[0]}{numbers[numbers.Count - 1]}"));
            }
            Console.WriteLine("Day 1, Part 2: "+sum.Sum());
        }
    }
}
