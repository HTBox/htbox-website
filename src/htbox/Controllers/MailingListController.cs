using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MailChimp;
using MailChimp.Types;

using htbox.ViewModels;
using htbox._ImportedCode.Benthos.N2CMS;

namespace htbox.Controllers
{
    public class MailingListController : N2CMSAwareMvcController {

        public ActionResult Subscribe() {
            //TODO: Move this back to base class
            if (TempData["ViewData"] != null)
                ViewData = (ViewDataDictionary)TempData["ViewData"];

            ViewBag.Content = BackingContentSource;

            var model = new MailingListSubscribeViewModel();

            return View(model);
        }

        //
        // POST: /MailingList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Subscribe(MailingListSubscribeViewModel viewModel) {
            //TODO: Remove this as it is for fake processing to check that only ".com" addresses are valid
            if (!ModelState.IsValid) {
                //TODO: move to base class and need to pull in my tempdata cookieprovider so we are multi-server tolerant with tempdata
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Subscribe");
            }

            //TODO: do actual subscription processing

            string mailChimpApiKey = ConfigurationSettings.AppSettings["MailChimpApiKey"];
            string mailChimpListId = ConfigurationSettings.AppSettings["MailChimpListId"];

            var mailChimp = new MCApi(mailChimpApiKey, true);

            mailChimp.ListSubscribe(mailChimpListId, viewModel.EmailAddress,
                                    new List.Merges {
                                        {"FNAME", viewModel.FirstName},
                                        {"LNAME", viewModel.LastName}
                                    }, new List.SubscribeOptions() {
                                        DoubleOptIn = false,
                                        SendWelcome = false,
                                        UpdateExisting = true
                                    });

            //TODO: move to base class and need to pull in my tempdata cookieprovider so we are multi-server tolerant with tempdata
            TempData["alert-success"] = "Thank you! You are now signed up.";
            return RedirectToAction("Subscribe");
        }
    }
}
