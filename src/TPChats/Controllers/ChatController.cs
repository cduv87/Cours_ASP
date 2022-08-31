namespace TPChats.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPChats.Models;

public class ChatController : Controller
{
    private static List<ChatViewModel> ls = ChatViewModel.GetMeuteDeChats();
    
    // GET: ChatController
    public ActionResult Index()
    {
        
        return View(ls);
    }

    // GET: ChatController/Details/5
    public ActionResult Details(int id)
    {
        return View(ls.First(c => c.Id == id));
    }

    // GET: ChatController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ChatController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(ChatViewModel chat)
    {
        try
        {
            ls.Add(chat);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    /*ici version pure Form*/

    /*
        // POST: ChatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            int id = Convert.ToInt32(collection["id"]);
            var nom = Convert.ToString(collection["nom"]);
            int age = Convert.ToInt32(collection["age"]);
            var couleur = Convert.ToString(collection["couleur"]);
            ls.Add(new ChatViewModel { Id = id, Nom = nom, Age = age, Couleur = couleur});
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    */
    // GET: ChatController/Delete/5
    public ActionResult Delete(int id)
    {
       
        return View(ls.First(c => c.Id == id));
    }

    // POST: ChatController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        ls.Remove(ls.Where(ls => ls.Id == id).First());

        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
