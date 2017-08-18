using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class RoliTheCoder
{
    static void Main()
    {
        var idAndEventPattern = @"^(?<id>\d+)\s#(?<event>.+?)(?=\s|$)";
        var participantPattern = @"@(?<participants>.+?(?=\s|$))";

        var eventsData = new Dictionary<int, Dictionary<string, HashSet<string>>>();

        var input = Console.ReadLine();

        while (input != "Time for Code")
        {
            var idEvent = Regex.Match(input, idAndEventPattern);
            var participantsMatched = Regex.Matches(input, participantPattern);

            if (idEvent.Success)
            {
                var id = int.Parse(idEvent.Groups["id"].Value);
                var eventName = idEvent.Groups["event"].Value;
                var participants = participantsMatched.Cast<Match>().Select(match => match.Value).ToList();

                if (!eventsData.ContainsKey(id))
                {
                    eventsData[id] = new Dictionary<string, HashSet<string>>();
                    eventsData[id][eventName] = new HashSet<string>();
                }

                if (eventsData.ContainsKey(id) && eventsData[id].ContainsKey(eventName))
                {
                    for (int i = 0; i < participants.Count; i++)
                    {
                        eventsData[id][eventName].Add(participants[i]);
                    }
                }
            }            

            input = Console.ReadLine();
        }

        var data = new Dictionary<string, HashSet<string>>();

        foreach (var item in eventsData)
        {
            foreach (var eventData in item.Value)
            {
                data.Add(eventData.Key, eventData.Value);
            }
        }

        var orderData = data
            .Distinct()
            .OrderByDescending(x => x.Value.Count)
            .ThenBy(k => k.Key)
            .ToDictionary(k => k.Key, k => k.Value);

        foreach (var item in orderData)
        {
            Console.WriteLine($"{item.Key} - {item.Value.Count}");

            foreach (var participant in item.Value.OrderBy(x => x))
            {
                Console.WriteLine(participant);
            }
        }
        
    }
}

