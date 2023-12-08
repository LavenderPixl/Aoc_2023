using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day_2
{
    public class Day2
    {
        //string[] input = File.ReadAllLines("../../../Day_2/Day2Input.txt");
        string[] input = {"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                          "Game 2: 1 blue, 2 green; green, 4 blue, 1 red; 1 green, 1 blue" };

        int maxRed = 12;
        int maxGreen = 13;
        int gColor;
        int maxBlue = 14;
        int bColor;
        int validGames;
        bool isValid = false;

        public Day2()
        {
            foreach (var game in input)
            {
                //Gives us the Id of the game (Will be used later, to get the final result.)
                Int32.TryParse(game.Split(":")[0], out int gameId);

                //Gets the specific set
                foreach (var set in game.Split(": ")[1].Split(";"))
                {
                    foreach (var cube in set.Split(", "))
                    {
                        //Splits the Number from the color.
                        string[] singular = cube.Split(' ');

                        //Checks the color.
                        if (singular[1] == "blue")
                        {
                            Int32.TryParse(cube.Split(" ")[0], out int blue);
                            bColor += blue;
                        }
                    }
                }
                if (true)
                {

                }
                if (isValid)
                {
                    validGames += gameId;
                }
            }
        }
    }
}
