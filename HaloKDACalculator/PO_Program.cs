using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using HaloKDACalculator.PO_Objects;
using System.Data.SqlClient;
using DataAccessLayer.DA_Objects;
using DataAccessLayer;
using LogicLayer;


namespace HaloKDACalculator
{
    class PO_Program
    {
        static LL_Mapper _LLMap = new LL_Mapper();      
        static PO_Mapper _mapper = new PO_Mapper();


        static void Main(string[] args)
        {
            //create a new instance of DataAccessLayer class
            DataAccess data = new DataAccess();
            DataAccess delete = new DataAccess();
            //Creating new instances of the LogicLayer Class
            TeamsLogic TLogic = new TeamsLogic();
            StatsLogic SLogic = new StatsLogic();

            string yes;
            do
            {
                // create a console menu for the user
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("(A) Add something");
                Console.WriteLine("(D) Delete something");
                Console.WriteLine("(U) update something");
                Console.WriteLine("(V) View something");
                Console.WriteLine("(L) Leave Team");
                Console.WriteLine("(J) Join Team");

                //String left "Empty"
                string PST = "Empty";

                //create a variable for CRUD, Team    
                //ToUpper to Convert User Input to UpperCase
                string CRUD = Console.ReadLine().ToUpper().Trim();
                if (CRUD.Equals("L") && CRUD.Equals("J"))
                {
                    //Only applies to the Teams Data
                }
                else
                {
                    PST = whichtable();
                }
                bool success = false;
                //create a switch case to determine which method will be applied
                switch (CRUD)
                {
                    //Adding Case
                    case "A":
                        switch (PST)
                        {
                            //"P" to add a Player to the DB
                            case "P":
                                success = data.AddPlayer(_mapper.Map(PlayerInfo()));
                                //indicate wheather a record was created based on the bool above
                                if (success)
                                {
                                    Console.WriteLine("You have added a new Player!");
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, Something went wrong. No Player Was Added.");
                                }
                                break;
                            case "S":
                                
                                PO_Stats NewStats = StatsInfo();
                                success = SLogic.AddStats(_LLMap.map(_mapper.Map(NewStats)));
                                                                                               
                                //indicate wheather a record was created based on the bool above
                                if (success) 
                                {
                                    Console.WriteLine("You have added a new Stats!");
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, Something went wrong. No Stats Were Added.");
                                }
                                break;
                            case "T":
                                success = data.AddTeams(_mapper.Map(TeamsInfo()));
                                //indicate wheather a record was created based on the bool above
                                if (success)
                                {
                                    Console.WriteLine("You have added a new Team!");
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, Something went wrong. No Team Was Added.");
                                }
                                break;

                        }
                        break;
                    //this case deletes
                    case "D":
                        switch (PST)
                        {
                            //this is to delete a book
                            case "P":
                                success = data.DeletePlayer(Name("PlayerName"));
                                if (success)
                                    Console.WriteLine("The Player was successfully deleted.");
                                else
                                    Console.WriteLine("Sorry, Something went wrong.");
                                break;

                            case "S":
                                success = data.DeleteStats(Name("PlayerName"));
                                if (success)
                                    Console.WriteLine("The Stat was successfully deleted.");
                                else
                                    Console.WriteLine("Sorry, Something went wrong.");
                                break;

                            case "T":
                                success = data.DeleteTeam(Name("Team"));
                                if (success)
                                    Console.WriteLine("The Team was successfully deleted.");
                                else
                                    Console.WriteLine("Sorry, Something went wrong.");
                                break;

                        }
                        break;
                    //this case updates
                    case "U":
                        switch (PST)
                        {
                            case "P":
                                PO_Player updatePlayer = PlayerInfo();
                                updatePlayer.PlayerName = Name("PlayerName");
                                success = data.UpdatePlayer(_mapper.Map(updatePlayer));
                                if (success)
                                    Console.WriteLine("The Player was successfully Updated.");
                                else
                                    Console.WriteLine("Sorry, Something went wrong.");
                                break;

                            case "S":                              
                                PO_Stats updateStats = StatsInfo();
                                updateStats.FKPlayerName = Name("PlayerName");
                                success = data.UpdateStats(_mapper.Map(updateStats));
                                if (success)
                                    Console.WriteLine("The Stat was successfully Updated.");
                                else
                                    Console.WriteLine("Sorry, Something went wrong.");
                                break;

                            case "T":
                                PO_Teams updateTeam = TeamsInfo();
                                updateTeam.TeamName =  Name("TeamName");
                                success = data.UpdateTeams(_mapper.Map(updateTeam));
                                if (success)
                                    Console.WriteLine("The Team was successfully Updated.");
                                else
                                    Console.WriteLine("Sorry, Something went wrong.");
                                break;
                        }
                        break;
                    //this case Views
                    case "V":
                        switch (PST)
                        {
                            case "P":
                                List<PO_Player> PlayerToView = new List<PO_Player>();
                                PlayerToView = _mapper.Map(data.GetAllPlayers());
                                foreach (PO_Player singlePlayer in PlayerToView)
                                {
                                    Console.WriteLine(singlePlayer.PlayerID + " | Player Name: " + singlePlayer.PlayerName + " | First Name: " 
                                        + singlePlayer.PlayerFirstName + " | Last Name: " + singlePlayer.PlayerLastName +
                                        " | City: " + singlePlayer.PlayerCity + " | State: " + singlePlayer.PlayerState + " | Age: " +
                                        singlePlayer.PlayerAge);
                                }
                                break;

                            case "S":

                                List<PO_Stats> StatsToView = new List<PO_Stats>();
                                StatsToView = _mapper.Map(data.GetAllStats());
                                foreach (PO_Stats SingleStat in StatsToView)
                                {
                                    Console.WriteLine(" | Player Name: " + SingleStat.FKPlayerName + " | Kills: " + SingleStat.Kills +
                                        " | Deaths: " + SingleStat.Deaths + " | Average: " + SingleStat.Average);

                                }
                                break;

                            case "T":
                                List<PO_Teams> TeamsToView = new List<PO_Teams>();
                                TeamsToView = _mapper.Map(data.GetAllTeams());
                                foreach (PO_Teams SingleTeam in TeamsToView)
                                {
                                    Console.WriteLine("|` Team name:" + SingleTeam.TeamName +"|  Description: " + SingleTeam.TeamDescription +
                                        "| Open Slots: " + SingleTeam.PositionsAvaliable + "| Filled Spots:" + SingleTeam.PositionsTaken +
                                        "| Team Members:" + SingleTeam.FKPlayerName);                          
                                }
                                break;


                        }
                        break;
                    // this case checks in 
                    case "L":

                        // Get TeamName to find what team to Leave
                        string LeaveTeam = Name("Teams");
                        TeamsDAO LeaveTeamDAO = data.viewSingleTeam(LeaveTeam);

                        // Makes sure there is is a position to leave
                        if (LeaveTeamDAO.PositionsTaken > 0)
                            success = TLogic._LeaveTeam(_LLMap.map(LeaveTeamDAO));

                        if (success)
                            Console.WriteLine("You have left the team.");
                        else
                            Console.WriteLine("Sorry,Something happend. You were unable to leave the team.");

                        break;

                    case "J":

                        // Get Team Name to find the team wanting to be joined
                        string JoinTeam = Name("Teams");
                        TeamsDAO JoinTeamDAO = data.viewSingleTeam(JoinTeam);

                        // Makes sure there is a position to join
                        if (JoinTeamDAO.PositionsAvaliable > 0)
                            success = TLogic._JoinTeam(_LLMap.map(JoinTeamDAO));

                        if (success)
                            Console.WriteLine("You have successfully Joined the Team! Welcome!.");
                        else
                            Console.WriteLine("Sorry The position you are trying to Join is unavaliable. You were Unable to Join the team.");

                        break;



                }


                Console.WriteLine("Do you wish to continue? Y/N");
                yes = Console.ReadLine().ToUpper().Trim();
            }
            while (yes.Equals("Y"));
            Console.ReadLine();
        }
        //Method for getting Team Info
        static PO_Teams TeamsInfo()
        {
            PO_Teams Teams = new PO_Teams();

            Console.WriteLine("Who Is The TeamLead?");
            Teams.FKPlayerName = Console.ReadLine();

            Console.WriteLine("What is the Team Name?");
            Teams.TeamName = Console.ReadLine();

            Console.WriteLine("What is the Teams Discription?");
            Teams.TeamDescription = Console.ReadLine();

            Console.WriteLine("How Many Positions are avaliable?MAX4)");
            Teams.PositionsAvaliable = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How Many Positions are Taken? *Note:The Combined total between Avaliable and Taken positions can NOT exceed 4)");
            Teams.PositionsTaken = Convert.ToInt32(Console.ReadLine());

