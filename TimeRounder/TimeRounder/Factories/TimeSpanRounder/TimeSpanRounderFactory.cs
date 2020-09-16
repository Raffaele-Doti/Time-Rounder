using System;
using System.Collections.Generic;
using System.Text;
using TimeRounder.Constants;
using TimeRounder.Interfaces;

namespace TimeRounder.Factories.TimeSpanRounder
{
    public class TimeSpanRounderFactory
    {
        #region Attributes 
        /// <summary>
        /// Dictonary to know concrete implementations to return 
        /// </summary>
        private Dictionary<TimeRoundDirection, Func<ITimeSpanRounder>> keyValuePairs;
        #endregion
        #region Ctor
        public TimeSpanRounderFactory()
        {
            //Init dictonary 
            keyValuePairs = new Dictionary<TimeRoundDirection, Func<ITimeSpanRounder>>
            {
                { TimeRoundDirection.Upwards, () => { return new ConcreteUpwardsTimeSpanRounder(); } },
                { TimeRoundDirection.Downwards, () => { return new ConcreteDownwardsTimeSpanRounder(); } }
            };
        }
        #endregion
        #region Methods
        /// <summary>
        /// Used to obtain a concrete implementation of interface itimespanrounder.
        /// </summary>
        /// <param name="timeRoundDirection"></param>
        /// <returns></returns>
        public ITimeSpanRounder GetTimeSpanRounder(TimeRoundDirection timeRoundDirection)
        {
            //params check 
            if (!Enum.IsDefined(typeof(TimeRoundDirection), timeRoundDirection))
            {
                throw new ApplicationException("TimeSpanRounderFactory.GetTimeSpanRounder() : Error #BOK29 Time round direction is not defined in enum");
            }
            //retrieve and return 
            try
            {
                return keyValuePairs[timeRoundDirection].Invoke();
            }
            catch (Exception e)
            {

                throw;
            }
        }
        #endregion
    }
}
