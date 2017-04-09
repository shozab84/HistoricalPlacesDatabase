using DatabaseTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseTest.Models;
using System.Data.Entity;
using DatabaseTest.Context;

namespace DatabaseTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private HistDBContext db = new HistDBContext();
        public ActionResult Index()
        {

           return View(db.HistoricalTable.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HistoricalPlaces place)
        {
            if (place.Picture == null)
            {
                place.Picture = "http://tinyurl.com/gmygven";
            }

            if (ModelState.IsValid)
            {
                
                db.HistoricalTable.Add(place);
                //Saving changes
                db.SaveChanges();

                //return to index page
                return RedirectToAction("Index");
            } else
            {
                return View(place);
            }
        }


        public ActionResult Details(int id)
        {
            HistoricalPlaces myPlace = db.HistoricalTable.Find(id);
            return View(myPlace);
        }
        
        // Writing method for Edit
        public ActionResult Edit(int? id)
        {
            HistoricalPlaces myPlace = db.HistoricalTable.Find(id);// we are selecting a record from the table

            return View(myPlace);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id, Name, State, Year, Picture, History, Architecture")]  HistoricalPlaces myPlace)
        {
            if (myPlace.Picture == null)
            {
                myPlace.Picture = "http://tinyurl.com/gmygven";
            }


            if (ModelState.IsValid)
            {
                //
                db.Entry(myPlace).State = EntityState.Modified;
                
                //Save changes
                db.SaveChanges();
                
                //return to the index page
                return RedirectToAction("Index");
            }
            return View(myPlace);
        }

        // writing method for Delete

        public ActionResult Delete(int?id)// method for delete (Select Delete from here, right click and create View)
        {
            HistoricalPlaces myPlace = db.HistoricalTable.Find(id);
            return View(myPlace);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)// method for confirming delete 
        {
            //find the record to be deleted again
            HistoricalPlaces myPlace = db.HistoricalTable.Find(id);

            //delete from the database
            db.HistoricalTable.Remove(myPlace);

            //Save changes
            db.SaveChanges();

            //return to the index page
            return RedirectToAction("Index");


        }




    }
}