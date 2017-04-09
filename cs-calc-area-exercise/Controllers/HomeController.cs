using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using cs_calc_area_exercise.Models;


namespace cs_calc_area_exercise.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            var viewModel = new AreaCalcViewModel();
            
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Index(AreaCalcViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);

            }
            else
            {
                ModelState.Clear();
            }

            viewModel.glass = new Glass(viewModel.SelectedInchWidth, viewModel.SelectedFracWidth, viewModel.SelectedInchLength, viewModel.SelectedFracLength);
           
            return PartialView("Result",viewModel.glass);
        }
    }
}