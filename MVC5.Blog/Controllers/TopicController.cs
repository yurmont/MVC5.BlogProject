using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using Blog.Mvc.Models;
using IdentitySample.Models;

namespace Blog.Mvc.Controllers
{
    public class TopicController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Topic/
        public ActionResult Index()
        {
            return View(db.Topics.ToList());
        }

        // GET: /Topic/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // GET: /Topic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Topic/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Title,Content,CreationDate,TopicId")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                db.Topics.Add(topic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(topic);
        }

        // GET: /Topic/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // POST: /Topic/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Title,Content,CreationDate,TopicId")] Topic topic)
        {
            if (ModelState.IsValid)
            {
                var actualTopic = db.Topics.FirstOrDefault(x => x.Id == topic.Id);
                actualTopic.Title = topic.Title;
                actualTopic.Content = topic.Content;

                db.Entry(actualTopic).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(topic);
        }

        // GET: /Topic/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Topic topic = db.Topics.Find(id);
            if (topic == null)
            {
                return HttpNotFound();
            }
            return View(topic);
        }

        // POST: /Topic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Topic topic = db.Topics.Find(id);
            db.Topics.Remove(topic);
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

        public ActionResult Subscribe(int id)
        {
            var topic = db.Topics.Find(id);
            var existingSubscription = db.Subscriptions.FirstOrDefault(x => x.Topic.Id == id && x.UserId == User.Identity.Name);

            if (existingSubscription != null)
            {
                var subscription = new Subscription()
                {
                    Topic = topic,
                    UserId = User.Identity.Name
                };

                db.Subscriptions.Add(subscription);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
