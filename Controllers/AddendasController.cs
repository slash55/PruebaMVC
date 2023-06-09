using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Web;
using System.Web.Mvc;
using PruebaMVC;

namespace PruebaMVC.Controllers
{
    public class AddendasController : Controller
    {
        private Cer_AddendasEntities1 db = new Cer_AddendasEntities1();

        // GET: Addendas
        public ActionResult Index()
        {
            return View(db.Addendas.ToList());
        }

        // GET: Addendas/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addendas addendas = db.Addendas.Find(id);
            if (addendas == null)
            {
                return HttpNotFound();
            }
            return View(addendas);
        }

        // GET: Addendas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Addendas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAddenda,NombreAddenda,XML,FechaModificacion,Usuario,Estado")] Addendas addendas)
        {
            if (ModelState.IsValid)
            {
                addendas.IdAddenda = Guid.NewGuid();
                db.Addendas.Add(addendas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addendas);
        }

        // GET: Addendas/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addendas addendas = db.Addendas.Find(id);
            if (addendas == null)
            {
                return HttpNotFound();
            }
            return View(addendas);
        }

        // POST: Addendas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAddenda,NombreAddenda,XML,FechaModificacion,Usuario,Estado")] Addendas addendas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addendas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addendas);
        }

        // GET: Addendas/Edit2/5
        public ActionResult Edit2(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addendas addendas = db.Addendas.Find(id);
            if (addendas == null)
            {
                return HttpNotFound();
            }
            return View(addendas);
        }

        // POST: Addendas/Edit2/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit2([Bind(Include = "IdAddenda,NombreAddenda,XML,FechaModificacion,Usuario,Estado")] Addendas addendas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addendas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addendas);
        }

        // GET: Addendas/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Addendas addendas = db.Addendas.Find(id);
            if (addendas == null)
            {
                return HttpNotFound();
            }
            return View(addendas);
        }

        // POST: Addendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Addendas addendas = db.Addendas.Find(id);
            db.Addendas.Remove(addendas);
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
        public ActionResult pdf()
        {
            return Redirect("https://int.certifac.mx:9006/");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult pdf(pdf datos)
        {
            if (ModelState.IsValid)
            {

                datos.cfdi64 = @"C:\Users\IVAN\source\repos\PruebaMVC\XML\ejemplo_cfdi.XML";
                datos.cfdiState = "EMIT";
                datos.isFree = "False";
                datos.logo64 = "";
                datos.informacionAdicional = null;
                datos.infoNofiscal = " ";                               
                return Redirect("https://int.certifac.mx:9006/inputMessage?datos");               
            }
            //return Redirect("https://int.certifac.mx:9006/");
            return RedirectToAction("Index");
        }
    }
}
