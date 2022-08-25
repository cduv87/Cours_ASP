using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpPizza.business;
using TpPizza.Web.ViewModels;

namespace TpPizza.Web.Controllers
{
    public class IngredientController : Controller
    {
        private readonly PizzaService pizzaService;

        public IngredientController(PizzaService pizzaService)
        {
            this.pizzaService = pizzaService;
        }

        // GET: IngredientController
        public ActionResult Index()
        {
            return View(pizzaService.GetListIngredients().Select(i => IngredientViewModel.IngretoIngreVM(i)));
        }

        // GET: IngredientController/Details/5
        public ActionResult Details(int id)
        {
            return View(IngredientViewModel.IngretoIngreVM(pizzaService.GetListIngredients().First(i => i.Id == id)));
        }

        // GET: IngredientController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngredientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IngredientViewModel ingredientVM)
        {
            try
            {
                pizzaService.AddIngredient(IngredientViewModel.IngreVMtoIngre(ingredientVM));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IngredientController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(IngredientViewModel.IngretoIngreVM(pizzaService.GetListIngredients().First(i => i.Id == id)));
        }

        // POST: IngredientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IngredientViewModel ingredientVM)
        {
            try
            {
                pizzaService.EditIngredients(id, IngredientViewModel.IngreVMtoIngre(ingredientVM));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IngredientController/Delete/5
        public ActionResult Delete(int id)
        {

            return View(IngredientViewModel.IngretoIngreVM(pizzaService.GetListIngredients().First(i => i.Id == id)));
        }

        // POST: IngredientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                pizzaService.DeleteIngredient(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
