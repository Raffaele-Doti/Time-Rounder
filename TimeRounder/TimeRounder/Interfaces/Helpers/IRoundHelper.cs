using System;
using TimeRounder.Constants;

namespace TimeRounder.Interfaces.Helpers
{
    public interface IRoundHelper
    {
        TimeSpan Round(TimeSpan timeToRound, TimeSpan roundValue, TimeRoundDirection roundTimeDirection);
    }
}