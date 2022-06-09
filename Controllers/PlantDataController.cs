using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HarvestHelp_PassionProject.Controllers
{
    public class PlantDataController : Controller
    {
        // GET: PlantData
        public ActionResult Index()
        {
            return View();
        }

        // GET: api/PlantData/ListPlants
        [HttpGet]
        public IEnumerable<PlantDto> ListPlants()
        {
            List<Plant> Plants = db.Plants.ToList();
            List<PlantDto> Planttos = new List<PlantDto>();

            Plants.ForEach(a => PlantDtos.Add(new PlantDto()
            {
                PlantID = a.PlantID,
                PlantName = a.PlantName,
                ZoneId = a.ZoneId,
                SowDate = a.SowDate,
                HarvestDate = a.HarvestDate,
                Sunlight = a.Sunlight,
                SoilType = a.SoilType,
                FertilizerMix = a.FertilizerMix
            }));

            return PlantDtos;
        }

        // GET: api/PlantData/FindPlant/5
        [ResponseType(typeof(Plant))]
        [HttpGet]
        public IHttpActionResult FindPlant(int id)
        {
            Plant Plant = db.Plants.Find(id);
            PlantDto PlantDto = new PlantDto()
            {
                PlantID = a.PlantID,
                PlantName = a.PlantName,
                ZoneId = a.ZoneId,
                SowDate = a.SowDate,
                HarvestDate = a.HarvestDate,
                Sunlight = a.Sunlight,
                SoilType = a.SoilType,
                FertilizerMix = a.FertilizerMix
            };
            if (Plant == null)
            {
                return NotFound();
            }

            return Ok(PlantDto);
        }

        // POST: api/PlantData/UpdatePlant/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdatePlant(int id, Plant Plant)
        {
            Debug.WriteLine("Update Plant method reached");
            if (!ModelState.IsValid)
            {
                Debug.WriteLine("Model State is invalid");
                return BadRequest(ModelState);
            }

            if (id != Plant.PlantID)
            {
                Debug.WriteLine("ID mismatch");
                Debug.WriteLine("GET parameter" + id);
                Debug.WriteLine("POST parameter" + Plant.PlantID);
                Debug.WriteLine("POST parameter" + Plant.PlantName);
                Debug.WriteLine("POST parameter " + Plant.ZoneId);
                Debug.WriteLine("POST parameter " + Plant.SowDate);
                Debug.WriteLine("POST parameter " + Plant.HarvestDate);
                Debug.WriteLine("POST parameter " + Plant.Sunlight);
                Debug.WriteLine("POST parameter " + Plant.SoilType);
                Debug.WriteLine("POST parameter " + Plant.FertilizerMix);
                return BadRequest();
            }

            db.Entry(Plant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantExists(id))
                {
                    Debug.WriteLine("Plant not found");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Debug.WriteLine("None of the conditions triggered");
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PlantData/AddPlant
        [ResponseType(typeof(Plant))]
        [HttpPost]
        public IHttpActionResult AddPlant(Plant Plant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Plants.Add(Plant);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = Plant.PlantID }, Plant);
        }

        // POST: api/PlantData/DeletePlant/5
        [ResponseType(typeof(Plant))]
        [HttpPost]
        public IHttpActionResult DeletePlant(int id)
        {
            Plant Plant = db.Plants.Find(id);
            if (Plant == null)
            {
                return NotFound();
            }

            db.Plants.Remove(Plant);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlantExists(int id)
        {
            return db.Plants.Count(e => e.PlantID == id) > 0;
        }

    }
}