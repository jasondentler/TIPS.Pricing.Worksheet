using System;
using System.Web.Mvc;
using TIPS.Pricing.UI.Filters;
using TIPS.Pricing.UI.Models;

namespace TIPS.Pricing.UI.Controllers
{
    public class WorksheetController : Controller
    {

        [HttpGet, ModelStateToTempData]
        public ViewResult StepOne(long? id)
        {
            if (id.HasValue)
                return View(new SelectASale() {SaleId = id.Value});
            return View();
        }

        [HttpPost, ModelStateToTempData]
        public RedirectToRouteResult StepOne(SelectASale model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("StepOne");

            return RedirectToAction("StepTwo", new {id = model.SaleId});
        }

        [HttpGet]
        public ViewResult StepTwo(long id)
        {
            return View(new SelectFlexOptions() {SaleId = id});
        }

    }
}
