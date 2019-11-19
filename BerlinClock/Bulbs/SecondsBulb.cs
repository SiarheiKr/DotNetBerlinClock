using BerlinClock.Core;

namespace BerlinClock.Bulbs
{
    internal sealed class SecondsBulb : BulbBase
    {
        internal override BulbColor Color => BulbColor.Yellow;

        internal override bool IsOn => Time.IsSecondsOn;
    }
}
