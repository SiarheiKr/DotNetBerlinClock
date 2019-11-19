
using BerlinClock.Helpers;

namespace BerlinClock.Core
{
    internal abstract class BulbBase
    {
        internal void Initialize(BerlinTime time, byte bulbIndex)
        {
            Args.ThrowIfNull(time, nameof(time));

            Time = time;
            BulbIndex = bulbIndex;
        }

        internal abstract BulbColor Color { get; }

        internal abstract bool IsOn { get; }

        protected BerlinTime Time { get; private set; }

        protected byte BulbIndex { get; private set; }
    }
}
