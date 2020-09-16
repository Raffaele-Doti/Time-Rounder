using System;
using System.Collections.Generic;
using System.Text;
using TimeRounder.Interfaces;

namespace TimeRounder.Factories.TimeSpanRounder
{
    public class ConcreteUpwardsTimeSpanRounder : ITimeSpanRounder
    {
        #region Methods
        /// <summary>
        /// Used to upwards round a time at a certain rounding value.
        /// </summary>
        /// <param name="timeToRound"></param>
        /// <param name="roundingValue"></param>
        /// <returns></returns>
        public TimeSpan Round(TimeSpan timeToRound, TimeSpan roundingValue)
        {
            //params check 
            if (timeToRound == null)
            {
                throw new ApplicationException("ConcreteUpwardsTimeSpanRounder.Round() : Error #APR203 Time to round cannot be null");
            }
            if(roundingValue == null)
            {
                throw new ApplicationException("ConcreteUpwardsTimeSpanRounder.Round() : Error #FKAK230 Rounding value cannot be null");
            }
            //calculating span between time to round and rounding value
            var roundingSpan = timeToRound.TotalMinutes % roundingValue.TotalMinutes;
            //return time to round if and only if its module with round value equals to 0 . (means that time to round is yet correctly rounded)
            //otherwise we must add the missing minutes to the time to be rounded in order to approximate in excess based on the rounding value . Missing minutes == timeToRound + (roundingValue - (timeToRound % roundingValue))
            return (roundingSpan == 0) ? timeToRound : timeToRound.Add(roundingValue.Subtract(TimeSpan.FromMinutes(roundingSpan)));
        }
        #endregion
    }
}
