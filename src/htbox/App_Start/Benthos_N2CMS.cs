using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Benthos.N2CMS;

using N2.Web.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(htbox.App_Start.Benthos_N2CMS), "PreStart")]
[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(htbox.App_Start.Benthos_N2CMS), "PostStart")]

namespace htbox.App_Start {
    public class Benthos_N2CMS {
        static IControllerFactory _cmsFactory;
        static IControllerFactory _factory;

        public static void PreStart() {
            _factory = ControllerBuilder.Current.GetControllerFactory();

            var engine = MvcEngine.Create();
            _cmsFactory = ControllerBuilder.Current.GetControllerFactory();

            RouteTable.Routes.MapContentRoute("Content", engine);
        }

        public static void PostStart() {
            ControllerBuilder.Current.SetControllerFactory(new N2CMSDelegatingControllerFactory(_cmsFactory, _factory));
        }
    }
}