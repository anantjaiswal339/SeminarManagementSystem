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
    public class ParticipantsController : Controller
    {
        private SeminarMaangementDBContext db = new SeminarMaangementDBContext();

        // GET: Participants
        public ActionResult Index()
        {
            var participants = db.Participants.Join(db.Seminars, p => p.SeminarID, s => s.SeminarID, (p, s) => new ParticipantViewModel
            {
                IsAttended = p.IsAttended,
                ParticipantDOB = p.ParticipantDOB,
                ParticipantEmail = p.ParticipantEmail,
                ParticipantID = p.ParticipantID,
                ParticipantMobileNo = p.ParticipantMobileNo,
                ParticipantName = p.ParticipantName,
                SeminarTitle = s.SeminarTitle
            });

            return View(participants.ToList());
        }

        // GET: Participants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            var result = new ParticipantViewModel
            {
                IsAttended = participant.IsAttended,
                ParticipantDOB = participant.ParticipantDOB,
                ParticipantEmail = participant.ParticipantEmail,
                ParticipantID = participant.ParticipantID,
                ParticipantMobileNo = participant.ParticipantMobileNo,
                ParticipantName = participant.ParticipantName,
                SeminarTitle = db.Seminars.Find(participant.SeminarID).SeminarTitle
            };
            return View(result);
        }

        // GET: Participants/Create
        public ActionResult Create()
        {
            ViewBag.Seminars = db.Seminars.ToList();
            return View();
        }

        // POST: Participants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParticipantID,SeminarID,ParticipantName,ParticipantEmail,ParticipantMobileNo,ParticipantDOB,IsAttended")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                db.Participants.Add(participant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(participant);
        }

        // GET: Participants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Seminars = db.Seminars.ToList();
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // POST: Participants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParticipantID,SeminarID,ParticipantName,ParticipantEmail,ParticipantMobileNo,ParticipantDOB,IsAttended")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(participant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(participant);
        }

        // GET: Participants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Participant participant = db.Participants.Find(id);
            if (participant == null)
            {
                return HttpNotFound();
            }
            return View(participant);
        }

        // POST: Participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Participant participant = db.Participants.Find(id);
            db.Participants.Remove(participant);
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
