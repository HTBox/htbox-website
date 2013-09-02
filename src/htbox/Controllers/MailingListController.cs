using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using htbox.ViewModels;

namespace htbox.Controllers
{
    public class MailingListController : Controller
    {
        public ActionResult Subscribe() {
            if (TempData["ViewData"] != null)
                ViewData = (ViewDataDictionary)TempData["ViewData"];

            var model = new MailingListSubscribeViewModel();

            return View(model);
        }

        //
        // POST: /MailingList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Subscribe(MailingListSubscribeViewModel viewModel) {
            //TODO: Remove this as it is for fake processing to check that only ".com" addresses are valid
            if (!viewModel.EmailAddress.EndsWith(".com")) {
                ModelState.AddModelError("EmailAddress", "Email Address must be a '.com' address.");
                TempData["alert-danger"] = "Could not sign up! Please try again.";
            }
            if (!ModelState.IsValid) {
                //TODO: need to pull in my tempdata cookieprovider so we are multi-server tolerant with tempdata
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Subscribe");
            }

            //TODO: do actual subscription processing

            //TODO: need to pull in my tempdata cookieprovider so we are multi-server tolerant with tempdata
            TempData["alert-success"] = "Thank you! You are now signed up.";
            return RedirectToAction("Subscribe");
        }
    }
}
