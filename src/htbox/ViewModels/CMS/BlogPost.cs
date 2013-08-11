using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using N2;
using N2.Details;
using N2.Integrity;

namespace htbox.ViewModels.CMS {
    [PageDefinition("Blog Post")]
    [RestrictParents(typeof(Blog))]
    [WithEditableTitle, WithEditableName]
    public class BlogPost : ContentItem {
        
        public override DateTime? Published {
            get {
                return base.Published;
            }
            set {
                base.Published = value;
            }
        }
    }
}