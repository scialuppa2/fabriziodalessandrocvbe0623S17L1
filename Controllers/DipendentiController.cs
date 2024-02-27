using esercizioS17L1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace esercizioS17L1.Controllers
{
    public class DipendentiController : Controller
    {
        // Azione per visualizzare l'elenco dei dipendenti
        public ActionResult Index()
        {
            var dipendenti = DipendenteRepository.GetDipendenti();
            return View(dipendenti);
        }

        // Azione per creare un nuovo dipendente
        public IActionResult Create()
        {
            var dipendenti = DipendenteRepository.GetDipendenti();
            ViewBag.Dipendenti = dipendenti.Any() ? new SelectList(dipendenti, "ID", "NomeCompleto") : null;
            return View();
        }



        [HttpPost]
        public ActionResult Create(Dipendente dipendente)
        {
            if (ModelState.IsValid)
            {
                DipendenteRepository.AddDipendente(dipendente);

                // Ricarica la lista dei dipendenti
                var dipendenti = DipendenteRepository.GetDipendenti();
                ViewBag.Dipendenti = new SelectList(dipendenti, "ID", "NomeCompleto");

                return RedirectToAction("Index");
            }
            return View(dipendente);
        }


        // Azione per visualizzare i dettagli di un dipendente
        public ActionResult Details(int id)
        {
            var dipendente = DipendenteRepository.GetDipendenteById(id);
            return View(dipendente);
        }

        // Azione per modificare un dipendente esistente
        public ActionResult Edit(int id)
        {
            var dipendente = DipendenteRepository.GetDipendenteById(id);
            return View(dipendente);
        }

        [HttpPost]
        public ActionResult Edit(Dipendente dipendente)
        {
            if (ModelState.IsValid)
            {
                DipendenteRepository.UpdateDipendente(dipendente);
                return RedirectToAction("Index");
            }
            return View(dipendente);
        }

        // Azione per eliminare un dipendente
        public ActionResult Delete(int id)
        {
            var dipendente = DipendenteRepository.GetDipendenteById(id);
            return View(dipendente);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                DipendenteRepository.DeleteDipendente(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Log dell'eccezione per debug
                Console.WriteLine(ex.Message);

                // Reindirizza a una vista di errore specifica
                return View("Errore");
            }
        }

    }

}
