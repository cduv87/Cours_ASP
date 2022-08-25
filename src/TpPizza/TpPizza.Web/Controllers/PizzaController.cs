using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TpPizza.business;
using TpPizza.Web.Models;
using TpPizza.Web.ViewModels;

namespace TpPizza.Web.Controllers
{   
    


    public class PizzaController : Controller
    {
        private readonly PizzaService pizzaService;

        public PizzaController(PizzaService pizzaService)
        {
            this.pizzaService = pizzaService;
        }

        
        // GET: PizzaController
        public ActionResult Index()
        {
            return View(pizzaService.GetListPizza().Select(p => PizzaViewModel.PizzaToPizzaVM(p)));
        }

        // GET: PizzaController/Details/5
        public ActionResult Details(int id)
        {
            return View(PizzaViewModel.PizzaToPizzaVM(pizzaService.GetListPizza().First(p => p.Id == id)));
        }

        // GET: PizzaController/Create
        public ActionResult Create()
        {
            this.ViewData["Pates"] = pizzaService.GetListPates().Select(PateViewModel.PateToPateVM).ToList();
            this.ViewData["Ingredients"] = pizzaService.GetListIngredients().Select(IngredientViewModel.IngretoIngreVM).ToList();
            return View();
        }

        // POST: PizzaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PizzaFormViewModel pizzaFVM)
        {
            try
            {   
                pizzaService.AddPizza(PizzaFormViewModel.PizzaFVMToPizza(pizzaFVM, pizzaService.GetPateById(pizzaFVM.PateId), pizzaService.GetIngredientsByListId(pizzaFVM.IngredientsId)));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(PizzaViewModel.PizzaToPizzaVM(pizzaService.GetListPizza().First(p => p.Id == id)));
        }

        // POST: PizzaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PizzaViewModel pizzaVM)
        {
            try
            {   var pizzaToEdit = PizzaViewModel.PizzaVMToPizza(pizzaVM);
                pizzaService.EditPizza(id, pizzaToEdit);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PizzaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(PizzaViewModel.PizzaToPizzaVM(pizzaService.GetListPizza().First(p => p.Id == id)));
        }

        // POST: PizzaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                pizzaService.DeletePizza(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
