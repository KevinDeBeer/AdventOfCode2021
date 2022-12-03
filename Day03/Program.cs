using Utilities;
using System.Linq;

IEnumerable<string> input = InputHelper.GetTextInput("input.txt");

DecypherData(input);
void DecypherData(IEnumerable<string> input)
{
    int wordLength = input.ElementAt(0).Length;
    List<List<char>> chars = new();

    for (int i = 0; i < wordLength; i++)
    {
        List<char> perIndex = new();

        for (int j = 0; j < input.Count(); j++)
        {
            char bit = input.ElementAt(j)[i];
            perIndex.Add(bit);
        }

        chars.Add(perIndex);
    }

    string binaryMostOccurences = string.Empty;
    string binaryLeastOccurences = string.Empty;

    for (int i = 0; i < wordLength; i++)
    {
        IEnumerable<IGrouping<char, char>> grouped = chars.ElementAt(i).GroupBy(x => x);
        IEnumerable<IGrouping<char, char>> ordered = grouped.OrderByDescending(x => x.Count());
        char mostUsed = ordered.First().Key;
        char leastUsed = ordered.Last().Key;

        binaryMostOccurences += mostUsed;
        binaryLeastOccurences += leastUsed;
    }

    int most = Convert.ToInt32(binaryMostOccurences, 2);
    int least = Convert.ToInt32(binaryLeastOccurences, 2);
    Console.WriteLine($"Most: {most}, least: {least}, answer {most * least}");
}