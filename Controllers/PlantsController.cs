using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HarvestHelp_PassionProject.Models;

namespace HarvestHelp_PassionProject.Controllers
{
    public class PlantsController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Plants
        public ActionResult Index()
        {
            return View(db.Plants.ToList());
        }

        // GET: Plants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plant plant = db.Plants.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            return View(plant);
        }

        // GET: Plants/Create
        public ActionResult Create()
        {
            // Checkboxes feature to provide users with plant zones selection options for when adding new plants.
            List<plantZones> zoneCheckboxesList = new List<plantZones>();

            zoneCheckboxesList.Add(new plantZones { ZoneId = "1a", zoneChecked = false });
            zoneCheckboxesList.Add(new plantZones { ZoneId = "1b", zoneChecked = false });
            zoneCheckboxesList.Add(new plantZones { ZoneId = "2a", zoneChecked = false });
            zoneCheckboxesList.Add(new plantZones { ZoneId = "2b", zoneChecked = false });
            zoneCheckboxesList.Add(new plantZones { ZoneId = "3a", zoneChecked = false });
            zoneCheckboxesList.Add(new plantZones { ZoneId = "3b", zoneChecked = false });
            zoneCheckboxesList.Add(new plantZones { ZoneId = "4a", zoneChecked = false });
            zoneCheckboxesList.Add(new plantZones { ZoneId = "4b", zoneChecked = false });
            zoneCheckboxesList.Add(new plantZones { ZoneId = "5a", zoneChecked = false });
            zoneCheckboxesList.Add(new plantZones { ZoneId = "5b", zoneChecked = false });
            zoneCheckboxesList.Add(new plantZones { ZoneId = "6a", zoneChecked = false });
            zoneCheckboxesList.Add(new plantZones { ZoneId = "6b", zoneChecked = false });
            zoneCheckboxesList.Add(new plantZones { ZoneId = "7a", zoneChecked = false });
            zoneCheckboxesList.Add(new plantZones { ZoneId = "7b", zoneChecked = false });
            zoneCheckboxesList.Add(new plantZones { ZoneId = "8a", zoneChecked = false });
            zoneCheckboxesList.Add(new plantZones { ZoneId = "8b", zoneChecked = false });
            zoneCheckboxesList.Add(new plantZones { ZoneId = "9a", zoneChecked = false });
            zoneCheckboxesList.Add(new plantZones { ZoneId = "9b", zoneChecked = false });

            ViewBag.zoneCheckboxesList = zoneCheckboxesList;

            return View();
        }

        // POST: Plants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlantId,PlantName,ZoneId,SowDate,HarvestDate,Sunlight,SoilType,FertilizerMix")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                db.Plants.Add(plant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plant);
        }

        // GET: Plants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plant plant = db.Plants.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            return View(plant);
        }

        // POST: Plants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlantId,PlantName,ZoneId,SowDate,HarvestDate,Sunlight,SoilType,FertilizerMix")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plant);
        }

        // GET: Plants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plant plant = db.Plants.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            return View(plant);
        }

        // POST: Plants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plant plant = db.Plants.Find(id);
            db.Plants.Remove(plant);
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
    }
}
