using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Student> objList = _db.Students;
            return View(objList);
        }
        //GET Create
        public IActionResult Create()
        {
            return View();
        }
        //POST Create
        [HttpPost]
       
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET Delete
        public IActionResult Delete(int? id)
        {
           
            if (id == null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Students.Find(id);
            if(obj== null)
            {
                return NotFound();
            }
            return View(obj);

        }
        //POST Delete
       
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Students.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            
                _db.Students.Remove(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
           
        }
        //GET Update
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Students.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
        //POST Update
        [HttpPost]

        public IActionResult Update(Student obj)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


    }
}