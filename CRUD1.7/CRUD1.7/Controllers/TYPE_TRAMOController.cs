using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUD1._7.Models;

namespace CRUD1._7.Controllers
{
    public class TYPE_TRAMOController : Controller
    {
        private PruebaProsis2DB db = new PruebaProsis2DB();
        public ActionResult Index()
        {
            var data = db.TYPE_TRAMO.ToList();
            var model = new ModeloVirtual();
            var selectTramos = new List<tramos>();
            var selectPlazas = new List<plazas>();
            var selectCarriles = new List<carriles>();

            foreach (var item in data)
            {
                selectTramos.Add(new tramos
                {
                    idenTramo = item.idenTramo,
                    idTramo = item.idTramo,
                    nomTramo = item.nomTramo
                }
                );
            }
            model.Tramos = selectTramos;
            model.Plazas = selectPlazas;
            model.Carriles = selectCarriles;
            return View(model);
        }
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPE_TRAMO tYPE_TRAMO = db.TYPE_TRAMO.Find(id);
            if (tYPE_TRAMO == null)
            {
                return HttpNotFound();
            }
            return View(tYPE_TRAMO);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idenTramo,idTramo,nomTramo")] TYPE_TRAMO tYPE_TRAMO)
        {
            if (ModelState.IsValid)
            {
                db.TYPE_TRAMO.Add(tYPE_TRAMO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tYPE_TRAMO);
        }
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPE_TRAMO tYPE_TRAMO = db.TYPE_TRAMO.Find(id);
            if (tYPE_TRAMO == null)
            {
                return HttpNotFound();
            }
            return View(tYPE_TRAMO);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idenTramo,idTramo,nomTramo")] TYPE_TRAMO tYPE_TRAMO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tYPE_TRAMO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tYPE_TRAMO);
        }
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPE_TRAMO tYPE_TRAMO = db.TYPE_TRAMO.Find(id);
            if (tYPE_TRAMO == null)
            {
                return HttpNotFound();
            }
            return View(tYPE_TRAMO);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TYPE_TRAMO tYPE_TRAMO = db.TYPE_TRAMO.Find(id);
            db.TYPE_TRAMO.Remove(tYPE_TRAMO);
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
        public ActionResult VerPlaza(int id)
        {
            
            var plazasdetramo = db.TYPE_TRAMO.Join(db.TYPE_PLAZA, tra => tra.idenTramo, pla => pla.idTramo, (tra, pla) => new { tra, pla }).Where(x => x.pla.idTramo == id).ToList();
            var data = db.TYPE_TRAMO.ToList();
            var model = new ModeloVirtual();
            var selectTramos = new List<tramos>();
            var selectPlazas = new List<plazas>();
            var selectCarriles = new List<carriles>();
            if (plazasdetramo.Count != 0)
            {
                foreach (var item in plazasdetramo)
                {
                    selectPlazas.Add(new plazas
                    {
                        idenPlaza = item.pla.idenPlaza,
                        idPlaza = item.pla.idPlaza,
                        nomPlaza = item.pla.nomPlaza
                    });
                }

                selectTramos.Add(new tramos
                {
                    idenTramo = plazasdetramo.FirstOrDefault().tra.idenTramo,
                    idTramo = plazasdetramo.FirstOrDefault().tra.idTramo,
                    nomTramo = plazasdetramo.FirstOrDefault().tra.nomTramo
                });
            }
            else
            {
                foreach (var item in data)
                {
                    if(item.idenTramo == id)
                    {
                        selectTramos.Add(new tramos
                        {
                            idenTramo = item.idenTramo,
                            idTramo = item.idTramo,
                            nomTramo = item.nomTramo
                        });
                    }
                }

            }
            model.Tramos = selectTramos;
            model.Plazas = selectPlazas;
            model.Carriles = selectCarriles;
            return View("Index", model);

        }
        [HttpGet]
        public ActionResult EditPlaza(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPE_PLAZA pLAZA = db.TYPE_PLAZA.Find(id);
            ViewBag.idTramo = new SelectList(db.TYPE_TRAMO, "idenTramo", "nomTramo");
            if (pLAZA == null)
            {
                return HttpNotFound();
            }
            return View(pLAZA);
        } //GET Editar Tramos
        [HttpPost]
        public ActionResult EditPlaza(TYPE_PLAZA pLAZA)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.idTramo = new SelectList(db.TYPE_TRAMO, "idenTramo", "nomTramo", pLAZA.idTramo);
                    db.Entry(pLAZA).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("EditPlaza");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult CreatePlaza()
        {
            ViewBag.idTramo = new SelectList(db.TYPE_TRAMO, "idenTramo", "nomTramo");
            return View("CreatePlaza");
        }
        [HttpPost]
        public ActionResult CreatePlaza(TYPE_PLAZA pLAZA)
        {
            if (ModelState.IsValid)
            {
                ViewBag.idTramo = new SelectList(db.TYPE_TRAMO, "idenTramo", "nomTramo", pLAZA.idTramo);
                db.TYPE_PLAZA.Add(pLAZA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pLAZA);
        }
        public ActionResult DetailsPlaza(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPE_PLAZA pLAZA = db.TYPE_PLAZA.Find(id);
            if (pLAZA == null)
            {
                return HttpNotFound();
            }
            return View(pLAZA);
        }
        public ActionResult DeletePlaza(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPE_PLAZA pLAZA = db.TYPE_PLAZA.Find(id);
            if (pLAZA == null)
            {
                return HttpNotFound();
            }
            return View(pLAZA);
        }
        [HttpPost, ActionName("DeletePlaza")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedPlaza(int id)
        {
            TYPE_PLAZA pLAZA = db.TYPE_PLAZA.Find(id);
            db.TYPE_PLAZA.Remove(pLAZA);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult VerCarriles(int id)
        {
            var carrilesdeplaza = db.TYPE_PLAZA.Join(db.TYPE_CARRIL, pla => pla.idenPlaza, car => car.idPlaza, (pla, car) => new { pla, car }).Where(x => x.car.idPlaza == id).ToList();
            var data = db.TYPE_TRAMO.ToList();
            var model = new ModeloVirtual();
            var selectTramos = new List<tramos>();
            var selectPlazas = new List<plazas>();
            var selectCarriles = new List<carriles>();
            if (carrilesdeplaza != null && carrilesdeplaza.Count != 0)
            {
                foreach (var item in carrilesdeplaza)
                {
                    selectCarriles.Add(new carriles
                    {
                        idenCarril = item.car.idenCarril,
                        idCarril = item.car.idCarril,
                        numCarril = item.car.numCarril,
                        numTramo = item.car.numTramo
                    });
                }
                selectPlazas.Add(new plazas
                {
                    idenPlaza = carrilesdeplaza.FirstOrDefault().pla.idenPlaza,
                    idPlaza = carrilesdeplaza.FirstOrDefault().pla.idPlaza,
                    nomPlaza = carrilesdeplaza.FirstOrDefault().pla.nomPlaza,
                });
                int iddeltramo;

                iddeltramo = carrilesdeplaza.FirstOrDefault().pla.idTramo.Value;
 
                foreach (var item in db.TYPE_TRAMO)
                {
                    if(iddeltramo == item.idenTramo)
                    {
                        selectTramos.Add(new tramos
                        {
                            idenTramo = item.idenTramo,
                            nomTramo = item.nomTramo,
                            idTramo = item.idTramo
                        });
                    }
                }
                model.Plazas = selectPlazas;
                model.Tramos = selectTramos;
                model.Carriles = selectCarriles;
            }
            else
            {
                var dataTramo = db.TYPE_TRAMO.ToList();
                var dataPlaza = db.TYPE_PLAZA.ToList();

                foreach (var item in dataPlaza)
                {
                    if (item.idenPlaza == id)
                    {
                        selectPlazas.Add(new plazas
                        {
                            idenPlaza = item.idenPlaza,
                            idPlaza = item.idPlaza,
                            nomPlaza = item.nomPlaza
                        });
                    }
                }
                foreach (var item in dataPlaza)
                {
                    if(item.idenPlaza == selectPlazas.FirstOrDefault().idenPlaza)
                    {
                        selectTramos.Add(new tramos
                        {
                            idenTramo = item.idTramo.Value

                        });
                    }
                }
                foreach (var item in dataTramo)
                {
                    if(item.idenTramo == selectTramos.FirstOrDefault().idenTramo)
                    {
                        selectTramos.Clear();
                        selectTramos.Add(new tramos
                        {
                            idenTramo = item.idenTramo,
                            idTramo = item.idTramo,
                            nomTramo = item.nomTramo
                        });
                    }
                }
                model.Plazas = selectPlazas;
                model.Tramos = selectTramos;
                model.Carriles = selectCarriles;

            }
            return View("Index", model);
        }
        public ActionResult CreateCarril()
        {
            ViewBag.idPlaza = new SelectList(db.TYPE_PLAZA, "idenPlaza", "nomPlaza");
            return View();
        }
        [HttpPost]
        public ActionResult CreateCarril(TYPE_CARRIL cARRIL)
        {
            if (ModelState.IsValid)
            {
                ViewBag.idPlaza = new SelectList(db.TYPE_PLAZA, "idenPlaza", "nomPlaza", cARRIL.idPlaza);
                db.TYPE_CARRIL.Add(cARRIL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cARRIL);
        }
        public ActionResult EditCarril(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.idPlaza = new SelectList(db.TYPE_PLAZA, "idenPlaza", "nomPlaza");
            TYPE_CARRIL cARRIL = db.TYPE_CARRIL.Find(id);
            if (cARRIL == null)
            {
                return HttpNotFound();
            }
            return View(cARRIL);
        }
        [HttpPost]
        public ActionResult EditCarril(TYPE_CARRIL cARRIL)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.idPlaza = new SelectList(db.TYPE_TRAMO, "idenTramo", "nomTramo", cARRIL.idPlaza);
                    db.Entry(cARRIL).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("EditCarril");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult DetailsCarril(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPE_CARRIL cARRIL = db.TYPE_CARRIL.Find(id);
            if (cARRIL == null)
            {
                return HttpNotFound();
            }
            return View(cARRIL);
        }
        public ActionResult DeleteCarril (int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TYPE_CARRIL cARRIL = db.TYPE_CARRIL.Find(id);
            if (cARRIL == null)
            {
                return HttpNotFound();
            }
            return View(cARRIL);
        }
        [HttpPost, ActionName("DeleteCarril")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedCarril(int id)
        {
            TYPE_CARRIL cARRIL = db.TYPE_CARRIL.Find(id);
            db.TYPE_CARRIL.Remove(cARRIL);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
