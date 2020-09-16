using System;
using System.Collections.Generic;
using System.Text;
using TimeRounder.Constants;
using TimeRounder.Factories.TimeSpanRounder;
using TimeRounder.Interfaces.Helpers;

namespace TimeRounder.Helpers
{
    public class RoundHelper : IRoundHelper
    {
        #region Attributes
        /// <summary>
        /// rounder factory
        /// </summary>
        private TimeSpanRounderFactory timeSpanRounderFactory;
        #endregion
        #region Ctor 
        public RoundHelper(TimeSpanRounderFactory timeSpanRounderFactory)
        {
            //dep inj 
            this.timeSpanRounderFactory = timeSpanRounderFactory;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Used to round a time at a certain minutes value.
        /// Eg. Round 10:28 a.m. at 15 minutes upwords -> return 10:30
        /// </summary>
        /// <param name="timeToRound">time span that has to be rounded.</param>
        /// <param name="roundingValue">how much minutes must be rounded.</param>
        /// <returns></returns>
        public TimeSpan Round(TimeSpan timeToRound, TimeSpan roundingValue, TimeRoundDirection roundTimeDirection)
        {
            //params check 
            if (timeToRound == null)
            {
                throw new ApplicationException("RoundHelper.RoundTimeSpan() : Error #AOK203 Time to round cannot be null.");
            }
            if (roundingValue == null)
            {
                throw new ApplicationException("RoundHelper.RoundTimeSpan() : Error #AK2301S Rounding value cannot be null.");
            }
            if (!Enum.IsDefined(typeof(TimeRoundDirection), roundTimeDirection))
            {
                throw new ApplicationException("RoundHelper.RoundTimeSpan() : Error #FAK230 Round time direction is not defined in enum.");
            }
            //checks done , continue
            return timeSpanRounderFactory.GetTimeSpanRounder(roundTimeDirection).Round(timeToRound, roundingValue);
        }
        #endregion
    }
}
