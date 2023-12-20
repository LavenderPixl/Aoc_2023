using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Day_3
{
    internal class Day3
    {
        //Each line has 140 characters.
        string[] _input = File.ReadAllLines("../../../Day_3/Day3Input.txt");
        // string[] _input =
        // {
        //     "467..114..", "...*.../..", "..35..633.", "......#...", "617*......", ".....+.58.", "..592.....",
        //     "......755.",
        //     "...$.*....", ".664.598.."
        // };

        private int _row = 0;
        private ObservableCollection<Numbers> _valueCollection = new ObservableCollection<Numbers>();
        private ObservableCollection<Numbers> _symbolCollection = new ObservableCollection<Numbers>();
        private ObservableCollection<int> _finalCollection = new ObservableCollection<int>();

        public Day3()
        {
            foreach (var line in _input)
            {
                Regex numberCheck = new Regex(@"\d+");
                // Regex symbolCheck = new Regex(@"[^.-A-Za-z0-9_ \s=]");
                Regex symbolCheck = new Regex(@"[^a-zA-Z0-9\.\s]");
                foreach (Match match in numberCheck.Matches(line))
                {
                    if (match.Success)
                    {
                        int index = match.Index;
                        // Console.WriteLine($"Start Index: {index}, Value: {match}");
                        _valueCollection.Add(new Numbers(index, match.ToString(), _row));
                    }
                }

                foreach (Match match in symbolCheck.Matches(line))
                {
                    if (match.Success)
                    {
                        int index = match.Index;
                        // Console.WriteLine($"Special letter! Index: {index}, Value: {match}");
                        _symbolCollection.Add(new Numbers(index, match.ToString(), _row));
                    }
                }

                _row++;
            }

            foreach (var numbers in _valueCollection)
            {
                int[] _numberRange = Enumerable.Range(numbers.StartIndex - 1, numbers.Value.Length + 2).ToArray();
                int check = 0;

                foreach (var symbols in _symbolCollection)
                {
                    if (numbers.Row == (symbols.Row - 1) || numbers.Row == symbols.Row ||
                        numbers.Row == (symbols.Row + 1))
                    {
                        int[] _symbolRange = Enumerable.Range(symbols.StartIndex, symbols.Value.Length)
                            .ToArray();

                        if (!_numberRange.Any(x => _symbolRange.Any(y => y == x)))
                        {
                            foreach (var symbol in _symbolCollection)
                            {
                                if (numbers.Row == (symbols.Row - 1) || numbers.Row == symbols.Row ||
                                    numbers.Row == (symbols.Row + 1))
                                {
                                    if (_numberRange.Any(x => _symbolRange.Any(y => y == x)))
                                    {
                                        check++;
                                        break;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            check++;
                            break;
                        }
                    }
                }

                if (check != 0)
                {
                    _finalCollection.Add(Convert.ToInt32(numbers.Value));
                }
            }

            int result = 0;
            foreach (var numb in _finalCollection)
            {
                result += numb;
            }

            Console.WriteLine(result);
        }
    }


    public class Numbers
    {
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int Row { get; set; }
        public string Value { get; set; }

        public Numbers(int start, string value, int row)
        {
            Value = value;
            StartIndex = start;
            EndIndex = GetEnd();
            Row = row;
        }

        private int GetEnd()
        {
            int end = StartIndex + Value.Length - 1;
            return end;
        }
    }
}