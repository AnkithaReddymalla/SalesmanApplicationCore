using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesmanApplicationCore.Models;
using Microsoft.EntityFrameworkCore;


namespace SalesmanApplicationCore.Controllers
{
    public class SalesmanController : Controller
    {
        SalesmanDbContext _salesmanDbContext;
        public SalesmanController(SalesmanDbContext salesmanDbContext)
        {
            _salesmanDbContext = salesmanDbContext;
        }
        public IActionResult Index()
        {

            var salesmanList = _salesmanDbContext.salesman.ToList();//select * from salesman
            return View(salesmanList);
        }
        public IActionResult SalesmanEntity()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SalesmanEntity(Salesman salesmanObj)
        {
            _salesmanDbContext.salesman.Add(salesmanObj);// insert into salesman values(salesmanObj.salesman_id,salesmanObj.name,salesmanObj.city,salesmanObj.commission)
            _salesmanDbContext.SaveChanges();
            // ViewBag, viewdata, tempdata
            ViewBag.message = "Salesman Details Saved Successfully";
            return View();
        }

        public IActionResult EditSalesman(decimal salesman_id)
        {
            var result = _salesmanDbContext.salesman.Find(salesman_id);
            return View(result);
        }
        [HttpPost]
        public IActionResult EditSalesman(Salesman salesman)
        {
            _salesmanDbContext.Entry(salesman).State = EntityState.Modified;
            _salesmanDbContext.SaveChanges();
            ViewBag.message = "Salesman Details Updated Successfully";
             return View();
        }

        public IActionResult DeleteSalesman(decimal salesman_id)
        {
            var result = _salesmanDbContext.salesman.Find(salesman_id);
            return View(result);
        }

        [HttpPost]
        public IActionResult DeleteSalesman(Salesman salesman)
        {
            _salesmanDbContext.Entry(salesman).State = EntityState.Deleted;
            _salesmanDbContext.SaveChanges();
            ViewBag.message = "Salesman Details Deleted Successfully";
            return View();
        }
    } 
}
