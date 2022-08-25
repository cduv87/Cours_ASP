using BO;

namespace TpPizza.Web.ViewModels
{
    public class IngredientViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public static IngredientViewModel IngretoIngreVM(Ingredient i) => new IngredientViewModel { Id = i.Id, Nom = i.Nom };
        public static Ingredient IngreVMtoIngre(IngredientViewModel ivm) => new Ingredient { Id = ivm.Id, Nom = ivm.Nom };

    }



}
