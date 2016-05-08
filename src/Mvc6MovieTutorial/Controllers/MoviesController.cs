using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Mvc6MovieTutorial.Models;
using Microsoft.AspNet.Http.Internal;
using System.Collections.Generic;

namespace Mvc6MovieTutorial.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Movies/Index/
        public IActionResult Index(string movieGenre, string searchString)
        {
            //get all genres from the DB
            var genres = from m in _context.Movie
                         orderby m.Genre
                         select m.Genre;
            //Get the Distinct list of genre to prevent dupes to store in a
            // select list for a useful dropdown
            var genreList = new List<string>();
            genreList.AddRange(genres.Distinct());
            ViewData["movieGenre"] = new SelectList(genreList);

            //get all movies from the DB
            var movies = from m in _context.Movie
                         select m;

            //see if the searchString param is not empty, constrain the query to limit
            //the results to the search term
            if (!string.IsNullOrEmpty(searchString))
            {
                //query w/ lambda!
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            //see if the movieGenre param is not empty, constrain the query to limit
            //the results to the specified genre
            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            return View(movies);
        }
        //
        // POST: Movies
        /*[HttpPost]
        public string Index(FormCollection fc, string searchString)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }*/

        // GET: Movies/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Movie movie = _context.Movie.Single(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Movie.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Movie movie = _context.Movie.Single(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(
            [Bind("ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)//To protect ourself from over-posting, we add the Bind attribute
        {
            if (ModelState.IsValid)
            {
                _context.Update(movie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Movie movie = _context.Movie.Single(m => m.ID == id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed([Bind("ID,Title,ReleaseDate,Genre,Price,Rating")] int id)
        {
            Movie movie = _context.Movie.Single(m => m.ID == id);
            _context.Movie.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
