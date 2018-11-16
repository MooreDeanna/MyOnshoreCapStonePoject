using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Utility_Logger;
using DataAccessLayer.DA_Objects;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    //class TeamsAccess
    //{
    //    static string connectionString = ConfigurationManager.ConnectionStrings["HaloStatDB"].ConnectionString;
    //    static ErrorLogger _Logger = new ErrorLogger();

    //    //Team Methods
    //    public bool AddTeams(TeamsDAO TeamsToAdd)
    //    {
    //        bool success = false;
    //        try
    //        {
    //            //connection to the DB with a ConnectionString Variable
    //            using (SqlConnection _connection = new SqlConnection(connectionString))
    //            {
    //                //create the commnd to Add Stats to the DB
    //                using (SqlCommand _command = new SqlCommand("SP_AddTeam", _connection))
    //                {
    //                    //Specify what command type will be used
    //                    _command.CommandType = CommandType.StoredProcedure;
    //                    //Below are the Values that will be sent to the command
    //                    _command.Parameters.AddWithValue("@FKPlayerName", TeamsToAdd.FKPlayerName);
    //                    _command.Parameters.AddWithValue("@TeamName", TeamsToAdd.TeamName);
    //                    _command.Parameters.AddWithValue("@TeamDescription", TeamsToAdd.TeamDescription);
    //                    _command.Parameters.AddWithValue("@PositionsAvaliable", TeamsToAdd.PositionsAvaliable);
    //                    _command.Parameters.AddWithValue("@PositionsTaken", TeamsToAdd.PositionsTaken);
    //                    //Connection Open
    //                    _connection.Open();
    //                    //Execute the command
    //                    _command.ExecuteNonQuery();
    //                    //set the bool to true
    //                    success = true;
    //                }
    //            }
    //        }
    //        catch
    //        {
    //            //set the bool to false since it failed
    //            success = false;
    //        }
    //        return success;
    //    }
    //    public bool DeleteTeam(string TeamName)
    //    {
    //        bool success = false;
    //        try
    //        {
    //            //Connection to the DB using CSV
    //            using (SqlConnection _connection = new SqlConnection(connectionString))
    //            {
    //                //Command to Delete a Team in the DB
    //                using (SqlCommand _command = new SqlCommand("SP_DeleteTeam", _connection))
    //                {
    //                    //specify what type of command is going to be used
    //                    _command.CommandType = CommandType.StoredProcedure;
    //                    //Below are the Values being sent to the command
    //                    _command.Parameters.AddWithValue("@TeamName", TeamName);
    //                    //Connection Open
    //                    _connection.Open();
    //                    //Execute Command
    //                    _command.ExecuteNonQuery();
    //                    //Set the Bool to true
    //                    success = true;
    //                }
    //            }
    //        }
    //        catch
    //        {
    //            //set the bool to false if it failed
    //            success = false;
    //        }
    //        return success;
    //    }
    //    public List<TeamsDAO> GetAllTeams()
    //    {
    //        List<TeamsDAO> _TeamsList = new List<TeamsDAO>();
    //        try
    //        {
    //            using (SqlConnection _connection = new SqlConnection(connectionString))
    //            {
    //                using (SqlCommand _command = new SqlCommand("SP_ViewAllTeams", _connection))
    //                {
    //                    _connection.Open();
    //                    //Specify why kind of command used
    //                    _command.CommandType = CommandType.StoredProcedure;
    //                    using (SqlDataReader _reader = _command.ExecuteReader())
    //                    {
    //                        if (_reader.HasRows)
    //                        {
    //                            while (_reader.Read())
    //                            {
    //                                TeamsDAO TeamsToList = new TeamsDAO();
    //                                TeamsToList.TeamName = _reader.GetString((_reader.GetOrdinal("TeamName")));
    //                                TeamsToList.TeamDescription = _reader.GetString((_reader.GetOrdinal("TeamDescription")));
    //                                TeamsToList.FKPlayerName = _reader.GetString((_reader.GetOrdinal("FKPlayerName")));
    //                                TeamsToList.PositionsAvaliable = _reader.GetInt32((_reader.GetOrdinal("PositionAvaliable")));
    //                                TeamsToList.PositionsTaken = _reader.GetInt32((_reader.GetOrdinal("PositionTaken")));


    //                                _TeamsList.Add(TeamsToList);
    //                            }
    //                        }
    //                        else
    //                        {
    //                            Console.WriteLine("Sorry, no data found");
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception _Error)
    //        {
    //            _Logger.LogError(_Error);
    //        }
    //        return _TeamsList;
    //    }
    //    public bool UpdateTeams(TeamsDAO TeamsToUpdate)
    //    {
    //        bool success = false;
    //        try
    //        {
    //            using (SqlConnection _connection = new SqlConnection(connectionString))
    //            {
    //                //command that will update a Teams basic info
    //                using (SqlCommand _command = new SqlCommand("SP_UpdateTeam", _connection))
    //                {
    //                    //Specify the command that is going to be used
    //                    _command.CommandType = CommandType.StoredProcedure;
    //                    //Command type being used
    //                    _command.Parameters.AddWithValue("@TeamName", TeamsToUpdate.TeamName);
    //                    _command.Parameters.AddWithValue("@TeamDescription", TeamsToUpdate.TeamDescription);
    //                    _command.Parameters.AddWithValue("@PositionsAvaliable", TeamsToUpdate.PositionsAvaliable);
    //                    _command.Parameters.AddWithValue("@PositionsTaken", TeamsToUpdate.PositionsTaken);
    //                    // _command.Parameters.AddWithValue("@FKPlayerName", TeamsToUpdate.FKPlayerName);

    //                    //connection open
    //                    _connection.Open();
    //                    //Execute command
    //                    _command.ExecuteNonQuery();
    //                    //set bool to true
    //                    success = true;
    //                }
    //            }
    //        }
    //        catch (Exception _Error)
    //        {
    //            //Error Logger
    //            _Logger.LogError(_Error);
    //        }
    //        return success;
    //    }
    //    public TeamsDAO viewSingleTeam(string TeamName)
    //    {
    //        TeamsDAO TeamToView = new TeamsDAO();

    //        try
    //        {
    //            // create connection to database using connection string variable
    //            using (SqlConnection _connection = new SqlConnection(connectionString))
    //            {
    //                // create command to view a team from the database
    //                using (SqlCommand _command = new SqlCommand("sp_ViewSingleTeam", _connection))
    //                {
    //                    // specify what type of command to use
    //                    _command.CommandType = CommandType.StoredProcedure;
    //                    _command.Parameters.AddWithValue("@TeamName", TeamName);
    //                    // this is where the connection is opened
    //                    _connection.Open();
    //                    // this is where all commands will be executed
    //                    _command.ExecuteNonQuery();

    //                    // this accesses all the data given by the stored procedure
    //                    using (SqlDataReader _reader = _command.ExecuteReader())
    //                    {
    //                        while (_reader.Read())
    //                        {
    //                            // create object to hold info from database
    //                            TeamToView.TeamName = _reader.GetString((_reader.GetOrdinal("TeamName")));
    //                            TeamToView.TeamDescription = _reader.GetString((_reader.GetOrdinal("TeamDescription")));
    //                            TeamToView.PositionsAvaliable = _reader.GetInt32((_reader.GetOrdinal("PositionsAvaliable")));
    //                            TeamToView.PositionsTaken = _reader.GetInt32((_reader.GetOrdinal("PoitionsTaken")));

    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception _error)
    //        {
    //            _Logger.LogError(_error);
    //        }

    //        return TeamToView;
    //    }
    //}
}
