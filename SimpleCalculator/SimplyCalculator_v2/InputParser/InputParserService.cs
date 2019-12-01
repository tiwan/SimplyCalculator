using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplyCalculator_v2.InputParser
{
    public class InputParserService : IInputParserService
    {
        private char[] operatorArray;

        public void SetOperatorsToSeperate(char[] seperators)
        {
            operatorArray = seperators;
        }

        public List<string> ParseToList(string userInput)
        {
            return  validateInput(parseInput(userInput));

        }

  


        private List<string> parseInput(string input)
        {
            var trimInput = input.Trim();

            return splitWithKeep(trimInput, operatorArray).ToList();
        }

        private IEnumerable<string> splitWithKeep(string input, char[] separators)
        {
            int start = 0;
            int index = 0;

            while ((index = input.IndexOfAny(separators, start)) != -1)
            {
                if (index - start > 0)
                    yield return input.Substring(start, index - start);

                yield return input.Substring(index, 1);

                start = index + 1;
            }

            if (start < input.Length)
            {
                yield return input.Substring(start);
            }
        }

        private List<string> validateInput(List<string> inputList)
        {
            if (inputList.Any() == false )
                throw new Exception("input is empty");

            if(operatorArray.Contains(inputList.First()[0]) || operatorArray.Contains(inputList.Last()[0]))
                throw new Exception("input not valid");

            foreach (var inputElemnt in inputList)
            {
                if (operatorArray.Contains(inputElemnt[0]))
                    continue;

                double param = 0;

                if(double.TryParse(inputElemnt, out param) == false)
                    throw new Exception("invalid expresion in input");

            }

            return inputList;

        }
    }
}