            return Teams;
        }        
        //Method for getting Stat info
        static PO_Stats StatsInfo()
        {

            PO_Stats Stats = new PO_Stats();

            Console.WriteLine("Whos Stats are being entered?");
            Stats.FKPlayerName = Console.ReadLine();

            Console.WriteLine("How many kills did the player get?");
            Stats.Kills = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many times did the player die");
            Stats.Deaths = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("What was the Average?");
            //Stats.Average = Convert.ToDecimal(Console.ReadLine());            

            return Stats;
        }
        //Method for getting Player Info
        static PO_Player PlayerInfo()
        {
            PO_Player Player = new PO_Player();

            Console.WriteLine("Player UserName");
            Player.PlayerName = Console.ReadLine();

            Console.WriteLine("Player First Name");
            Player.PlayerFirstName = Console.ReadLine();

            Console.WriteLine("Player Last Name");
            Player.PlayerLastName = Console.ReadLine();

            Console.WriteLine("What City are you from?");
            Player.PlayerCity = Console.ReadLine();

            Console.WriteLine("What State are you from?");
            Player.PlayerState = Console.ReadLine();

            Console.WriteLine("How old are you?");
            Player.PlayerAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter a Password?");
            Player.PlayerPassword = Console.ReadLine();

            Console.WriteLine("What is your RoleID number?(If not assisgned please enter '1')");
            Player.FKRoleID = Convert.ToInt32(Console.ReadLine());

            return Player;
        }

        static string whichtable()
        {
            Console.WriteLine("Choose an Option");
            Console.WriteLine("(P) for Player");
            Console.WriteLine("(S) for Stats");
            Console.WriteLine("(T) for Teams");

            //use ToUpper so it doesn't matter the capitalization of user input
            // use Trim so it wont throw error if they add a space or something like that
            string userchoice = Console.ReadLine().ToUpper().Trim();
            Console.WriteLine();
            return userchoice;
        }
             
        static string Name(string Input)
        {
            Console.WriteLine("What is the " + Input + "?");
           
            string IDName = Console.ReadLine().Trim();

            return IDName;

        }
    }
}
