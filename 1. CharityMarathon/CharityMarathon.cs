using System;
using System.Collections.Generic;
using System.Linq;

class CharityMarathon
{
    static void Main()
    {
        var marathonDays = int.Parse(Console.ReadLine());
        var runnerCount = long.Parse(Console.ReadLine());
        var avrgNumberOfLaps = int.Parse(Console.ReadLine());
        var lengthOfTrack = long.Parse(Console.ReadLine());
        var capacityOfTrack = int.Parse(Console.ReadLine());
        var moneyPerKilometer = decimal.Parse(Console.ReadLine());

        var capacityForAllDays = marathonDays * capacityOfTrack;

        if (runnerCount > capacityForAllDays)
        {
            runnerCount = capacityForAllDays;
        }

        var totalMeters = runnerCount * avrgNumberOfLaps * lengthOfTrack;
        var totalKilometers = totalMeters / 1000;

        var allMoney = totalKilometers * moneyPerKilometer;

        Console.WriteLine($"Money raised: {allMoney:f2}");
    }
}

