using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpPizza.business;
using TpPizza.Web.ViewModels;

namespace TpPizza.Web.Controllers
{
    public class PateController : Controller
    {
        private readonly PizzaService pizzaService;

        public PateController(PizzaService pizzaService)
        {
            this.pizzaService = pizzaService;
        }

        // GET: PateController
        public ActionResult Index()
        {   
            return View(pizzaService.GetListPates().Select(p => PateViewModel.PateToPateVM(p)));
        }

        // GET: PateController/Details/5
        public ActionResult Details(int id)
        {
            return View(PateViewModel.PateToPateVM(pizzaService.GetListPates().First(p => p.Id == id)));
        }

        // GET: PateController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PateController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PateViewModel pateVM)
        {
            try
            {
                pizzaService.AddPate(PateViewModel.PateVMToPate(pateVM));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PateController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(PateViewModel.PateToPateVM(pizzaService.GetListPates().First(p => p.Id == id)));
        }

        // POST: PateController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PateViewModel pateVM)
        {
            try
            {
                pizzaService.EditPates(id, PateViewModel.PateVMToPate(pateVM));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PateController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(PateViewModel.PateToPateVM(pizzaService.GetListPates().First(p => p.Id == id)));
        }

        // POST: PateController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                pizzaService.DeletePate(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
