namespace TpPizza.Web.ViewModels
{
    using BO;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Cryptography.Xml;
    using TpPizza.business;

    public class PizzaFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }
        public int PateId { get; set; }
        public List<int> IngredientsId { get; set; } = new List<int>();

        public static Pizza PizzaFVMToPizza(PizzaFormViewModel pvfm, Pate pate, List<Ingredient> list)
        {
            Pizza p = new Pizza { Id = pvfm.Id, Nom = pvfm.Nom, Pate = pate, Ingredients = list };
            return p;
        }
    }
}
