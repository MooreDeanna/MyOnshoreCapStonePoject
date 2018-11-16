using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DA_Objects;


namespace HaloKDACalculator.PO_Objects
{
    public class PO_Mapper
    {
        //map from the presentation layer object to the dataaccess layer object

        //Player Mapper
        public PlayerDAO Map(PO_Player _PlayerToMap)
        {
            PlayerDAO _PlayerToReturn = new PlayerDAO();
            _PlayerToReturn.PlayerName = _PlayerToMap.PlayerName;
            _PlayerToReturn.PlayerFirstName = _PlayerToMap.PlayerFirstName;
            _PlayerToReturn.PlayerLastName = _PlayerToMap.PlayerLastName;
            _PlayerToReturn.PlayerCity = _PlayerToMap.PlayerCity;
            _PlayerToReturn.PlayerState = _PlayerToMap.PlayerState;
            _PlayerToReturn.PlayerAge = _PlayerToMap.PlayerAge;
            _PlayerToReturn.PlayerPassword = _PlayerToMap.PlayerPassword;
            _PlayerToReturn.FKRoleID = _PlayerToMap.FKRoleID;      

            return _PlayerToReturn;
        }
        public PO_Player Map(PlayerDAO _PlayerToMap)
        {
            PO_Player _PlayerToReturn = new PO_Player();
            _PlayerToReturn.PlayerName = _PlayerToMap.PlayerName;
            _PlayerToReturn.PlayerFirstName = _PlayerToMap.PlayerFirstName;
            _PlayerToReturn.PlayerLastName = _PlayerToMap.PlayerLastName;
            _PlayerToReturn.PlayerCity = _PlayerToMap.PlayerCity;
            _PlayerToReturn.PlayerState = _PlayerToMap.PlayerState;
            _PlayerToReturn.PlayerAge = _PlayerToMap.PlayerAge;
            _PlayerToReturn.PlayerPassword = _PlayerToMap.PlayerPassword;
            _PlayerToReturn.FKRoleID = _PlayerToMap.FKRoleID;

            return _PlayerToReturn;
        }
        //Stats Mapper
        public StatsDAO Map(PO_Stats _StatsToMap)
        {
            StatsDAO _StatsToReturn = new StatsDAO();
            _StatsToReturn.Kills = _StatsToMap.Kills;
            _StatsToReturn.Deaths = _StatsToMap.Deaths;
            _StatsToReturn.Average = _StatsToMap.Average;
            _StatsToReturn.FKPlayerName = _StatsToMap.FKPlayerName;

            return _StatsToReturn;
        }
        public PO_Stats Map(StatsDAO _StatsToMap)
        {
            PO_Stats _StatsToReturn = new PO_Stats();
            _StatsToReturn.Kills = _StatsToMap.Kills;
            _StatsToReturn.Deaths = _StatsToMap.Deaths;
            _StatsToReturn.Average = _StatsToMap.Average;
            _StatsToReturn.FKPlayerName = _StatsToMap.FKPlayerName;

            return _StatsToReturn;
        }
        //Teams Mapping
        public TeamsDAO Map(PO_Teams _TeamsToMap)
        {
            TeamsDAO _TeamsToReturn = new TeamsDAO();
            _TeamsToReturn.TeamName = _TeamsToMap.TeamName;
            _TeamsToReturn.TeamDescription = _TeamsToMap.TeamDescription;
            _TeamsToReturn.FKPlayerName = _TeamsToMap.FKPlayerName;
            _TeamsToReturn.PositionsAvaliable = _TeamsToMap.PositionsAvaliable;
            _TeamsToReturn.PositionsTaken = _TeamsToMap.PositionsTaken;            
            

            return _TeamsToReturn;
        }
        public PO_Teams Map(TeamsDAO _TeamsToMap)
        {
            PO_Teams _TeamsToReturn = new PO_Teams();
            _TeamsToReturn.TeamName = _TeamsToMap.TeamName;
            _TeamsToReturn.TeamDescription = _TeamsToMap.TeamDescription;
            _TeamsToReturn.FKPlayerName = _TeamsToMap.FKPlayerName;
            _TeamsToReturn.PositionsAvaliable = _TeamsToMap.PositionsAvaliable;
            _TeamsToReturn.PositionsTaken = _TeamsToMap.PositionsTaken;
            

            return _TeamsToReturn;
        }
        //Player View mapper
        public List<PO_Player> Map(List<PlayerDAO> _dataPlayers)
        {
            List<PO_Player> _PressPlayer = new List<PO_Player>();
            foreach (PlayerDAO _dataPlayer in _dataPlayers)
            {
                PO_Player _Player = new PO_Player();
                _Player.PlayerName = _dataPlayer.PlayerName;
                _Player.PlayerFirstName = _dataPlayer.PlayerFirstName;
                _Player.PlayerLastName = _dataPlayer.PlayerLastName;
                _Player.PlayerCity = _dataPlayer.PlayerCity;
                _Player.PlayerState = _dataPlayer.PlayerState;
                _Player.PlayerAge = _dataPlayer.PlayerAge;              

                _PressPlayer.Add(_Player);
            }
            return _PressPlayer;
        }
        //Team View mapper
        public List<PO_Teams> Map(List<TeamsDAO> _dataTeams)
        {
            List<PO_Teams> _PressTeams = new List<PO_Teams>();
            foreach (TeamsDAO _dataTeam in _dataTeams)
            {
                PO_Teams _Teams = new PO_Teams();
                _Teams.TeamName = _dataTeam.TeamName;
                _Teams.TeamDescription = _dataTeam.TeamDescription;
                _Teams.FKPlayerName = _dataTeam.FKPlayerName;
                _Teams.PositionsAvaliable = _dataTeam.PositionsAvaliable;
                _Teams.PositionsTaken = _dataTeam.PositionsTaken;
                

                _PressTeams.Add(_Teams);
            }
            return _PressTeams;
        }
        //Stats View mapper
        public List<PO_Stats> Map(List<StatsDAO> _dataStats)
        {
            List<PO_Stats> _PressStats = new List<PO_Stats>();
            foreach (StatsDAO _dataStat in _dataStats)
            {
                PO_Stats _Stats = new PO_Stats();
                _Stats.Kills = _dataStat.Kills;
                _Stats.Deaths = _dataStat.Deaths;
                _Stats.Average = _dataStat.Average;
                _Stats.FKPlayerName = _dataStat.FKPlayerName;

                _PressStats.Add(_Stats);
            }
            return _PressStats;
        }
    }
}