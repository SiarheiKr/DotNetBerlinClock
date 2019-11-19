using BerlinClock.Core;

namespace BerlinClock.Bulbs
{
    internal sealed class BigHourBulb : BulbBase
    {
        internal override BulbColor Color => BulbColor.Red;

        internal override bool IsOn => BulbIndex < Time.BigHours;
    }
}
