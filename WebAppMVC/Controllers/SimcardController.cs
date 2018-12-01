using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers
{
    public class SimcardController : Controller
    {
        // GET: Simcard
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Simcard());
            else
            {
                using (DBModel db = new DBModel())
                {
                    return View(db.Simcards.Where(model => model.EmployeeID == id).FirstOrDefault<Simcard>());
                }
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            using (DBModel db = new DBModel())
            {
                if (emp.EmployeeID == 0)
                {
                    db.Employees.Add(emp);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Save Successfuly" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Update Successfuly" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (DBModel db = new DBModel())
            {
                Simcard simcard = db.Simcards.Where(x => x.EmployeeID == id).FirstOrDefault<Simcard>();
                db.Simcards.Remove(simcard);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}