﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day_4
{
    internal class Day4
    {
        string[] testString =
        {
            "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
            "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
            "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
            "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
            "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
            "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"
        };

        string[] input = File.ReadAllLines("../../../Day_4/Day4Input.txt");

        int finalScore; // Needs to be 26426

        public Day4()
        {
            foreach (var line in input)
            {
                string id = line.Split(":")[0].Split(" ")[1];
                string winningNumbers = line.Split(":")[1].Split("|")[0];
                string userNumbers = line.Split(":")[1].Split("|")[1];

                string[] w = winningNumbers.Trim().Split(" ");
                string[] u = userNumbers.Trim().Split(" ");

                int score = 0;
                foreach (var number in w)
                {
                    if (number != "")
                    {
                        if (u.Contains(number))
                        {
                            if (score > 0)
                            {
                                score *= 2;
                            }
                            else
                            {
                                score = 1;
                            }
                        }
                    }
                }

                finalScore += score;
                //Console.WriteLine(id + " " + score + " " + finalScore);
            }

            Console.WriteLine("Day 4, Part 1: " + finalScore);
            
            //Day 4 - Part 2.
            foreach (var line in input)
            {
                string id = line.Split(":")[0].Split(" ")[1];
                string winningNumbers = line.Split(":")[1].Split("|")[0];
                string userNumbers = line.Split(":")[1].Split("|")[1];

                string[] w = winningNumbers.Trim().Split(" ");
                string[] u = userNumbers.Trim().Split(" ");
                
                int score = 0;
                foreach (var number in w)
                {
                    if (number != "")
                    {
                        if (u.Contains(number))
                        {
                            
                        }
                    }
                }
            }
            
            
        }
    }
}