using BerlinClock.Core;

namespace BerlinClock.Bulbs
{
    internal sealed class BigMinuteBulb : BulbBase
    {
        internal override BulbColor Color => (BulbIndex +1) % 3 == 0 ? BulbColor.Red : BulbColor.Yellow;

        internal override bool IsOn => BulbIndex < Time.BigMinutes;
    }
}
