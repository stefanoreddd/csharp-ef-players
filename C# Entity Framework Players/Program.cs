using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using C__Entity_Framework_Players;
using static System.Formats.Asn1.AsnWriter;

string connectionString = "Data Source=localhost;Initial Catalog=Players;Integrated Security=True";

bool continua = true;

while (continua)
{
    Console.WriteLine("GESTORE GIOCATORI");
    Console.WriteLine();
    Console.WriteLine("Seleziona un'opzione:");
    Console.WriteLine("1. Inserisci un nuovo giocatore: ");
    Console.WriteLine("2. Cerca un giocatore per nome: ");
    Console.WriteLine("3. Cerca un giocatore per id: ");
    Console.WriteLine("4. Modifica un giocatore: ");
    Console.WriteLine("5. Cancella un giocatore: ");
    Console.WriteLine("6. Esci");

    Console.WriteLine("Inserisci l'opzione desiderata: ");
    int response = int.Parse(Console.ReadLine());

    switch (response)
    {
        case 1:
            Console.WriteLine("Inserisci il nome del giocatore: ");
            string nomeGiocatore = Console.ReadLine();

            Console.WriteLine("Inserisci il cognome del giocatore: ");
            string cognomeGiocatore = Console.ReadLine();

            Console.WriteLine("Inserisci l'id del giocatore: ");
            int idGiocatore = int.Parse(Console.ReadLine());


            Random random = new Random();

            int punteggioGiocatore = random.Next(11);
            int partiteGiocatore = random.Next(1, 101);
            int partiteVinteGiocatore = random.Next(1, partiteGiocatore);

            Players player = new Players(idGiocatore, nomeGiocatore, cognomeGiocatore, punteggioGiocatore, partiteGiocatore, partiteVinteGiocatore);

            using(PlayersContext db = new PlayersContext())
            {
                db.Add(player);
                db.SaveChanges();
            }

            break;

        case 2:
            Console.WriteLine("Inserisci il nome del giocatore da visualizzare: ");
            string giocatoreDaVisualizzare = Console.ReadLine();

            using (PlayersContext db = new PlayersContext())
            {
                List<Players> playersFound = db.Players.Where(playersSearched => playersSearched.Name.Contains(giocatoreDaVisualizzare)).ToList<Players>();

                foreach (Players p in playersFound)
                {
                    Console.WriteLine(p.ToString());
                }
            }

            break;

        case 3:
            Console.WriteLine("Inserisci l'id del giocatore da visualizzare: ");
            int idDaVisualizzare = int.Parse(Console.ReadLine());

            using (PlayersContext db = new PlayersContext())
            {
                List<Players> playersFound = db.Players.Where(playersSearched => playersSearched.PlayerId.Equals(idDaVisualizzare)).ToList<Players>();

                foreach (Players p in playersFound)
                {
                    Console.WriteLine(p.ToString());
                }
            }

            break;

        case 4:
            Console.WriteLine("Inserisci l'id del giocatore da modificare: ");
            int playerToEdit = int.Parse(Console.ReadLine());
            
            using (PlayersContext db = new PlayersContext())
            {
                Players playersToUpdate = db.Players.Where(playersSearched => playersSearched.PlayerId.Equals(playerToEdit)).First();
                Console.WriteLine(playersToUpdate.ToString());

                Console.WriteLine("Qual è il nuovo nome?");
                string newName = Console.ReadLine();
                newName = playersToUpdate.Name;

                Console.WriteLine("Qual è il nuovo cognome?");
                string newSurname = Console.ReadLine();
                newSurname = playersToUpdate.Surname;
            }

            break;

        case 5:
            Console.WriteLine("Inserisci l'id del giocatore da cancellare: ");
            int playerToDelete = int.Parse(Console.ReadLine());

            using (PlayersContext db = new PlayersContext())
            {
                Players playerToCancel = db.Players.Where(playerSearched => playerSearched.PlayerId.Equals(playerToDelete)).First();

                db.Remove(playerToCancel);
                db.SaveChanges();
            }

            break;

        case 6:
            Console.WriteLine("Grazie e arrivederci!");
            continua = false;

            break;

        default:
            Console.WriteLine("Non hai inserito un'opzione valida: ritenta.");
            break;
    }
}