﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrganizersController : Controller
    {
        private SeminarMaangementDBContext db = new SeminarMaangementDBContext();

        // GET: Organizers
        public ActionResult Index()
        {
            return View(db.Organizers.ToList());
        }

        // GET: Organizers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizer organizer = db.Organizers.Find(id);
            if (organizer == null)
            {
                return HttpNotFound();
            }
            return View(organizer);
        }

        // GET: Organizers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organizers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganizerID,OrganizerName,OrganizerEmail,OrganizerMobileNo,OrganizerAddress")] Organizer organizer)
        {
            if (ModelState.IsValid)
            {
                db.Organizers.Add(organizer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(organizer);
        }

        // GET: Organizers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizer organizer = db.Organizers.Find(id);
            if (organizer == null)
            {
                return HttpNotFound();
            }
            return View(organizer);
        }

        // POST: Organizers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganizerID,OrganizerName,OrganizerEmail,OrganizerMobileNo,OrganizerAddress")] Organizer organizer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(organizer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(organizer);
        }

        // GET: Organizers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Organizer organizer = db.Organizers.Find(id);
            if (organizer == null)
            {
                return HttpNotFound();
            }
            return View(organizer);
        }

        // POST: Organizers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Organizer organizer = db.Organizers.Find(id);
            db.Organizers.Remove(organizer);
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
