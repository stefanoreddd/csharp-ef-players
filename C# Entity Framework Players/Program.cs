using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using C__Entity_Framework_Players;

string connectionString = "Data Source=localhost;Initial Catalog=Players;Integrated Security=True";

bool continua = true;

while (continua)
{
    Console.WriteLine("GESTORE GIOCATORI");
    Console.WriteLine();
    Console.WriteLine("Seleziona un'opzione:");
    Console.WriteLine("1. Inserisci il nome di un giocatore: ");
    Console.WriteLine("2. Inserisci il cognome di un giocatore: ");
    Console.WriteLine("3. Cerca il giocatore per id: ");
    Console.WriteLine("4. Cancella un giocatore: ");
    Console.WriteLine("5. Esci");

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

            Console.WriteLine("Inserisci il punteggio: ");
            int punteggioGiocatore = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci il numero di partite giocate: ");
            int partiteGiocatore = int.Parse(Console.ReadLine());

            Console.WriteLine("Inserisci il numero di partite vinte: ");
            int partiteVinteGiocatore = int.Parse(Console.ReadLine());

            Players player = new Players(idGiocatore, nomeGiocatore, cognomeGiocatore, punteggioGiocatore, partiteGiocatore, partiteVinteGiocatore);

            using(PlayersContext db = new PlayersContext())
            {
                db.Add(player);
                db.SaveChanges();
            }

            break;
    }
}