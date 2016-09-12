﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerTourney
{
    class Program
    {
        // Basic Object of a team, could be of any type of sport. Only needs a Name, Wins, and Losses
        class Team
        {
            public string tName;
            public int wins;
            public int loss;

        };

        // This is an implementation of the Game class, representing the interaction of teams
        class Game
        {
            Random rand = new Random();
            public int goalsFor;
            public int goalsAgainst;
            public int differential;

            public Game()
            {
                goalsAgainst = rand.Next(0, 10);
                goalsFor = rand.Next(0, 10);
                differential = goalsFor - goalsAgainst;
            }
        };

        // This is a specific child-class of the Team base class
        class SoccerTeam : Team
        {
            public int draw;
            public int points;
            public List<Game> matches;

            public SoccerTeam(String name, int p)
            {
                tName = name;
                points = p;
                matches = new List<Game>();
            }
        };

        /**
          * @desc tryConvert - attempts conversion of string to integer. If successful, returns converted int. If fail, returns -1
          * @param string origin - input from user into the app, in the form of a string, hopefully an integer
          * @return integer - converted string to integer value. If fail, return -1
        */
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

        /**
          * @desc convertString - takes any input string and converts it to 
          * @param string origin - original string inputed by the user
          * @return string - if the original string was blank, return blank string. Else, capitalize the first letter and lowercase the rest of the string.
        */
        static String convertString(String origin)
        {
            if (origin.Equals(""))
            {
                return "";
            }

            return origin.First().ToString().ToUpper() + origin.Substring(1).ToLower();
        }


        // MARK: Main Function

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

                // When the points input is a convertable integer, then break the while loop and add the points to the team
                while (points < 0)
                {
                    points = tryConvert(Console.ReadLine());
                }

                SoccerTeam team = new SoccerTeam(teamName, points);
                tourney.Add(team);

            }



            // MARK: Begin output of table.

            Console.Write("\n\nHere is the sorted list:");

            Console.Write("\n\n\nPosition\tName\t\t\tPoints");
            Console.Write("\n--------\t----\t\t\t------\n");

            List<SoccerTeam> results = tourney.OrderByDescending(o => o.points).ToList();

            // Populate the table of results
            foreach (SoccerTeam team in results)
            {
                Console.WriteLine((results.IndexOf(team) + 1) + "\t\t" + team.tName + "\t\t\t" + team.points);
            }

            // Pause the console before the app completes and closes
            Console.ReadLine();

        }
    }
}