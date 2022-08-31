using TpPizza.business.Models;

namespace TpPizza.business
{
    public class PizzaService
    {
        private static List<Ingredient> ingredients = Pizza.IngredientsDisponibles;
        private static List<Pate> pates = Pizza.PatesDisponibles;
        private static List<Pizza> pizzas = new List<Pizza>();

        /*PIZZAS*/
        public List<Pizza> GetListPizza()
        {
            return pizzas;
        }

        public void AddPizza(Pizza p) => pizzas.Add(p);

        public void EditPizza(int id, Pizza p)
        {
            var pizzaToEdit = pizzas.FirstOrDefault(p => p.Id == id);
            pizzaToEdit.Nom = p.Nom;
        }

        public void DeletePizza(int id) => pizzas.Remove(pizzas.Where(p => p.Id == id).First());


        /*PATES*/
        public List<Pate> GetListPates() => pates;
        public Pate GetPateById(int id) => pates.FirstOrDefault(p => p.Id == id);

        public void AddPate(Pate p) => pates.Add(p);

        public void EditPates(int id, Pate p)
        {
            var pateToEdit = pates.FirstOrDefault(p => p.Id == id);
            pateToEdit.Nom = p.Nom;
        }

        public void DeletePate(int id) => pates.Remove(pates.Where(p => p.Id == id).First());

        /*INGREDIENTS*/
        public List<Ingredient> GetListIngredients()
        {
            return ingredients;
        }

        public List<Ingredient> GetIngredientsByListId(List<int> lsId)
        {
            var listeIngredients = this.GetListIngredients();
            List<Ingredient> list = new List<Ingredient>();
            foreach (int id in lsId)
            list.Add((Ingredient)listeIngredients.FirstOrDefault(i => i.Id == id));
            return list;
            
        }

        public void AddIngredient(Ingredient i) => ingredients.Add(i);

        public void EditIngredients(int id, Ingredient i)
        {
            var ingredientToEdit = ingredients.FirstOrDefault(i => i.Id == id);
            ingredientToEdit.Nom = i.Nom;
        }

        public void DeleteIngredient(int id) => ingredients.Remove(ingredients.Where(i => i.Id == id).First());

    }
}