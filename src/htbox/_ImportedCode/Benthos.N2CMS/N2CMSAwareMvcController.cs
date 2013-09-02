using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

using htbox.ViewModels.CMS;

namespace htbox._ImportedCode.Benthos.N2CMS {
    public abstract class N2CMSAwareMvcController : Controller {
        CMSPage _backingContent = null;
        int _backingContentId = 0;

        public CMSPage BackingContentSource {
            get {
                LoadBackingContentData();
                return _backingContent;
            }
        }

        public int BackingContentId {
            get {
                LoadBackingContentData();
                return _backingContentId;
            }
        }

        void LoadBackingContentData() {
            int backingContentId = 0;
            if (_backingContent == null && HttpContext.Request.QueryString["backingcontentid"] != null && int.TryParse(HttpContext.Request.QueryString["backingcontentid"], out backingContentId)) {
                _backingContentId = backingContentId;
                ViewBag.BackingContentId = backingContentId;
                _backingContent = N2.Find.Items.Where.ID.Eq(backingContentId).Select<CMSPage>().FirstOrDefault();
            }
        }

        //inject the backingcontentid into route data to ensure it lands in redirect urls
        protected override RedirectToRouteResult RedirectToAction(string actionName, string controllerName, System.Web.Routing.RouteValueDictionary routeValues) {
            if (routeValues == null) {
                routeValues = new RouteValueDictionary();
            }
            if (BackingContentId > 0) {
                routeValues.Add("backingcontentid", BackingContentId);
            }
            return base.RedirectToAction(actionName, controllerName, routeValues);
        }
    }
}