using System.Collections.Generic;

namespace SimplyCalculator_v2.InputParser
{
    public interface IInputParserService
    {
        List<string> ParseToList(string userInput);
        void SetOperatorsToSeperate(char[] seperators);
    }
}