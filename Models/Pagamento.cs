using System.ComponentModel.DataAnnotations;

namespace esercizioS17L1.Models
{
    public class Pagamento
    {
        public int ID { get; set; }
        public int DipendenteID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Il campo Periodo è obbligatorio.")]
        [Display(Name = "Periodo")]
        public DateTime Periodo { get; set; }

        [Required(ErrorMessage = "Il campo Ammontare è obbligatorio.")]
        [Display(Name = "Ammontare")]
        public decimal Ammontare { get; set; }

        [Required(ErrorMessage = "Seleziona una tipologia di pagamento.")]
        [Display(Name = "Tipologia")]
        public string TipologiaPagamento { get; set; }
        public virtual Dipendente Dipendente { get; set; }
    }




    public static class PagamentoRepository
    {
        private static List<Pagamento> pagamenti = new List<Pagamento>();

        public static List<Pagamento> GetPagamenti()
        {
            return pagamenti;
        }

        public static void AddPagamento(Pagamento pagamento)
        {
            // Aggiungi il nuovo pagamento alla lista
            pagamenti.Add(pagamento);
        }

        public static Pagamento GetPagamentoById(int id)
        {
            // Trova il pagamento con l'ID specificato
            return pagamenti.FirstOrDefault(p => p.ID == id);
        }

        public static List<Pagamento> GetPagamentiByDipendenteID(int dipendenteID)
        {
            return pagamenti.Where(p => p.DipendenteID == dipendenteID).ToList();
        }


        public static void UpdatePagamento(Pagamento pagamento)
        {
            // Trova il pagamento nella lista e aggiorna i suoi dati
            var existingPagamento = pagamenti.FirstOrDefault(p => p.ID == pagamento.ID && p.DipendenteID == pagamento.DipendenteID);
            if (existingPagamento != null)
            {
                existingPagamento.Periodo = pagamento.Periodo;
                existingPagamento.Ammontare = pagamento.Ammontare;
                existingPagamento.TipologiaPagamento = pagamento.TipologiaPagamento; 
            }
        }



        public static void DeletePagamento(int id)
        {
            // Trova e rimuovi il pagamento con l'ID specificato dalla lista
            var pagamentoToRemove = pagamenti.FirstOrDefault(p => p.ID == id);
            if (pagamentoToRemove != null)
            {
                pagamenti.Remove(pagamentoToRemove);
            }
        }
    }

}
