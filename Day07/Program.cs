using Utilities;

const int nrDays = 256;

string input = InputHelper.GetSingleLine("input.txt");
ulong[] fishes = new ulong[10];
int[] startingFishes = input.Split(',').Select(int.Parse).ToArray();
ulong dyingFishes = 0;

for (int i = 0; i < startingFishes.Length; i++)
{
    fishes[startingFishes[i]] += 1;
}

for (int i = 0; i < nrDays; i++)
{
    Array.Copy(fishes, 1, fishes, 0, fishes.Length - 1);

    fishes[6] += fishes[8] += dyingFishes;
    dyingFishes = fishes[0];
}

Console.WriteLine($"Nr of fishes after {nrDays} days: {fishes.Aggregate((a, c) => a + c)}");