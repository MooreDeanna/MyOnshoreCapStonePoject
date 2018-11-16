using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DataAccessLayer.DA_Objects;
using System.Data.SqlClient;
using System.Data;
using Utility_Logger;

    namespace DataAccessLayer
    {
        public class DataAccess
        {
            //Connection Variable
            static string connectionstring = ConfigurationManager.ConnectionStrings["HaloStatDB"].ConnectionString;
            //Build and Insert Logger here
            static ErrorLogger _Logger = new ErrorLogger();

            //Player Methods
            public bool AddPlayer(PlayerDAO playerTOAdd)
            {
                bool success = false;
                try
                {
                    //Create a connection to the DB using a ConnectionString Variable
                    using (SqlConnection _connection = new SqlConnection(connectionstring))
                    {
                        //Creates a command that will Add a Player To the DB
                        using (SqlCommand _command = new SqlCommand("SP_AddPlayer", _connection))
                        {
                            //Specify the command type that is going to be used
                            //in this case we are going to be useing StoredProcedure
                            _command.CommandType = CommandType.StoredProcedure;
                            //Below is where the values are sent to the command
                            _command.Parameters.AddWithValue("@PlayerName", playerTOAdd.PlayerName);
                            _command.Parameters.AddWithValue("@PlayerFirstName", playerTOAdd.PlayerFirstName);
                            _command.Parameters.AddWithValue("@PlayerLastName", playerTOAdd.PlayerLastName);
                            _command.Parameters.AddWithValue("@PlayerCity", playerTOAdd.PlayerCity);
                            _command.Parameters.AddWithValue("@PlayerState", playerTOAdd.PlayerState);
                            _command.Parameters.AddWithValue("@PlayerAge", playerTOAdd.PlayerAge);
                            _command.Parameters.AddWithValue("@PlayerPassword", playerTOAdd.PlayerPassword);
                            _command.Parameters.AddWithValue("@FKRoleID", playerTOAdd.FKRoleID);
                            


                            //This is where the connection Opens
                            _connection.Open();
                            //this is where it executes the command
                            _command.ExecuteNonQuery();
                            //Set the Bool to TRUE
                            success = true;
                        }
                    }
                }
                catch (Exception _Error)
                {
                    //Set the bool to false because it Failed
                    success = false;
                    //Below is the Error Log that will Log Errors into a text document
                    _Logger.LogError(_Error);

                }
                return success;
            }
            public bool DeletePlayer(string PlayerName)
            {
                bool success = false;
                try
                {
                    //Create the connection to the DB using a ConnectionString Variable
                    using (SqlConnection _connection = new SqlConnection(connectionstring))
                    {
                        //Command to Delete a Player from the DB
                        using (SqlCommand _command = new SqlCommand("SP_DeletePlayer", _connection))
                        {
                            //Specify the command that will be used
                            _command.CommandType = CommandType.StoredProcedure;
                            //This is where the value get sent to command
                            _command.Parameters.AddWithValue("@PlayerName", PlayerName);
                            //Open the connection
                            _connection.Open();
                            //Execute Command
                            _command.ExecuteNonQuery();
                            //set bool to True
                            success = true;
                        }
                    }
                }
                catch
                {
                    success = false;
                }
                return success;
            }
            public List<PlayerDAO> GetAllPlayers()
            {
                List<PlayerDAO> _PlayerList = new List<PlayerDAO>();
                try
                {
                    using (SqlConnection _connection = new SqlConnection(connectionstring))
                    {
                        using (SqlCommand _command = new SqlCommand("SP_ViewAllPlayers", _connection))
                        {
                            _connection.Open();
                            _command.CommandType = CommandType.StoredProcedure;
                            using (SqlDataReader _reader = _command.ExecuteReader())
                            {
                                if (_reader.HasRows)
                                {
                                    while (_reader.Read())
                                    {
                                        PlayerDAO playerToList = new PlayerDAO();
                                        playerToList.PlayerName = _reader.GetString((_reader.GetOrdinal("PlayerName")));
                                        playerToList.PlayerFirstName = _reader.GetString((_reader.GetOrdinal("PlayerFirstName")));
                                        playerToList.PlayerLastName = _reader.GetString((_reader.GetOrdinal("PlayerLastName")));
                                        playerToList.PlayerCity = _reader.GetString((_reader.GetOrdinal("PlayerCity")));
                                        playerToList.PlayerState = _reader.GetString((_reader.GetOrdinal("PlayerState")));
                                        playerToList.PlayerAge = _reader.GetInt32((_reader.GetOrdinal("PlayerAge")));                                                                       

                                      _PlayerList.Add(playerToList);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Sorry,there is no data found.");
                                }
                            }
                        }
                    }
                }
            catch (Exception _Error)
            {
                _Logger.LogError(_Error);
            }
            return _PlayerList;
            }
            public bool UpdatePlayer(PlayerDAO PlayerToUpdate)
            {
                bool success = false;
                try
                {
                    using (SqlConnection _connection = new SqlConnection(connectionstring))
                    {
                        //command used to Update a Player in the DB
                        using (SqlCommand _command = new SqlCommand("SP_UpdatePlayer", _connection))
                        {
                            //Specify the command that is going to be used
                            _command.CommandType = CommandType.StoredProcedure;
                            //Below are the values that will be sent to the command
                            _command.Parameters.AddWithValue("@PlayerName", PlayerToUpdate.PlayerName);
                            _command.Parameters.AddWithValue("@PlayerFirstName", PlayerToUpdate.PlayerFirstName);
                            _command.Parameters.AddWithValue("@PlayerLastName", PlayerToUpdate.PlayerLastName);
                            _command.Parameters.AddWithValue("@PlayerCity", PlayerToUpdate.PlayerCity);
                            _command.Parameters.AddWithValue("@PlayerState", PlayerToUpdate.PlayerState);
                            _command.Parameters.AddWithValue("@PlayerAge", PlayerToUpdate.PlayerAge);
                            _command.Parameters.AddWithValue("@FKRoleID", PlayerToUpdate.FKRoleID);
                        //Open the Connection
                        _connection.Open();
                            //Execute the command
                            _command.ExecuteNonQuery();
                            //set the bool to true
                            success = true;
                        }
                    }
                }
                catch (Exception _Error)
                {
                    //ErrorLogger
                    _Logger.LogError(_Error);
                }
                return success;
            }
            //Method Called when Logging in a Player
            public PlayerDAO LoginPlayer(PlayerDAO _Login)
        {
            PlayerDAO _PlayerToList = new PlayerDAO();

            try
            {
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    using (SqlCommand _command = new SqlCommand("SP_PlayerLogin", _connection))
                    {
                        //What Command Type will be used
                        _command.CommandType = CommandType.StoredProcedure;
                        //What commands are going to be used
                        _command.Parameters.AddWithValue("@PlayerName", _Login.PlayerName);
                        _command.Parameters.AddWithValue("@PlayerPassword", _Login.PlayerPassword);
                        //open connection
                        _connection.Open();
                        //Execute commands
                        //_command.ExecuteNonQuery();

                        //Accesses SP to get the Data
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            while (_reader.Read())
                            {
                                _PlayerToList.PlayerName = _reader.GetString((_reader.GetOrdinal("PlayerName")));
                                _PlayerToList.PlayerFirstName = _reader.GetString((_reader.GetOrdinal("PlayerFirstName")));
                                _PlayerToList.PlayerLastName = _reader.GetString((_reader.GetOrdinal("PlayerLastName")));
                                _PlayerToList.PlayerCity = _reader.GetString((_reader.GetOrdinal("PlayerCity")));
                                _PlayerToList.PlayerState = _reader.GetString((_reader.GetOrdinal("PlayerState")));
                                _PlayerToList.PlayerAge = _reader.GetInt32((_reader.GetOrdinal("PlayerAge")));
                            }
                        }
                    }
                }
            }
            catch (Exception _Error)
            {
                _Logger.LogError(_Error);
            }
            return _PlayerToList;
        }
            public PlayerDAO viewSinglePlayer(string FKPlayerName)
        {
            PlayerDAO PlayerToView = new PlayerDAO();

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    // create command to view a team from the database
                    using (SqlCommand _command = new SqlCommand("sp_ViewSinglePlayer", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@FKPlayerName", FKPlayerName);
                        // this is where the connection is opened
                        _connection.Open();
                        // this is where all commands will be executed
                        _command.ExecuteNonQuery();

                        // this accesses all the data given by the stored procedure
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            while (_reader.Read())
                            {
                                // create object to hold info from database
                                //use .GetOrdinal so that if the DB gets rearranged it will not throw error because the Column numbers dont match
                                PlayerToView.PlayerName = _reader.GetString(_reader.GetOrdinal("PlayerName"));
                                PlayerToView.PlayerFirstName = _reader.GetString((_reader.GetOrdinal("PlayerFirstName")));
                                PlayerToView.PlayerLastName = _reader.GetString((_reader.GetOrdinal("PlayerLastName")));
                                PlayerToView.PlayerCity = _reader.GetString((_reader.GetOrdinal("PlayerCity")));
                                PlayerToView.PlayerState = _reader.GetString((_reader.GetOrdinal("PlayerState")));
                                PlayerToView.PlayerAge = _reader.GetInt32((_reader.GetOrdinal("PlayerAge")));
                                PlayerToView.FKRoleID = _reader.GetInt32((_reader.GetOrdinal("FKRoleID")));
                            }
                        }
                    }
                }
            }
            catch (Exception _error)
            {
                _Logger.LogError(_error);
            }

            return PlayerToView;
        }

            //Stats Methods
            public bool AddStats(StatsDAO StatToAdd)
            {
                bool success = false;
                try
                {
                    //connection to the DB with a ConnectionString Variable
                    using (SqlConnection _connection = new SqlConnection(connectionstring))
                    {
                        //create the commnd to Add Stats to the DB
                        using (SqlCommand _command = new SqlCommand("SP_UpsertStats", _connection))
                        {
                            //Specify what command type will be used
                            _command.CommandType = CommandType.StoredProcedure;
                            //Below are the Values that will be sent to the command
                            _command.Parameters.AddWithValue("@Kills", StatToAdd.Kills);
                            _command.Parameters.AddWithValue("@Deaths", StatToAdd.Deaths);                            
                            _command.Parameters.AddWithValue("@FKPlayerName", StatToAdd.FKPlayerName);


                        //Connection Open
                        _connection.Open();
                            //Execute the command
                            _command.ExecuteNonQuery();
                            //set the bool to true
                            success = true;
                        }
                    }
                }
                catch
                {
                    //set the bool to false since it failed
                    success = false;
                }
                return success;
            }
            public bool DeleteStats(string FKPlayerName)
            {
                bool success = false;
                try
                {
                    //Connection to the DB using CSV
                    using (SqlConnection _connection = new SqlConnection(connectionstring))
                    {
                        //Command to Delete a players Stats in the DB
                        using (SqlCommand _command = new SqlCommand("SP_DeleteStats", _connection))
                        {
                            //specify what type of command is going to be used
                            _command.CommandType = CommandType.StoredProcedure;
                            //Below are the Values being sent to the command
                            _command.Parameters.AddWithValue("@FKPlayerName", FKPlayerName);
                            //Connection Open
                            _connection.Open();
                            //Execute Command
                            _command.ExecuteNonQuery();
                            //Set the Bool to true
                            success = true;
                        }
                    }
                }
                catch
                {
                    //set the bool to false if it failed
                    success = false;
                }
                return success;
            }
            public List<StatsDAO> GetAllStats()
            {
                List<StatsDAO> _StatsList = new List<StatsDAO>();
                try
                {
                    using (SqlConnection _connection = new SqlConnection(connectionstring))
                    {
                        using (SqlCommand _command = new SqlCommand("SP_ViewAllStats", _connection))
                        {
                            _connection.Open();
                            //Specify why kind of command used
                            _command.CommandType = CommandType.StoredProcedure;
                            using (SqlDataReader _reader = _command.ExecuteReader())
                            {
                                if (_reader.HasRows)
                                {
                                    while (_reader.Read())
                                    {
                                        StatsDAO StatsToList = new StatsDAO();
                                        StatsToList.FKPlayerName = _reader.GetString((_reader.GetOrdinal("FKPlayerName")));
                                        StatsToList.Kills = _reader.GetInt32((_reader.GetOrdinal("Kills")));
                                        StatsToList.Deaths = _reader.GetInt32((_reader.GetOrdinal("Deaths")));
                                        StatsToList.Average = _reader.GetDecimal((_reader.GetOrdinal("Average")));                                        
                                        

                                        _StatsList.Add(StatsToList);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, no data found");
                                }
                            }
                        }
                    }
                }
                catch (Exception _Error)
            {
                _Logger.LogError(_Error);
            }
            return _StatsList;
            }
            public bool UpdateStats(StatsDAO StatsToUpdate)
            {
                bool success = false;
                try
                {
                    using (SqlConnection _connection = new SqlConnection(connectionstring))
                    {
                        //command that will update a players stats
                        using (SqlCommand _command = new SqlCommand("SP_UpsertStats", _connection))
                        {
                        //Specify what command type will be used
                            _command.CommandType = CommandType.StoredProcedure;
                        //Command type being used
                            _command.Parameters.AddWithValue("@Kills", StatsToUpdate.Kills);
                            _command.Parameters.AddWithValue("@Deaths", StatsToUpdate.Deaths);
                            _command.Parameters.AddWithValue("@Average", StatsToUpdate.Average);                          
                            _command.Parameters.AddWithValue("@FKPlayerName", StatsToUpdate.FKPlayerName);

                        //connection open
                        _connection.Open();
                            //Execute command
                            _command.ExecuteNonQuery();
                            //set bool to true
                            success = true;
                        }
                    }
                }
                catch (Exception _Error)
                {
                    //ErrorLogger
                    _Logger.LogError(_Error);
                }
                return success;
            }
            public StatsDAO viewSingleStat(string FKPlayerName)
        {
            StatsDAO StatToView = new StatsDAO();

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    // create command to view a team from the database
                    using (SqlCommand _command = new SqlCommand("sp_ViewPlayerStats", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@FKPlayerName", FKPlayerName);
                        // this is where the connection is opened
                        _connection.Open();
                        // this is where all commands will be executed
                        _command.ExecuteNonQuery();

                        // this accesses all the data given by the stored procedure
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            while (_reader.Read())
                            {
                                // create object to hold info from database
                                StatToView.FKPlayerName = _reader.GetString(_reader.GetOrdinal("FKPlayerName"));
                                StatToView.Kills = _reader.GetInt32((_reader.GetOrdinal("Kills")));
                                StatToView.Deaths = _reader.GetInt32((_reader.GetOrdinal("Deaths")));
                                StatToView.Average = _reader.GetDecimal((_reader.GetOrdinal("Average")));
                            }
                        }
                    }
                }
            }
            catch (Exception _error)
            {
                _Logger.LogError(_error);
            }

            return StatToView;
        }

            //Team Methods
            public bool AddTeams(TeamsDAO TeamsToAdd)
            {
                bool success = false;
                try
                {
                    //connection to the DB with a ConnectionString Variable
                    using (SqlConnection _connection = new SqlConnection(connectionstring))
                    {
                        //create the commnd to Add Stats to the DB
                        using (SqlCommand _command = new SqlCommand("SP_AddTeam", _connection))
                        {
                            //Specify what command type will be used
                            _command.CommandType = CommandType.StoredProcedure;
                        //Below are the Values that will be sent to the command
                            _command.Parameters.AddWithValue("@FKPlayerName", TeamsToAdd.FKPlayerName);
                            _command.Parameters.AddWithValue("@TeamName", TeamsToAdd.TeamName);
                            _command.Parameters.AddWithValue("@TeamDescription", TeamsToAdd.TeamDescription);
                            _command.Parameters.AddWithValue("@PositionsAvaliable", TeamsToAdd.PositionsAvaliable);
                            _command.Parameters.AddWithValue("@PositionsTaken", TeamsToAdd.PositionsTaken);
                            //Connection Open
                            _connection.Open();
                            //Execute the command
                            _command.ExecuteNonQuery();
                            //set the bool to true
                            success = true;
                        }
                    }
                }
                catch
                {
                    //set the bool to false since it failed
                    success = false;
                }
                return success;
            }
            public bool DeleteTeam(string TeamName)
            {
                bool success = false;
                try
                {
                    //Connection to the DB using CSV
                    using (SqlConnection _connection = new SqlConnection(connectionstring))
                    {
                        //Command to Delete a Team in the DB
                        using (SqlCommand _command = new SqlCommand("SP_DeleteTeam", _connection))
                        {
                            //specify what type of command is going to be used
                            _command.CommandType = CommandType.StoredProcedure;
                            //Below are the Values being sent to the command
                            _command.Parameters.AddWithValue("@TeamName", TeamName);
                            //Connection Open
                            _connection.Open();
                            //Execute Command
                            _command.ExecuteNonQuery();
                            //Set the Bool to true
                            success = true;
                        }
                    }
                }
                catch
                {
                    //set the bool to false if it failed
                    success = false;
                }
                return success;
            }
            public List<TeamsDAO> GetAllTeams()
            {
                List<TeamsDAO> _TeamsList = new List<TeamsDAO>();
                try
                {
                    using (SqlConnection _connection = new SqlConnection(connectionstring))
                    {
                        using (SqlCommand _command = new SqlCommand("SP_ViewAllTeams", _connection))
                        {
                            _connection.Open();
                            //Specify why kind of command used
                            _command.CommandType = CommandType.StoredProcedure;
                            using (SqlDataReader _reader = _command.ExecuteReader())
                            {
                                if (_reader.HasRows)
                                {
                                    while (_reader.Read())
                                    {
                                        TeamsDAO TeamsToList = new TeamsDAO();
                                        TeamsToList.TeamName = _reader.GetString((_reader.GetOrdinal("TeamName")));
                                        TeamsToList.TeamDescription = _reader.GetString((_reader.GetOrdinal("TeamDescription")));                                       
                                        TeamsToList.FKPlayerName = _reader.GetString((_reader.GetOrdinal("FKPlayerName")));
                                        TeamsToList.PositionsAvaliable = _reader.GetInt32((_reader.GetOrdinal("PositionAvaliable")));
                                        TeamsToList.PositionsTaken = _reader.GetInt32((_reader.GetOrdinal("PositionTaken")));                                        
                                        

                                    _TeamsList.Add(TeamsToList);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, no data found");
                                }
                            }
                        }
                    }
                }
                catch (Exception _Error)
            {
                _Logger.LogError(_Error);
            }
            return _TeamsList;
            }
            public bool UpdateTeams(TeamsDAO TeamsToUpdate)
            {
                bool success = false;
                try
                {
                    using (SqlConnection _connection = new SqlConnection(connectionstring))
                    {
                        //command that will update a Teams basic info
                        using (SqlCommand _command = new SqlCommand("SP_UpdateTeam", _connection))
                        {
                        //Specify the command that is going to be used
                            _command.CommandType = CommandType.StoredProcedure;
                        //Command type being used
                            _command.Parameters.AddWithValue("@TeamName", TeamsToUpdate.TeamName);
                            _command.Parameters.AddWithValue("@TeamDescription", TeamsToUpdate.TeamDescription);
                            _command.Parameters.AddWithValue("@PositionsAvaliable", TeamsToUpdate.PositionsAvaliable);
                            _command.Parameters.AddWithValue("@PositionsTaken", TeamsToUpdate.PositionsTaken);
                           // _command.Parameters.AddWithValue("@FKPlayerName", TeamsToUpdate.FKPlayerName);

                        //connection open
                        _connection.Open();
                            //Execute command
                            _command.ExecuteNonQuery();
                            //set bool to true
                            success = true;
                        }
                    }
                }
                catch (Exception _Error)
                {
                    //Error Logger
                    _Logger.LogError(_Error);
                }
                return success;
            }
            public TeamsDAO viewSingleTeam(string TeamName)
        {
            TeamsDAO TeamToView = new TeamsDAO();

            try
            {
                // create connection to database using connection string variable
                using (SqlConnection _connection = new SqlConnection(connectionstring))
                {
                    // create command to view a team from the database
                    using (SqlCommand _command = new SqlCommand("sp_ViewSingleTeam", _connection))
                    {
                        // specify what type of command to use
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@TeamName", TeamName);
                        // this is where the connection is opened
                        _connection.Open();
                        // this is where all commands will be executed
                        _command.ExecuteNonQuery();

                        // this accesses all the data given by the stored procedure
                        using (SqlDataReader _reader = _command.ExecuteReader())
                        {
                            while (_reader.Read())
                            {
                                // create object to hold info from database
                                TeamToView.TeamName = _reader.GetString((_reader.GetOrdinal("TeamName")));
                                TeamToView.TeamDescription = _reader.GetString((_reader.GetOrdinal("TeamDescription")));
                                TeamToView.PositionsAvaliable = _reader.GetInt32((_reader.GetOrdinal("PositionsAvaliable")));
                                TeamToView.PositionsTaken = _reader.GetInt32((_reader.GetOrdinal("PoitionsTaken")));
                                
                            }
                        }
                    }
                }
            }
            catch (Exception _error)
            {
                _Logger.LogError(_error);
            }

            return TeamToView;
        }
    }
    }

