using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class NetherRealms
{
    static void Main()
    {
        var input = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

        var demons = new Dictionary<string, Dictionary<double, double>>();

        for (int i = 0; i < input.Length; i++)
        {
            var damagePattern = @"(-?[0-9]+\.[0-9]+|-?[\d]+)";
            var healthPattern = @"[^0-9-+.*\/]";

            var numbers = Regex.Matches(input[i], damagePattern);
            var letterAndSymbols = Regex.Matches(input[i], healthPattern);

            var damage = 0d;
            var health = 0d;

            foreach (Match symbol in letterAndSymbols)
            {
                var currentSymbol = char.Parse(symbol.Value);
                health += currentSymbol;
            }

            damage = AddDamage(input, i, numbers, damage);

            demons.Add(input[i], new Dictionary<double, double>());
            demons[input[i]][health] = damage;
        }

        foreach (var demonData in demons.OrderBy(x => x.Key))
        {
            foreach (var kvp in demonData.Value)
            {
                Console.WriteLine($"{demonData.Key} - {kvp.Key} health, {kvp.Value:f2} damage");
            }
        }
    }

    private static double AddDamage(string[] input, int i, MatchCollection numbers, double damage)
    {
        foreach (Match number in numbers)
        {
            damage += double.Parse(number.Value);
        }

        foreach (var item in input[i])
        {
            if (item == '*')
            {
                damage *= 2;
            }

            if (item == '/')
            {
                damage /= 2;
            }
        }

        return damage;
    }
}

