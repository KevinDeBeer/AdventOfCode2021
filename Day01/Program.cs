// See https://aka.ms/new-console-template for more information
using Utilities;

List<int> depths = InputHelper.GetNumericInput("input.txt");
List<int> groupedDepths = BuildGroupedInts(depths);

Console.WriteLine($"Increased count: {TimesIncreased(depths)}");
Console.WriteLine($"Grouped increased count: {TimesIncreased(groupedDepths)}");

int TimesIncreased(List<int> depths)
{
    int increased = 0;

    for (int i = 0; i < depths.Count; i++)
    {
        if (i == depths.Count - 1)
        {
            break;
        }

        int nextDepth = depths.ElementAt(i + 1);

        increased = nextDepth > depths.ElementAt(i) ? ++increased : increased;
    }

    return increased;
}

List<int> BuildGroupedInts(List<int> depths)
{
    List<int> levels = new();

    for (int i = 0; i < depths.Count; i += 1)
    {
        int level = depths.Skip(i).Take(3).Sum();
        levels.Add(level);
    }

    return levels;
}