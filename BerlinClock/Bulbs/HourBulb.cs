using BerlinClock.Core;

namespace BerlinClock.Bulbs
{
    internal sealed class HourBulb : BulbBase
    {
        internal override BulbColor Color => BulbColor.Red;

        internal override bool IsOn => BulbIndex < Time.Hours;
    }
}
