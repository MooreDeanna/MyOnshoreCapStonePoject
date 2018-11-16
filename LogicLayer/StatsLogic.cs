using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.LL_Objects;
using DataAccessLayer;
using Utility_Logger;

namespace LogicLayer
{
    public class StatsLogic
    {
        static LL_Mapper SLogMap = new LL_Mapper();
        static DataAccess data = new DataAccess();
        static ErrorLogger _Logger = new ErrorLogger();

        //use DAL to Update BLL
        //Stats Adding Logic
        public bool AddStats(StatsLLObject _NewStats)
        {   
            //NewStats pulls New info from User(PO) and mapping it to (LL)
            //single stats from DB mapped to LL 
            StatsLLObject _AddOld = SLogMap.map(data.viewSingleStat(_NewStats.FKPlayerName));
            bool success = false;
            try
            //Adding old Kills with New Kills to update Kills Column
            {
                _NewStats.Kills = (_NewStats.Kills) + (_AddOld.Kills);               

                //Adding old Desths with New Deaths to update Deaths Column

                _NewStats.Deaths = (_NewStats.Deaths) + (_AddOld.Deaths);

                //Calculating the new Average and updating the Average Column
                //(Math.Round (---,2)) is rounding the decimal to the 2nd place instead of it having 6+ places after the decimal              
                _NewStats.Average = (Math.Round(Convert.ToDecimal(_NewStats.Kills) / Convert.ToDecimal(_NewStats.Deaths), 2));
                success = data.UpdateStats(SLogMap.map(_NewStats));
            }
            catch (Exception _error)
            {
                _Logger.LogError(_error);
            }

            return success;
        }
    }
}

