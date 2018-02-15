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
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
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

            client.City = db.Cities.First(c => c.Id == client.CityId);
            
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            var vm = new ClientViewModel()
            {
                CityList = GetCitySelectList(0)
            };

            return View(vm);
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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

            var client = mapper.ClientViewModelToClient(clientVM);
            
            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientVM);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
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

        public List<SelectListItem> GetCitySelectList(int id)
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
