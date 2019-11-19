using BerlinClock.Core;

namespace BerlinClock.Bulbs
{
    internal sealed class MinuteBulb : BulbBase
    {
        internal override BulbColor Color => BulbColor.Yellow;

        internal override bool IsOn => BulbIndex < Time.Minutes;
    }
}
