using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

using N2.Web.Mvc;

// ReSharper disable once CheckNamespace
namespace Benthos.N2CMS {
    //class inherited from Tony's soon to be public library to provide support for N2CMS/MVC integration
    public class N2CMSDelegatingControllerFactory : IControllerFactory {
        private readonly IControllerFactory _factory;
        private readonly IControllerFactory _cmsFactory;

        public N2CMSDelegatingControllerFactory(IControllerFactory cmsFactory, IControllerFactory factory) {
            this._cmsFactory = cmsFactory;
            this._factory = factory;
        }

        public IController CreateController(RequestContext requestContext, string controllerName) {
            return !(requestContext.RouteData.Route is ContentRoute) ? this._factory.CreateController(requestContext, controllerName) : this._cmsFactory.CreateController(requestContext, controllerName);
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName) {
            if (requestContext.RouteData.Route is ContentRoute)
                return this._cmsFactory.GetControllerSessionBehavior(requestContext, controllerName);
            else
                return this._factory.GetControllerSessionBehavior(requestContext, controllerName);
        }

        public void ReleaseController(IController controller) {
            if (((ControllerBase)controller).ControllerContext.RouteData.Route is ContentRoute)
                this._cmsFactory.ReleaseController(controller);
            else
                this._factory.ReleaseController(controller);
        }
    }
}