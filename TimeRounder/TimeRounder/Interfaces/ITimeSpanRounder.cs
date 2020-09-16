using System;
using System.Collections.Generic;
using System.Text;

namespace TimeRounder.Interfaces
{
    public interface ITimeSpanRounder
    {
        TimeSpan Round(TimeSpan timeToRound, TimeSpan roundingValue);
    }
}
