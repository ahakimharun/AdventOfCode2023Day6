string file = @"C:\Users\SaLiVa\source\repos\AdventOfCode2023Day6\AdventOfCode2023Day6\Day6InputP2.txt";

List<long> Times = [];
List<long> Distances = [];

using (StreamReader reader = File.OpenText(file))
{
    while (!reader.EndOfStream)
    {
        var line = reader.ReadLine();
        if (line.Contains("Time:"))
        {
            var timesString = line.Substring(line.IndexOf(":") + 1, line.Length - 1 - line.IndexOf(":")).Split(" ");
            foreach (var t in timesString)
            {
                if (t != "")
                    Times.Add(long.Parse(t));
            }

        }

        if (line.Contains("Distance:"))
        {
            var distanceString = line.Substring(line.IndexOf(":") + 1, line.Length - 1 - line.IndexOf(":")).Split(" ");
            foreach (var d in distanceString)
            {
                if (d != "")
                    Distances.Add(long.Parse(d));
            }

        }
    }
}

var Result = CalculateWinningScenarios(Times, Distances);
Console.WriteLine(Result);

long CalculateWinningScenarios(List<long> times, List<long> distances)
{
    var winRecord = 0;
    for (var i = 0; i < times.Count; i++)
    {
        var winRound = 0;
        // b represents the time button is pressed
        for (var b = 0; b < times[i]; b++)
        {
            // Speed is the 1:1 proportional to the amount of time the button is pressed
            var speed = b;
            var timeRemaining = times[i] - b;
            var distanceDriven = b * timeRemaining;
            winRound += distanceDriven > distances[i] ? 1 : 0;
        }
        // Part 1 calculation
        // if (winRecord == 0)
        //     winRecord = winRound;
        // else
        //     winRecord = winRecord * winRound;
        
        // Part 2 is a counter
        winRecord += winRound;
    }

    return winRecord;
}


