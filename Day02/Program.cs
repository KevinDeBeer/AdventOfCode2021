// See https://aka.ms/new-console-template for more information
using Utilities;

IEnumerable<string> input = InputHelper.GetTextInput("input.txt");

(int hor1, int ver1) = ProcessCommand(input, false);
Console.WriteLine($"Horizontal: {hor1}, Vertical: {ver1}, mult: {hor1 * ver1}");

(int hor2, int ver2) = ProcessCommand(input, true);
Console.WriteLine($"Horizontal: {hor2}, Vertical: {ver2}, mult: {hor2 * ver2}");

static (int, int) ProcessCommand(IEnumerable<string> input, bool useAim)
{
    int horizontal = 0, vertical = 0, aim = 0;

    foreach (string command in input)
    {
        string[] split = command.Split(' ');
        string direction = split[0];
        int distance = int.Parse(split[1]);

        switch (direction)
        {
            case "forward":
                horizontal += distance;
                vertical = useAim ? (vertical += aim * distance) : vertical;
                break;
            case "down":
                vertical += useAim ? 0 : distance;
                aim += useAim ? distance : 0;
                break;
            case "up":
                vertical -= useAim ? 0 : distance;
                aim -= useAim ? distance : 0;
                break;
            default:
                break;
        }
    }

    return (horizontal, vertical);
}