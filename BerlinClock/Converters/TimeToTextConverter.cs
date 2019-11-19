using System;
using System.Collections.Generic;
using System.Text;
using BerlinClock.Helpers;
using BerlinClock.Core;

namespace BerlinClock.Converters
{
    public class TimeToTextConverter : ITimeConverter
    {
        private readonly BerlinClockModel _clock;

        public TimeToTextConverter()
        {
            _clock = new BerlinClockModel();
        }

        public string ConvertTime(string aTime)
        {
            if (!ExtendedTimeParser.TryParse(aTime, out TimeSpan dayTime))
            {
                throw new ArgumentException($"Failed to parse {aTime} as a time string.", nameof(aTime));
            }

            _clock.UpdateTime(dayTime);

            var berlinTime = new StringBuilder();
            PrintBulb(berlinTime, _clock.SecondsBulb);
            berlinTime.AppendLine();
            PrintBulbs(berlinTime, _clock.BigHoursBulbs);
            berlinTime.AppendLine();
            PrintBulbs(berlinTime, _clock.HoursBulbs);
            berlinTime.AppendLine();
            PrintBulbs(berlinTime, _clock.BigMinutesBulbs);
            berlinTime.AppendLine();
            PrintBulbs(berlinTime, _clock.MinutesBulbs);

            return berlinTime.ToString();
        }

        private static void PrintBulbs(StringBuilder output, IEnumerable<BulbBase> bulbs)
        {
            foreach (var bulb in bulbs)
            {
                PrintBulb(output, bulb);
            }
        }

        private static void PrintBulb(StringBuilder output, BulbBase bulb)
        {
            output.Append(GetBulbLetter(bulb));
        }

        private static string GetBulbLetter(BulbBase bulb)
        {
            if (!bulb.IsOn)
                return "O";

            switch (bulb.Color)
            {
                case BulbColor.Red:
                    return "R";
                case BulbColor.Yellow:
                    return "Y";
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}
