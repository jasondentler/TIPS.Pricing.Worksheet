using System;
using System.Configuration;
using System.Web.Mvc;
using TIPS.Pricing.UI.Filters;
using TIPS.Pricing.UI.Models;

namespace TIPS.Pricing.UI.Controllers
{
    public class WorksheetController : Controller
    {
        private readonly SaleController _saleController;

        public WorksheetController(SaleController saleController)
        {
            _saleController = saleController;
        }

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
            var formatString = ConfigurationManager.AppSettings["TIPSUrl"];
            var sale = _saleController.Get(id);

            var tipsUrl = string.Format(formatString, sale.OpportunityId, sale.SaleId);
            return View(new SelectFlexOptions()
                {
                    Sale = sale,
                    TipsUrl = new Uri(tipsUrl, UriKind.RelativeOrAbsolute)
                });
        }

    }
}
