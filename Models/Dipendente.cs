namespace esercizioS17L1.Models
{
    public class Dipendente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string CodiceFiscale { get; set; }
        public bool Coniugato { get; set; }
        public int NumeroFigliACarico { get; set; }
        public string Mansione { get; set; }
        public string NomeCompleto => $"{Nome} {Cognome}";

    }

    public static class DipendenteRepository
    {
        private static List<Dipendente> dipendenti = new List<Dipendente>();

        public static List<Dipendente> GetDipendenti()
        {
            return dipendenti.ToList();
        }


        public static void AddDipendente(Dipendente dipendente)
        {
            // Assegnazione di un ID univoco basato sul numero di dipendenti già presenti
            dipendente.ID = dipendenti.Count > 0 ? dipendenti.Max(d => d.ID) + 1 : 1;
            dipendenti.Add(dipendente);
        }


        public static Dipendente GetDipendenteById(int id)
        {
            return dipendenti.FirstOrDefault(d => d.ID == id);
        }

        public static void UpdateDipendente(Dipendente dipendente)
        {
            var existingDipendente = dipendenti.FirstOrDefault(d => d.ID == dipendente.ID);
            if (existingDipendente != null)
            {
                existingDipendente.Nome = dipendente.Nome;
                existingDipendente.Cognome = dipendente.Cognome;
                existingDipendente.Indirizzo = dipendente.Indirizzo;
                existingDipendente.CodiceFiscale = dipendente.CodiceFiscale;
                existingDipendente.Coniugato = dipendente.Coniugato;
                existingDipendente.NumeroFigliACarico = dipendente.NumeroFigliACarico;
                existingDipendente.Mansione = dipendente.Mansione;
            }
        }

        public static void DeleteDipendente(int id)
        {
            var dipendenteToRemove = dipendenti.FirstOrDefault(d => d.ID == id);
            if (dipendenteToRemove != null)
            {
                dipendenti.Remove(dipendenteToRemove);
            }
        }
    }
}
