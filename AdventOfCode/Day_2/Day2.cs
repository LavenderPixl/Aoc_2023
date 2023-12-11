using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day_2
{
    public class Day2
    {
        string[] input = File.ReadAllLines("../../../Day_2/Day2Input.txt");
        //string[] input = {"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
        //                  "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
        //"Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
        //    "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
        //"Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"};
        int maxRed = 12;
        int maxGreen = 13;
        int maxBlue = 14;
        int validGames = 0;

        public Day2()
        {
            foreach (var game in input)
            {
                int rColor = 0;
                int gColor = 0;
                int bColor = 0;
                bool isValid = true;

                //Gives us the Id of the game (Will be used later, to get the final result.)
                Int32.TryParse(game.Split(":")[0].Split(" ")[1], out int gameId);

                //Gets the specific set
                foreach (var set in game.Split(": ")[1].Split(";"))
                {
                    foreach (var cube in set.Split(", "))
                    {
                        //Splits the Number from the color.
                        string[] singular = cube.TrimStart().Split(' ');

                        //Checks the color.
                        if (singular[1] == "blue")
                        {
                            Int32.TryParse(cube.TrimStart().Split(" ")[0], out int blue);
                            bColor = blue;
                        }
                        if (singular[1] == "red")
                        {
                            Int32.TryParse(cube.TrimStart().Split(" ")[0], out int red);
                            rColor = red;
                        }
                        if (singular[1] == "green")
                        {
                            Int32.TryParse(cube.TrimStart().Split(" ")[0], out int green);
                            gColor = green;
                        }
                        if (bColor > maxBlue || rColor > maxRed || gColor > maxGreen)
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                if (isValid)
                {
                    validGames += gameId;
                }
            }
            Console.WriteLine($"Day 2, Part 1: {validGames}"); ///2551



            //Day 2, Part 2. 
            //The power of a set of cubes is equal to the numbers of red, green, and blue cubes multiplied together.
            //For each game, find the minimum set of cubes that must have been present. What is the sum of the power of these sets?

            int result = 0;
            int endValue = 0;
            foreach (var game in input)
            {
                int rColor = 0;
                int gColor = 0;
                int bColor = 0;

                //Gets the specific set
                foreach (var set in game.Split(": ")[1].Split(";"))
                {
                    foreach (var cube in set.Split(", "))
                    {
                        //Splits the Number from the color.
                        string[] singular = cube.TrimStart().Split(' ');

                        //Checks the color.
                        if (singular[1] == "blue")
                        {
                            Int32.TryParse(cube.TrimStart().Split(" ")[0], out int blue);
                            bColor = compareColor(blue, bColor);
                        }
                        if (singular[1] == "red")
                        {
                            Int32.TryParse(cube.TrimStart().Split(" ")[0], out int red);
                            rColor = compareColor(red, rColor);
                        }
                        if (singular[1] == "green")
                        {
                            Int32.TryParse(cube.TrimStart().Split(" ")[0], out int green);
                            gColor = compareColor(green, gColor);
                        }
                    }
                }
                result = rColor * gColor * bColor;
                endValue += result;
            }
            Console.WriteLine($"Day 2, Part 2: {endValue}"); ///2551
        }

        /// <summary>
        /// Compares the first number given, to the second.
        /// </summary>
        /// <param name="currentNumber"></param>
        /// <param name="comparedNumber"></param>
        /// <returns>Returns the higher number.</returns>
        int compareColor(int currentNumber, int comparedNumber)
        {
            if (currentNumber < comparedNumber)
            {
                currentNumber = comparedNumber;
                return currentNumber;
            }
            else
            {
                return currentNumber;
            }
        }
    }
}
