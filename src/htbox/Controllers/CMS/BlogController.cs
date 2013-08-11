using System;
using System.Web.Mvc;

using htbox.ViewModels.CMS;

using N2.Web;
using N2.Web.Mvc;

namespace htbox.Controllers.CMS {
    [Controls(typeof(Blog))]
    public class BlogController : ContentController<Blog> {
        public override ActionResult Index() {
            return base.Index();
        }
    }
}