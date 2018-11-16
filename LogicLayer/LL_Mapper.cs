using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DA_Objects;
using LogicLayer.LL_Objects;


namespace LogicLayer
{
    public class LL_Mapper
    {
        // map from DAL to the LogicLayer
        // and vice versa using objects

        public TeamsLLObject map(TeamsDAO _TeamsToMap)
        {
            TeamsLLObject _TeamsToReturn = new TeamsLLObject();

            _TeamsToReturn.TeamName = _TeamsToMap.TeamName;
            _TeamsToReturn.TeamDescription = _TeamsToMap.TeamDescription;
            _TeamsToReturn.PositionsAvaliable = _TeamsToMap.PositionsAvaliable;
            _TeamsToReturn.PositionsTaken = _TeamsToMap.PositionsTaken;          

            return _TeamsToReturn;
        }

        public TeamsDAO map(TeamsLLObject _TeamsToMap)
        {
            TeamsDAO _TeamsToReturn = new TeamsDAO();

            _TeamsToReturn.TeamName = _TeamsToMap.TeamName;
            _TeamsToReturn.TeamDescription = _TeamsToMap.TeamDescription;
            _TeamsToReturn.PositionsAvaliable = _TeamsToMap.PositionsAvaliable;
            _TeamsToReturn.PositionsTaken = _TeamsToMap.PositionsTaken;

            return _TeamsToReturn;
        }
        //Stats Logic Mappers
        public StatsLLObject map(StatsDAO _StatsToMap)
        {
            StatsLLObject _StatsToReturn = new StatsLLObject();

            _StatsToReturn.Kills = _StatsToMap.Kills;
            _StatsToReturn.Deaths = _StatsToMap.Deaths;
            _StatsToReturn.Average = _StatsToMap.Average;
            _StatsToReturn.FKPlayerName = _StatsToMap.FKPlayerName;

            return _StatsToReturn;
        }

        public StatsDAO map(StatsLLObject _StatsToMap)
        {
            StatsDAO _StatsToReturn = new StatsDAO();

            _StatsToReturn.Kills = _StatsToMap.Kills;
            _StatsToReturn.Deaths = _StatsToMap.Deaths;
            _StatsToReturn.Average = _StatsToMap.Average;
            _StatsToReturn.FKPlayerName = _StatsToMap.FKPlayerName;

            return _StatsToReturn;
        }

    }
}
