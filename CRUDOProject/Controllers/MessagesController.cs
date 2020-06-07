using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Repository.IRepo;
using Repository.Models;
using Repository.Models.View;

namespace CRUDOProject.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly IMessageRepo _repo;

        public MessagesController(IMessageRepo repo)
        {
            _repo = repo;
        }

        // GET: Messages
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            return View(_repo.GetMessagesForCurrentUser(userId));
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _repo.SetDateTime(id,DateTime.Now);
            _repo.SaveChanges();

            Message message = _repo.GetMessage(id);

            if (message == null)
            {
                return HttpNotFound();
            }
            if (!(message.RecipientId.Equals(User.Identity.GetUserId())))
            {
                return HttpNotFound("Brak dostępu");
            }

            return View(message);
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            MessageModelView msg = new MessageModelView();
            return View(msg);
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Content,SenderId,RecipientEmail")] MessageModelView message)
        {
            if (ModelState.IsValid)
            {
                if (_repo.IfExist(message.RecipientEmail))
                {
                    Message msg = new Message()
                    {
                        Content = message.Content,
                        SendTime = DateTime.Now,
                        RecipientId = _repo.GetRecipientIdByEmail(message.RecipientEmail),
                        Title = message.Title,
                        OpenTime = null,
                        SenderId = User.Identity.GetUserId()
                    };
                    _repo.SendMessage(msg);
                    _repo.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(message);
        }

        // GET: Messages/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Message message = db.Messages.Find(id);
        //    if (message == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(message);
        //}

        //// POST: Messages/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Title,Content,SendTime,OpenTime,SenderId,RecipientId")] Message message)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(message).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(message);
        //}

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Message message = _repo.GetMessage(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.DeleteMessage(id);
            _repo.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
