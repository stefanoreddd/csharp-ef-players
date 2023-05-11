using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace C__Entity_Framework_Players
{
    public class Players
    {
        [Key]
        public int PlayerId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Surname { get; set; }

        [MaxLength(50)]
        public int Score { get; set; }
        
        [MaxLength(50)]
        public int GamesPlayed { get; set; }

        [MaxLength(50)]
        public int GamesWon { get; set; }


        public Players(int playerId, string name, string surname, int score, int gamesPlayed, int gamesWon)
        {
            PlayerId = playerId;
            Name = name;
            Surname = surname;
            Score = score;
            GamesPlayed = gamesPlayed;
            GamesWon = gamesWon;

            /*Random random = new Random();

            Score = random.Next(11);
            GamesPlayed = random.Next(1, 101);
            GamesWon = random.Next(1, gamesPlayed);*/
        }

        public override string ToString()
        {
            string playerInfo = "- Nome: " + Name;
            playerInfo += "- Cognome: " + Surname;
            playerInfo += "- Punteggio: " + Score;
            playerInfo += "- Partite giocate: " + GamesPlayed;
            playerInfo += "- Partite vinte: " + GamesWon;
            return playerInfo;
        }
    }
}
