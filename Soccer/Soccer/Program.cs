using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTourney
{
    class Program
    {
        class Team  // Basic Object of a team, could be of any type of sport. Only needs a Name, Wins, and Losses
        {
            public string tName;
            public int wins;
            public int loss;

        };

        class Match
        {

        };

        class SoccerTeam : Team
        {
            public int draw;
            public int goalsFor;
            public int goalsAgainst;
            public int differential;
            public int points;
            public List<Match> matches;

            public SoccerTeam(String name, int p)
            {
                tName = name;
                points = p;
            }
        };


        static int tryConvert(String origin)
        {
            int temp;
            try
            {
                temp = Convert.ToInt16(origin);
                return temp;
            }
            catch (Exception e)
            {
                //Console.Error.WriteLine(e);
                Console.WriteLine("Invalid Entry. Please try again. ");
                return -1;
            }

        }

        static String convertString(String origin)
        {
            if (origin.Equals(""))
            {
                return "";
            }

            return origin.First().ToString().ToUpper() + origin.Substring(1).ToLower();
        }

        static void Main(string[] args)
        {
            int teamNumber = -1;
            List<SoccerTeam> tourney = new List<SoccerTeam>();

            Console.Write("How many teams? ");
            while (teamNumber == -1)
            {
                teamNumber = tryConvert(Console.ReadLine());
            }


            for (int i = 1; i <= teamNumber; i++)
            {
                String teamName = "";
                int points = -1;

                Console.Write("\n\nEnter Team " + i + "'s name: ");
                while (teamName.Equals(""))
                {
                    teamName = convertString(Console.ReadLine());
                }

                Console.Write("\nEnter " + teamName + "'s points: ");
                while (points < 0)  // When the points input is a convertable integer, then break the while loop and add the points to the team
                {
                    points = tryConvert(Console.ReadLine());
                }

                SoccerTeam team = new SoccerTeam(teamName, points);
                tourney.Add(team);

            }

            Console.Write("\n\nHere is the sorted list:");

            Console.Write("\n\n\nPosition\tName\t\t\tPoints");
            Console.Write("\n--------\t----\t\t\t------\n");

            List<SoccerTeam> results = tourney.OrderByDescending(o => o.points).ToList();

            foreach (SoccerTeam team in results)
            {
                Console.WriteLine((results.IndexOf(team) + 1) + "\t\t" + team.tName + "\t\t\t" + team.points);
            }

            Console.ReadLine();  // Pause the console before the app completes and closes

        }
    }
}

