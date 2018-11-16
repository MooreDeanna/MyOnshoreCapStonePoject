using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.LL_Objects;
using Utility_Logger;
using DataAccessLayer;

namespace LogicLayer
{
    public class TeamsLogic
    {
        static LL_Mapper TLogMap = new LL_Mapper();
        static DataAccess data = new DataAccess();
        static ErrorLogger _Logger = new ErrorLogger();

        //use DAL to Update BLL
        //Join team method subtracts 1 position from Avaliable and Adds 1 to the Taken
        public bool _LeaveTeam(TeamsLLObject _Team)
        {
            bool success = false;
            try
            {
                _Team.PositionsAvaliable++;
                _Team.PositionsTaken--;
                success = data.UpdateTeams(TLogMap.map(_Team));
            }
            catch (Exception _error)
            {
                _Logger.LogError(_error);
            }

            return success;
        }
        //Function For Leaving a team
        //subtracts 1 from PositionsTaken and adds 1 to Positions avaliable
        public bool _JoinTeam(TeamsLLObject _Team)
        {
            bool success = false;
            try
            {
                _Team.PositionsAvaliable--;
                _Team.PositionsTaken++;
                success = data.UpdateTeams(TLogMap.map(_Team));
            }
            catch (Exception _error)
            {
                _Logger.LogError(_error);
            }

            return success;
        }
    }
}
