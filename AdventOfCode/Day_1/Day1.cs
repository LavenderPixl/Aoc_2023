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
        #region Day 1 - Part 1
        string[] input = File.ReadAllLines("../../../Day_1/Day1Input.txt");
        string collection;
        int result;


        public Day1()
        {
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
        }
        #endregion
    }
}
