using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EspaciosInteligentes.Mapping;
using EspaciosInteligentes.Models;
using EspaciosInteligentes.Persistence;
using EspaciosInteligentes.ViewModels;

namespace EspaciosInteligentes.Controllers
{
    public class ClientsController : Controller
    {
        private EIContext db = new EIContext();

        // GET: Clients
        public ActionResult Index() //éste método retorna la vista con la lista de clientes actualmente en la base de datos
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id) //éste método retorna una vista de detalle con el cliente recibiendo como parámetro el id del cliente
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }

            client.City = db.Cities.First(c => c.Id == client.CityId); //aquí carga la ciudad del cliente para mostrarla en el dropdownlist de ciudad
            
            return View(client); //aquí se manda a llamar la vista y se le asigna el cliente que es su modelo
        }

        // GET: Clients/Create
        public ActionResult Create() //éste método manda a llamar la vista para crear un cliente nuevo
        {
            var vm = new ClientViewModel()
            {
                CityList = GetCitySelectList(0)
            };

            return View(vm);
        }

        // POST: Clients/Create
        //éste método toma los datos de la forma de creación para crear un registro en la base de datos
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LastName,Email,Password,BirthDate,ContactNumber")] ClientViewModel clientVM, FormCollection form)
        {
            var cityId = Convert.ToInt32(form["City"]);

            if (db.Cities.Any(c => c.Id == cityId))
            {
                var city = db.Cities.First(c => c.Id == cityId);
                clientVM.City = city;
            }

            var mapper = new ClientMapper();

            var client = mapper.ClientViewModelToClient(clientVM); //éste método se utiliza para convertir el objeto ClientViewModel en un objeto Client
            
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientVM);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id) //éste método carga la vista de edición de un cliente existente
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);

            if (client == null)
            {
                return HttpNotFound();
            }

            var mapper = new ClientMapper();

            var vm = mapper.ClientToClientViewModel(client);

            vm.CityList = GetCitySelectList(client.CityId);

            return View(vm);
        }

        // POST: Clients/Edit/5
        //éste método guarda los cambios de un cliente existente tomando los datos de la forma
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,Email,Password,BirthDate,ContactNumber")] ClientViewModel clientVM, FormCollection form)
        {
            var cityId = Convert.ToInt32(form["City"]);

            if (db.Cities.Any(c => c.Id == cityId))
            {
                var city = db.Cities.First(c => c.Id == cityId);
                clientVM.City = city;
            }

            var mapper = new ClientMapper();

            var client = mapper.ClientViewModelToClient(clientVM);

            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientVM);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id) //éste método elimina el registro de un cliente y recibe como parámetro el id del cliente a eliminar
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) //éste método confirma si se va a eliminar el cliente, una vez que el usuario así lo decida
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public List<SelectListItem> GetCitySelectList(int id) //éste método carga las ciudades de la base de datos, en caso de recibir un parámetro distinto a cero utiliza el id para determinar qué ciudad debe estar seleccionada
        {
            var selectList = new List<SelectListItem>();

            selectList = db.Cities.Select(city => new SelectListItem { Value = city.Id.ToString(), Text = city.Name }).ToList();

            if (id != 0)
            {
                var index = selectList.FindIndex(c => Convert.ToInt32(c.Value) == id);
                selectList[index].Selected = true;
            }
            
            return selectList;
        }
    }
}
