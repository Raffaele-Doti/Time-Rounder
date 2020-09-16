using System;
using System.Collections.Generic;
using System.Text;
using TimeRounder.Interfaces;

namespace TimeRounder.Factories.TimeSpanRounder
{
    public class ConcreteDownwardsTimeSpanRounder : ITimeSpanRounder
    {
        #region Methods
        /// <summary>
        /// Used to round downwards
        /// </summary>
        /// <param name="timeToRound"></param>
        /// <param name="roundingValue"></param>
        /// <returns></returns>
        public TimeSpan Round(TimeSpan timeToRound, TimeSpan roundingValue)
        {
            //params check 
            if (timeToRound == null)
            {
                throw new ApplicationException("ConcreteDownwardsTimeSpanRounder.Round() : Error #DP302A Time to round cannot be null");
            }
            if (roundingValue == null)
            {
                throw new ApplicationException("ConcreteUpwardsTimeSpanRounder.Round() : Error #FDSA30 Rounding value cannot be null");
            }
            //calculating span between time to round and rounding value
            var roundingSpan = timeToRound.TotalMinutes % roundingValue.TotalMinutes;
            //return time to span if and only if rounding span is equal to 0 , otherwise we must subtract rounding span to our time to round
            return (roundingSpan == 0) ? timeToRound : timeToRound.Subtract(TimeSpan.FromMinutes(roundingSpan)); 
        }
        #endregion
    }
}
