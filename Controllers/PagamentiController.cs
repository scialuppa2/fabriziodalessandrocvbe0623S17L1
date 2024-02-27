using esercizioS17L1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace esercizioS17L1.Controllers
{
    public class PagamentiController : Controller
    {
        // Azione per visualizzare l'elenco dei pagamenti di un dipendente specifico
        public ActionResult Index(int dipendenteID)
        {
            var pagamenti = PagamentoRepository.GetPagamentiByDipendenteID(dipendenteID);
            return View(pagamenti);
        }

        // Azione per creare un nuovo pagamento per un dipendente specifico
        public ActionResult Create()
        {
            var dipendenti = DipendenteRepository.GetDipendenti();
            ViewBag.DipendentiList = new SelectList(dipendenti, "ID", "NomeCompleto");
            return View();
        }


        [HttpPost]
        public ActionResult Create(Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                PagamentoRepository.AddPagamento(pagamento);
                return RedirectToAction("Index", new { dipendenteID = pagamento.DipendenteID });
            }
            return View(pagamento);
        }

        // Azione per visualizzare i dettagli di un pagamento
        public ActionResult Details(int id)
        {
            var pagamento = PagamentoRepository.GetPagamentoById(id);
            return View(pagamento);
        }

        // Azione per modificare un pagamento esistente
        public ActionResult Edit(int id)
        {
            var pagamento = PagamentoRepository.GetPagamentoById(id);
            return View(pagamento);
        }

        [HttpPost]
        public ActionResult Edit(int id, Pagamento pagamento)
        {
            if (ModelState.IsValid)
            {
                PagamentoRepository.UpdatePagamento(pagamento);
                return RedirectToAction("Index", new { dipendenteID = pagamento.DipendenteID });
            }
            return View(pagamento);
        }

        // Azione per eliminare un pagamento
        public ActionResult Delete(int id)
        {
            var pagamento = PagamentoRepository.GetPagamentoById(id);
            return View(pagamento);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var pagamento = PagamentoRepository.GetPagamentoById(id);
            PagamentoRepository.DeletePagamento(id);
            return RedirectToAction("Index", new { dipendenteID = pagamento.DipendenteID });
        }
    }
}
