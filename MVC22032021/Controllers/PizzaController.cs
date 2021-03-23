using Data;
using Model;
using System.Web.Mvc;

namespace MVC22032021.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            var lst = this.Crud().Select();
            return View(lst);
        }
        //criar
        public ActionResult Create()
        {
            return View();
        }
        //IMPORTANTE *Metodo de envio dos dados
        [HttpPost]
        //evitar que se falsifique o envio de dados para o servidor.Receba apanas requisiçoes do controller
        [ValidateAntiForgeryToken]

        public ActionResult Create(Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                this.Crud().Insert(pizza);
                return RedirectToAction("Index");
            }
            return View(pizza);
        }
        //atualizar
        public ActionResult Edit(int id)
        {
            var pizza = this.Crud().SelectById(id);
            return View(pizza);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        //ler
        public ActionResult Edit(Pizza pizza)
        {
            if (ModelState.IsValid)  
            {
                this.Crud().Update(pizza);
                return RedirectToAction("Index");
            }
            return View(pizza);
        }
        public ActionResult Details(int id)
        {
            var pizza = this.Crud().SelectById(id);
            return View(pizza);
        }
        //delete
        public ActionResult Delete(int id)
        {
            var pizza = this.Crud().SelectById(id);
            return View(pizza);
        }

        /*O ActionName precisa ser o mesmo "Delete", como a orientacao a objetos não permite métodos com o mesmo nome e parametros é necessario utilizar esse recurso*/
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirm(int id)
        {
            this.Crud().Delete(id);
            return RedirectToAction("Index");
        }
        private IPizzaDB Crud()
        {
            return new PizzaDB();
        }
    }
}