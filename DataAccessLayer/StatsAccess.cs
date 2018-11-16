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
    //class StatsAccess
    //{
    //    static string connectionString = ConfigurationManager.ConnectionStrings["HaloStatDB"].ConnectionString;
    //    static ErrorLogger _Logger = new ErrorLogger();

    //    //Stats Methods
    //    public bool AddStats(StatsDAO StatToAdd)
    //    {
    //        bool success = false;
    //        try
    //        {
    //            //connection to the DB with a ConnectionString Variable
    //            using (SqlConnection _connection = new SqlConnection(connectionString))
    //            {
    //                //create the commnd to Add Stats to the DB
    //                using (SqlCommand _command = new SqlCommand("SP_UpsertStats", _connection))
    //                {
    //                    //Specify what command type will be used
    //                    _command.CommandType = CommandType.StoredProcedure;
    //                    //Below are the Values that will be sent to the command
    //                    _command.Parameters.AddWithValue("@Kills", StatToAdd.Kills);
    //                    _command.Parameters.AddWithValue("@Deaths", StatToAdd.Deaths);
    //                    _command.Parameters.AddWithValue("@FKPlayerName", StatToAdd.FKPlayerName);


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
    //    public bool DeleteStats(string FKPlayerName)
    //    {
    //        bool success = false;
    //        try
    //        {
    //            //Connection to the DB using CSV
    //            using (SqlConnection _connection = new SqlConnection(connectionString))
    //            {
    //                //Command to Delete a players Stats in the DB
    //                using (SqlCommand _command = new SqlCommand("SP_DeleteStats", _connection))
    //                {
    //                    //specify what type of command is going to be used
    //                    _command.CommandType = CommandType.StoredProcedure;
    //                    //Below are the Values being sent to the command
    //                    _command.Parameters.AddWithValue("@FKPlayerName", FKPlayerName);
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
    //    public List<StatsDAO> GetAllStats()
    //    {
    //        List<StatsDAO> _StatsList = new List<StatsDAO>();
    //        try
    //        {
    //            using (SqlConnection _connection = new SqlConnection(connectionString))
    //            {
    //                using (SqlCommand _command = new SqlCommand("SP_ViewAllStats", _connection))
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
    //                                StatsDAO StatsToList = new StatsDAO();
    //                                StatsToList.FKPlayerName = _reader.GetString((_reader.GetOrdinal("FKPlayerName")));
    //                                StatsToList.Kills = _reader.GetInt32((_reader.GetOrdinal("Kills")));
    //                                StatsToList.Deaths = _reader.GetInt32((_reader.GetOrdinal("Deaths")));
    //                                StatsToList.Average = _reader.GetDecimal((_reader.GetOrdinal("Average")));


    //                                _StatsList.Add(StatsToList);
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
    //        return _StatsList;
    //    }
    //    public bool UpdateStats(StatsDAO StatsToUpdate)
    //    {
    //        bool success = false;
    //        try
    //        {
    //            using (SqlConnection _connection = new SqlConnection(connectionString))
    //            {
    //                //command that will update a players stats
    //                using (SqlCommand _command = new SqlCommand("SP_UpsertStats", _connection))
    //                {
    //                    //Specify what command type will be used
    //                    _command.CommandType = CommandType.StoredProcedure;
    //                    //Command type being used
    //                    _command.Parameters.AddWithValue("@Kills", StatsToUpdate.Kills);
    //                    _command.Parameters.AddWithValue("@Deaths", StatsToUpdate.Deaths);
    //                    _command.Parameters.AddWithValue("@Average", StatsToUpdate.Average);
    //                    _command.Parameters.AddWithValue("@FKPlayerName", StatsToUpdate.FKPlayerName);

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
    //            //ErrorLogger
    //            _Logger.LogError(_Error);
    //        }
    //        return success;
    //    }
    //    public StatsDAO viewSingleStat(string FKPlayerName)
    //    {
    //        StatsDAO StatToView = new StatsDAO();

    //        try
    //        {
    //            // create connection to database using connection string variable
    //            using (SqlConnection _connection = new SqlConnection(connectionString))
    //            {
    //                // create command to view a team from the database
    //                using (SqlCommand _command = new SqlCommand("sp_ViewPlayerStats", _connection))
    //                {
    //                    // specify what type of command to use
    //                    _command.CommandType = CommandType.StoredProcedure;
    //                    _command.Parameters.AddWithValue("@FKPlayerName", FKPlayerName);
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
    //                            StatToView.FKPlayerName = _reader.GetString(_reader.GetOrdinal("FKPlayerName"));
    //                            StatToView.Kills = _reader.GetInt32((_reader.GetOrdinal("Kills")));
    //                            StatToView.Deaths = _reader.GetInt32((_reader.GetOrdinal("Deaths")));
    //                            StatToView.Average = _reader.GetDecimal((_reader.GetOrdinal("Average")));
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception _error)
    //        {
    //            _Logger.LogError(_error);
    //        }

    //        return StatToView;
    //    }
    //}
}
