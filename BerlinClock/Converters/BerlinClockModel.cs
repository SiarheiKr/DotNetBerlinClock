using System;
using System.Collections.Generic;
using System.Linq;
using BerlinClock.Bulbs;
using BerlinClock.Core;

namespace BerlinClock.Converters
{
    internal sealed class BerlinClockModel
    {
        private const int NumberOfBigHoursBulbs = 4;
        private const int NumberOfHoursBulbs = 4;
        private const int HoursPerBigHour = 5;

        private const int NumberOfBigMinutesBulbs = 11;
        private const int NumberOfMinutesBulbs = 4;
        private const int MinutesPerBigMinute = 5;

        private const int SecondsBulbBlinkingRepetitiveness = 2;

        private readonly BerlinTime _berlinTime;

        public BerlinClockModel()
        {
            _berlinTime = new BerlinTime(HoursPerBigHour, MinutesPerBigMinute, SecondsBulbBlinkingRepetitiveness);

            SecondsBulb = CreateBulbs<SecondsBulb>(1).Single();

            BigHoursBulbs = CreateBulbs<BigHourBulb>(NumberOfBigHoursBulbs);
            HoursBulbs = CreateBulbs<HourBulb>(NumberOfHoursBulbs);

            BigMinutesBulbs = CreateBulbs<BigMinuteBulb>(NumberOfBigMinutesBulbs);
            MinutesBulbs = CreateBulbs<MinuteBulb>(NumberOfMinutesBulbs);
        }

        private IEnumerable<BulbBase> CreateBulbs<T>(int numberOfBulbs) where T : BulbBase, new()
        {
            return Enumerable.Range(0, numberOfBulbs).Select(_ =>
            {
                var bulb = new T();
                bulb.Initialize(_berlinTime, (byte)_);

                return bulb;
            });
        }

        internal void UpdateTime(TimeSpan time)
        {
            _berlinTime.Update(time);
        }

        internal BulbBase SecondsBulb { get; }

        internal IEnumerable<BulbBase> BigHoursBulbs { get; }

        internal IEnumerable<BulbBase> HoursBulbs { get; }

        internal IEnumerable<BulbBase> BigMinutesBulbs { get; }

        internal IEnumerable<BulbBase> MinutesBulbs { get; }
    }
}

