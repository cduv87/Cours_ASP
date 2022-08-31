namespace TpPizza.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using TpPizza.business.Models;

    public class PizzaViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }
        public PateViewModel Pate { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; } = new List<IngredientViewModel>();

        public string StringIngredients => string.Join("' ", Ingredients.Select(i => i.Nom));

        public static PizzaViewModel PizzaToPizzaVM(Pizza p) => new PizzaViewModel { Id = p.Id, Nom = p.Nom, Pate = PateViewModel.PateToPateVM(p.Pate), Ingredients = p.Ingredients.Select(IngredientViewModel.IngretoIngreVM).ToList()};
        public static Pizza PizzaVMToPizza(PizzaViewModel pvm) => new Pizza { Id = pvm.Id, Nom = pvm.Nom, Pate = PateViewModel.PateVMToPate(pvm.Pate) };
    }
}
