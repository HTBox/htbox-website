using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

using MailChimp;
using MailChimp.Net;

using htbox.ViewModels;
using htbox._ImportedCode.Benthos.N2CMS;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;

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
        public async Task<ActionResult> Subscribe(MailingListSubscribeViewModel viewModel) {
            //TODO: Remove this as it is for fake processing to check that only ".com" addresses are valid
            if (!ModelState.IsValid) {
                //TODO: move to base class and need to pull in my tempdata cookieprovider so we are multi-server tolerant with tempdata
                TempData["ViewData"] = ViewData;
                return RedirectToAction("Subscribe");
            }

            //TODO: do actual subscription processing

            string mailChimpApiKey = ConfigurationSettings.AppSettings["MailChimpApiKey"];
            string mailChimpListId = ConfigurationSettings.AppSettings["MailChimpListId"];

            IMailChimpManager manager = new MailChimpManager(mailChimpApiKey);

            // Use the Status property if updating an existing member
            var member = new Member { EmailAddress = viewModel.EmailAddress, StatusIfNew = Status.Subscribed };
            member.MergeFields.Add("FNAME", viewModel.FirstName);
            member.MergeFields.Add("LNAME", viewModel.LastName);
            await manager.Members.AddOrUpdateAsync(mailChimpListId, member);

            //TODO: move to base class and need to pull in my tempdata cookieprovider so we are multi-server tolerant with tempdata
            TempData["alert-success"] = "Thank you! You are now signed up.";
            return RedirectToAction("Subscribe");
        }
    }
}
