using System;
using System.Web.Mvc;

using htbox.ViewModels.CMS;

using N2.Web;
using N2.Web.Mvc;

namespace htbox.Controllers {
    [Controls(typeof(CMSPage))]
    public class CMSController : ContentController<CMSPage> {
        public override ActionResult Index() {
            return base.Index();
        }
    }
}