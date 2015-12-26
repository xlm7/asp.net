using Shiyan5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shiyan5.Controllers
{
    public class MoviesController : Controller
    {
         MovieDBContext db = new MovieDBContext();
        // GET: Movies
        public ActionResult Index(string movieGenre,string searchString)
        {
            var GenreLst = new List<string>();
            var GenreQry = from d in db.Movies orderby d.Genre select d.Genre;
            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.movieGenre = new SelectList(GenreLst);
            var movies = from m in db.Movies select m;
            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }
            return View(movies);
        }

        public ActionResult Edit(int? id)
        {
        //    if (id == null)
          //  {
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
               
                db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }


        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid) {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(movie);
        }

        public ActionResult TestJQueryUI()
        {
            return View();
        }

       

        public ActionResult Delete(int? id)
        {
            
                //    if (id == null)
                //  {
                //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //}
                Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
 }

        public ActionResult Details(int? id)
        {
            //    if (id == null)
            //  {
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

    }
}