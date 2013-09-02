using System;
using System.Web.Mvc;

using htbox.ViewModels.CMS;

using N2.Web;
using N2.Web.Mvc;

namespace htbox.Controllers.CMS {
    [Controls(typeof(CMSPage))]
    public class CMSController : ContentController<CMSPage> {
        public override ActionResult Index() {

            if (!string.IsNullOrWhiteSpace(CurrentItem.MvcSubstitueUrl)) {
                var url = CurrentItem.MvcSubstitueUrl + "?backingcontentid=" + CurrentItem.ID;
                return Redirect(url);
            }

            return base.Index();
        }
    }
}