using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccessLayer.DA_Objects;

namespace PresentationLayer.Models
{
    //map from the presentation layer object to the dataaccess layer object
    public class PLMapper
    { 
    //Player Mappers
    public PlayerDAO Map(PlayerModel _PlayerToMap)
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
    public PlayerModel Map(PlayerDAO _PlayerToMap)
    {
        PlayerModel _PlayerToReturn = new PlayerModel();
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
    //Stats Mappers
    public StatsDAO Map(StatsModel _StatsToMap)
    {
        StatsDAO _StatsToReturn = new StatsDAO();
        _StatsToReturn.Kills = _StatsToMap.Kills;
        _StatsToReturn.Deaths = _StatsToMap.Deaths;
        _StatsToReturn.Average = _StatsToMap.Average;
        _StatsToReturn.FKPlayerName = _StatsToMap.FKPlayerName;

        return _StatsToReturn;
    }
    public StatsModel Map(StatsDAO _StatsToMap)
    {
        StatsModel _StatsToReturn = new StatsModel();
        _StatsToReturn.Kills = _StatsToMap.Kills;
        _StatsToReturn.Deaths = _StatsToMap.Deaths;
        _StatsToReturn.Average = _StatsToMap.Average;
        _StatsToReturn.FKPlayerName = _StatsToMap.FKPlayerName;

        return _StatsToReturn;
    }
    //Teams Mapping
    public TeamsDAO Map(TeamsModel _TeamsToMap)
    {
        TeamsDAO _TeamsToReturn = new TeamsDAO();
        _TeamsToReturn.TeamName = _TeamsToMap.TeamName;
        _TeamsToReturn.TeamDescription = _TeamsToMap.TeamDescription;
        _TeamsToReturn.FKPlayerName = _TeamsToMap.FKPlayerName;
        _TeamsToReturn.PositionsAvaliable = _TeamsToMap.PositionsAvaliable;
        _TeamsToReturn.PositionsTaken = _TeamsToMap.PositionsTaken;


        return _TeamsToReturn;
    }
    public TeamsModel Map(TeamsDAO _TeamsToMap)
    {
        TeamsModel _TeamsToReturn = new TeamsModel();
        _TeamsToReturn.TeamName = _TeamsToMap.TeamName;
        _TeamsToReturn.TeamDescription = _TeamsToMap.TeamDescription;
        _TeamsToReturn.FKPlayerName = _TeamsToMap.FKPlayerName;
        _TeamsToReturn.PositionsAvaliable = _TeamsToMap.PositionsAvaliable;
        _TeamsToReturn.PositionsTaken = _TeamsToMap.PositionsTaken;


        return _TeamsToReturn;
    }
    //Player View mapper
    public List<PlayerModel> Map(List<PlayerDAO> _dataPlayers)
    {
        List<PlayerModel> _ListPlayer = new List<PlayerModel>();
        foreach (PlayerDAO _dataPlayer in _dataPlayers)
        {
            PlayerModel _Player = new PlayerModel();
            _Player.PlayerName = _dataPlayer.PlayerName;
            _Player.PlayerFirstName = _dataPlayer.PlayerFirstName;
            _Player.PlayerLastName = _dataPlayer.PlayerLastName;
            _Player.PlayerCity = _dataPlayer.PlayerCity;
            _Player.PlayerState = _dataPlayer.PlayerState;
            _Player.PlayerAge = _dataPlayer.PlayerAge;

            _ListPlayer.Add(_Player);
        }
        return _ListPlayer;
    }
    //Team View mapper
    public List<TeamsModel> Map(List<TeamsDAO> _dataTeams)
    {
        List<TeamsModel> _ListTeams = new List<TeamsModel>();
        foreach (TeamsDAO _dataTeam in _dataTeams)
        {
            TeamsModel _Teams = new TeamsModel();
            _Teams.TeamName = _dataTeam.TeamName;
            _Teams.TeamDescription = _dataTeam.TeamDescription;
            _Teams.FKPlayerName = _dataTeam.FKPlayerName;
            _Teams.PositionsAvaliable = _dataTeam.PositionsAvaliable;
            _Teams.PositionsTaken = _dataTeam.PositionsTaken;


            _ListTeams.Add(_Teams);
        }
        return _ListTeams;
    }
    //Stats View mapper
    public List<StatsModel> Map(List<StatsDAO> _dataStats)
    {
        List<StatsModel> _ListStats = new List<StatsModel>();
        foreach (StatsDAO _dataStat in _dataStats)
        {
            StatsModel _Stats = new StatsModel();
            _Stats.Kills = _dataStat.Kills;
            _Stats.Deaths = _dataStat.Deaths;
            _Stats.Average = _dataStat.Average;
            _Stats.FKPlayerName = _dataStat.FKPlayerName;

            _ListStats.Add(_Stats);
        }
        return _ListStats;
    }
}
}