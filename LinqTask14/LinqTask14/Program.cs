using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace LinqTask14
{
    class Program
    {
        static void Main()
        {
            var lines = new List<string>
            {
                "А, а, а, б, в, г",
                "У у У у У",
                "э ю я"
            };

            foreach (var (key, value) in GetDictionaryOfVowelCounts(lines))
            {
                Console.WriteLine("{0} - {1}", key, value);
            }

            var dataBase = new List<Record>();

            foreach (var strs in File.ReadAllLines("db.txt"))
            {
                var data = strs.Split();
                var record = new Record()
                {
                    ClientID = int.Parse(data[0]),
                    Year = int.Parse(data[1]),
                    Month = int.Parse(data[2]),
                    Duration = int.Parse(data[3])
                };
                dataBase.Add(record);
            }

            PrintRarestVisitingMonths(1, dataBase);
            Console.ReadKey();
        }

        private static Dictionary<char, int> GetDictionaryOfVowelCounts(IEnumerable<string> lines)
        {
            return new[] { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' }
                .ToDictionary(letter => letter, letter => lines
                    .SelectMany(s => s.ToLower().Split())
                    .Where(word => word[0] == letter)
                    .Count(word => word[0] == letter));
        }

        private static void PrintRarestVisitingMonths(int client, IEnumerable<Record> dataBase)
        {
            var rarestRecords = dataBase
                .Where(r => r.ClientID == client)
                .GroupBy(r => r.Year)
                .Select(g => g
                    .OrderBy(r => r.Duration)
                    .ThenByDescending(r => r.Month)
                    .First())
                .ToList();

            if (rarestRecords.Any())
            {
                foreach (var r in rarestRecords)
                    Console.WriteLine($" В {r.Year} году продолжительность занятий составила {r.Duration} часов в {r.Month} месяце");
            }
            else
                Console.WriteLine("Данные о клиенте отсутствуют.");
        }
    }
}