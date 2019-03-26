using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlLayer;
using BlLayer.Interface;
using DTOLayer;
using Microsoft.AspNetCore.Mvc;
using TaskCoreMVCProject.Models;

namespace TaskCoreMVCProject.Controllers
{
    public class HomeController : Controller
    {
        private ITask Productdata;

        public HomeController()
        {
            Productdata = new Taskdatatprovider();
        }
        public IActionResult Index()
        {
            List<Productdetail> PRO = Productdata.Product();
            return View(PRO);
        }

        public IActionResult Action(string CommandName, int id=0, string Product = "", int Price=0)
        {
            bool Productoperation = Productdata.ProductOperation(CommandName,id,Product,Price);
            return Json(Productoperation);
        }
    }
}
