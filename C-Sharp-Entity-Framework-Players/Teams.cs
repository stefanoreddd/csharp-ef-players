using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Entity_Framework_Players
{
    public class Teams
    {
        [Key]
        public int TeamId { get; set; }
        [MaxLength(50)]
        public string TeamName { get; set; }
        [MaxLength(50)]
        public string TeamCity { get; set; }
        [MaxLength (50)]
        public string TeamCoach { get; set; }
        [MaxLength(50)]
        public string TeamColors { get; set; }
        public List<Players> PlayersList { get; set; }


        public Teams (int teamId, string teamName, string teamCity, string teamCoach, string teamColors)
        {
            TeamId = teamId;
            TeamName = teamName;
            TeamCity = teamCity;
            TeamCoach = teamCoach;
            TeamColors = teamColors;
            PlayersList = new List<Players> ();
        }


        public override string ToString()
        {
            string teamsInfo = "Nome squadra: " + TeamName + "\n";
            teamsInfo += "Città: " + TeamCity + "\n";
            teamsInfo += "Allenatore: " + TeamCoach + "\n";
            teamsInfo += "Colori: " + TeamColors + "\n";
            
            return teamsInfo;
        }
    }
}
