using System;
using BerlinClock.Helpers;

namespace BerlinClock.Core
{
    internal sealed class BerlinTime
    {
        private readonly byte _hoursPerBigHour;
        private readonly byte _minutesPerBigMinute;
        private readonly byte _secondsRepetitiveness;

        internal BerlinTime(byte hoursPerBigHour, byte minutesPerBigMinute, byte secondsRepetitiveness)
        {
            Args.ThrowIfOutOfRange(hoursPerBigHour, nameof(hoursPerBigHour), 1, 24 / 2);
            Args.ThrowIfOutOfRange(minutesPerBigMinute, nameof(minutesPerBigMinute), 1, 60 / 2);
            Args.ThrowIfOutOfRange(secondsRepetitiveness, nameof(secondsRepetitiveness), 1, 60);
            
            _hoursPerBigHour = hoursPerBigHour;
            _minutesPerBigMinute = minutesPerBigMinute;
            _secondsRepetitiveness = secondsRepetitiveness;
        }

        internal void Update(TimeSpan time)
        {
            Args.ThrowIfOutOfRange(time.Ticks, nameof(time), 0, TimeSpan.TicksPerDay);

            var hours = (int)time.TotalHours;

            BigHours = hours / _hoursPerBigHour;
            Hours = hours % _hoursPerBigHour;

            BigMinutes = time.Minutes / _minutesPerBigMinute;
            Minutes = time.Minutes % _minutesPerBigMinute;

            IsSecondsOn = time.Seconds % _secondsRepetitiveness == 0;
        }

        internal bool IsSecondsOn { get; private set; }

        internal int BigHours { get; private set; }

        internal int Hours { get; private set; }

        internal int BigMinutes { get; private set; }

        internal int Minutes { get; private set; }
    }
}
