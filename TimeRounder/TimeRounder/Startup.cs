using System;
using System.Collections.Generic;
using System.Text;
using TimeRounder.Constants;
using TimeRounder.Helpers;
using TimeRounder.Interfaces.Helpers;

namespace TimeRounder
{
    class Startup
    {
        #region Attributes
        /// <summary>
        /// round helper instance
        /// </summary>
        private IRoundHelper roundHelper;
        #endregion
        #region Ctor 
        public Startup(IRoundHelper roundHelper)
        {
            //dep inj 
            this.roundHelper = roundHelper;
        }
        #endregion
        #region StarterMethod
        public void Start()
        {
            //time to be rounded
            TimeSpan timeToRound = new TimeSpan(8, 18, 00);
            //rounding VALUE 
            TimeSpan roundingValue = new TimeSpan(0, 15, 0);
            //rounding directiom
            TimeRoundDirection timeRoundDirection = TimeRoundDirection.Upwards;
            //another rounding direction 
            TimeRoundDirection anotherTimeRoundDirection = TimeRoundDirection.Downwards;
            //display on console rounding value
            Console.WriteLine(roundHelper.Round(timeToRound, roundingValue, timeRoundDirection).ToString());
            Console.WriteLine(roundHelper.Round(timeToRound, roundingValue, anotherTimeRoundDirection).ToString());
            Console.ReadLine();

        }
        #endregion
    }
}
