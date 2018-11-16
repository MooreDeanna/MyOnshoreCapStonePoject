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
    //public class PlayerAccess
    //{
    //    static string connectionString = ConfigurationManager.ConnectionStrings["HaloStatDB"].ConnectionString;
    //    static ErrorLogger _Logger = new ErrorLogger();

    //    //Player Methods
    //    public bool AddPlayer(PlayerDAO playerTOAdd)
    //    {
    //        bool success = false;
    //        try
    //        {
    //            //Create a connection to the DB using a ConnectionString Variable
    //            using (SqlConnection _connection = new SqlConnection(connectionString))
    //            {
    //                //Creates a command that will Add a Player To the DB
    //                using (SqlCommand _command = new SqlCommand("SP_AddPlayer", _connection))
    //                {
    //                    //Specify the command type that is going to be used
    //                    //in this case we are going to be useing StoredProcedure
    //                    _command.CommandType = CommandType.StoredProcedure;
    //                    //Below is where the values are sent to the command
    //                    _command.Parameters.AddWithValue("@PlayerName", playerTOAdd.PlayerName);
    //                    _command.Parameters.AddWithValue("@PlayerFirstName", playerTOAdd.PlayerFirstName);
    //                    _command.Parameters.AddWithValue("@PlayerLastName", playerTOAdd.PlayerLastName);
    //                    _command.Parameters.AddWithValue("@PlayerCity", playerTOAdd.PlayerCity);
    //                    _command.Parameters.AddWithValue("@PlayerState", playerTOAdd.PlayerState);
    //                    _command.Parameters.AddWithValue("@PlayerAge", playerTOAdd.PlayerAge);
    //                    _command.Parameters.AddWithValue("@PlayerPassword", playerTOAdd.PlayerPassword);
    //                    _command.Parameters.AddWithValue("@FKRoleID", playerTOAdd.FKRoleID);



    //                    //This is where the connection Opens
    //                    _connection.Open();
    //                    //this is where it executes the command
    //                    _command.ExecuteNonQuery();
    //                    //Set the Bool to TRUE
    //                    success = true;
    //                }
    //            }
    //        }
    //        catch (Exception _Error)
    //        {
    //            //Set the bool to false because it Failed
    //            success = false;
    //            //Below is the Error Log that will Log Errors into a text document
    //            _Logger.LogError(_Error);

    //        }
    //        return success;
    //    }
    //    public bool DeletePlayer(string PlayerName)
    //    {
    //        bool success = false;
    //        try
    //        {
    //            //Create the connection to the DB using a ConnectionString Variable
    //            using (SqlConnection _connection = new SqlConnection(connectionString))
    //            {
    //                //Command to Delete a Player from the DB
    //                using (SqlCommand _command = new SqlCommand("SP_DeletePlayer", _connection))
    //                {
    //                    //Specify the command that will be used
    //                    _command.CommandType = CommandType.StoredProcedure;
    //                    //This is where the value get sent to command
    //                    _command.Parameters.AddWithValue("@PlayerName", PlayerName);
    //                    //Open the connection
    //                    _connection.Open();
    //                    //Execute Command
    //                    _command.ExecuteNonQuery();
    //                    //set bool to True
    //                    success = true;
    //                }
    //            }
    //        }
    //        catch
    //        {
    //            success = false;
    //        }
    //        return success;
    //    }
    //    public List<PlayerDAO> GetAllPlayers()
    //    {
    //        List<PlayerDAO> _PlayerList = new List<PlayerDAO>();
    //        try
    //        {
    //            using (SqlConnection _connection = new SqlConnection(connectionString))
    //            {
    //                using (SqlCommand _command = new SqlCommand("SP_ViewAllPlayers", _connection))
    //                {
    //                    _connection.Open();
    //                    _command.CommandType = CommandType.StoredProcedure;
    //                    using (SqlDataReader _reader = _command.ExecuteReader())
    //                    {
    //                        if (_reader.HasRows)
    //                        {
    //                            while (_reader.Read())
    //                            {
    //                                PlayerDAO playerToList = new PlayerDAO();
    //                                playerToList.PlayerName = _reader.GetString((_reader.GetOrdinal("PlayerName")));
    //                                playerToList.PlayerFirstName = _reader.GetString((_reader.GetOrdinal("PlayerFirstName")));
    //                                playerToList.PlayerLastName = _reader.GetString((_reader.GetOrdinal("PlayerLastName")));
    //                                playerToList.PlayerCity = _reader.GetString((_reader.GetOrdinal("PlayerCity")));
    //                                playerToList.PlayerState = _reader.GetString((_reader.GetOrdinal("PlayerState")));
    //                                playerToList.PlayerAge = _reader.GetInt32((_reader.GetOrdinal("PlayerAge")));

    //                                _PlayerList.Add(playerToList);
    //                            }
    //                        }
    //                        else
    //                        {
    //                            Console.WriteLine("Sorry,there is no data found.");
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception _Error)
    //        {
    //            _Logger.LogError(_Error);
    //        }
    //        return _PlayerList;
    //    }
    //    public bool UpdatePlayer(PlayerDAO PlayerToUpdate)
    //    {
    //        bool success = false;
    //        try
    //        {
    //            using (SqlConnection _connection = new SqlConnection(connectionString))
    //            {
    //                //command used to Update a Player in the DB
    //                using (SqlCommand _command = new SqlCommand("SP_UpdatePlayer", _connection))
    //                {
    //                    //Specify the command that is going to be used
    //                    _command.CommandType = CommandType.StoredProcedure;
    //                    //Below are the values that will be sent to the command
    //                    _command.Parameters.AddWithValue("@PlayerName", PlayerToUpdate.PlayerName);
    //                    _command.Parameters.AddWithValue("@PlayerFirstName", PlayerToUpdate.PlayerFirstName);
    //                    _command.Parameters.AddWithValue("@PlayerLastName", PlayerToUpdate.PlayerLastName);
    //                    _command.Parameters.AddWithValue("@PlayerCity", PlayerToUpdate.PlayerCity);
    //                    _command.Parameters.AddWithValue("@PlayerState", PlayerToUpdate.PlayerState);
    //                    _command.Parameters.AddWithValue("@PlayerAge", PlayerToUpdate.PlayerAge);
    //                    _command.Parameters.AddWithValue("@FKRoleID", PlayerToUpdate.FKRoleID);
    //                    //Open the Connection
    //                    _connection.Open();
    //                    //Execute the command
    //                    _command.ExecuteNonQuery();
    //                    //set the bool to true
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
    //    //Method Called when Logging in a Player
    //    public PlayerDAO LoginPlayer(PlayerDAO _Login)
    //    {
    //        PlayerDAO _PlayerToList = new PlayerDAO();

    //        try
    //        {
    //            using (SqlConnection _connection = new SqlConnection(connectionString))
    //            {
    //                using (SqlCommand _command = new SqlCommand("SP_PlayerLogin", _connection))
    //                {
    //                    //What Command Type will be used
    //                    _command.CommandType = CommandType.StoredProcedure;
    //                    //What commands are going to be used
    //                    _command.Parameters.AddWithValue("@PlayerName", _Login.PlayerName);
    //                    _command.Parameters.AddWithValue("@PlayerPassword", _Login.PlayerPassword);
    //                    //open connection
    //                    _connection.Open();
    //                    //Execute commands
    //                    //_command.ExecuteNonQuery();

    //                    //Accesses SP to get the Data
    //                    using (SqlDataReader _reader = _command.ExecuteReader())
    //                    {
    //                        while (_reader.Read())
    //                        {
    //                            _PlayerToList.PlayerName = _reader.GetString((_reader.GetOrdinal("PlayerName")));
    //                            _PlayerToList.PlayerFirstName = _reader.GetString((_reader.GetOrdinal("PlayerFirstName")));
    //                            _PlayerToList.PlayerLastName = _reader.GetString((_reader.GetOrdinal("PlayerLastName")));
    //                            _PlayerToList.PlayerCity = _reader.GetString((_reader.GetOrdinal("PlayerCity")));
    //                            _PlayerToList.PlayerState = _reader.GetString((_reader.GetOrdinal("PlayerState")));
    //                            _PlayerToList.PlayerAge = _reader.GetInt32((_reader.GetOrdinal("PlayerAge")));
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception _Error)
    //        {
    //            _Logger.LogError(_Error);
    //        }
    //        return _PlayerToList;
    //    }
    //    public PlayerDAO viewSinglePlayer(string FKPlayerName)
    //    {
    //        PlayerDAO PlayerToView = new PlayerDAO();

    //        try
    //        {
    //            // create connection to database using connection string variable
    //            using (SqlConnection _connection = new SqlConnection(connectionString))
    //            {
    //                // create command to view a team from the database
    //                using (SqlCommand _command = new SqlCommand("sp_ViewSinglePlayer", _connection))
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
    //                            //use .GetOrdinal so that if the DB gets rearranged it will not throw error because the Column numbers dont match
    //                            PlayerToView.PlayerName = _reader.GetString(_reader.GetOrdinal("PlayerName"));
    //                            PlayerToView.PlayerFirstName = _reader.GetString((_reader.GetOrdinal("PlayerFirstName")));
    //                            PlayerToView.PlayerLastName = _reader.GetString((_reader.GetOrdinal("PlayerLastName")));
    //                            PlayerToView.PlayerCity = _reader.GetString((_reader.GetOrdinal("PlayerCity")));
    //                            PlayerToView.PlayerState = _reader.GetString((_reader.GetOrdinal("PlayerState")));
    //                            PlayerToView.PlayerAge = _reader.GetInt32((_reader.GetOrdinal("PlayerAge")));
    //                            PlayerToView.FKRoleID = _reader.GetInt32((_reader.GetOrdinal("FKRoleID")));
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception _error)
    //        {
    //            _Logger.LogError(_error);
    //        }

    //        return PlayerToView;
    //    }
    //}
}

