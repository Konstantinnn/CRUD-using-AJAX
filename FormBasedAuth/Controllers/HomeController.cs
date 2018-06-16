using FormBasedAuth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormBasedAuth.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        ProjectDB1 db = new ProjectDB1();
        List<Cars> cars = new List<Cars>();
        
        // GET: Home
        public ActionResult Index()
        {
           
            cars = db.Cars.ToList();
            return View(cars);
        }

        public JsonResult GetAllCars()
        {
            List<Cars> cars = db.Cars.ToList();
            return Json(cars, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCarById(Cars CarId)
        {

            Cars car = db.Cars.Where(x => x.Id == CarId.Id).Single();
            return Json(car, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Cars car)
        {
            if (ModelState.IsValid)
            {
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("index","Home");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var car = db.Cars.Where(x => x.Id == id).Single();
            return View(car);
        }
        [HttpPost]
        public ActionResult Edit(Cars car)
        {
            if (ModelState.IsValid)
            {
                Cars b = db.Cars.Where(x => x.Id == car.Id).Single();
                b.Model = car.Model;
                b.Name = car.Name;
                b.Capability = car.Capability;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        
        public JsonResult UpdateCar(Cars car)
        {
            var result = false;
            {
                try
                {
                    Cars carObj = db.Cars.Where(x => x.Id == car.Id).Single();
                    carObj.Model = car.Model;
                    carObj.Name = car.Name;
                    carObj.Capability = car.Capability;
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
                return Json(result,JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult AddCar(Cars car)
        {
            var result = false;
            try
            {
                db.Cars.Add(car);
                db.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCar(Cars car)
        {
            bool result = false;
            Cars car1 = db.Cars.Where(x => x.Id == car.Id).Single();
            if (car1 != null)
            {
                db.Cars.Remove(car1);
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Delete(int? id)
        {
            Cars car = db.Cars.Where(x => x.Id == id).Single();
            return View("Index","Home");
        }
    }
}