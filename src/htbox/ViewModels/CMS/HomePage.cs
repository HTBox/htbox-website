using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using N2;
using N2.Definitions;
using N2.Details;
using N2.Integrity;

namespace htbox.ViewModels.CMS {
    [PageDefinition("Home Page")]
    [WithEditableName, WithEditableTitle]
    [RestrictParents(typeof(IRootPage))]
    public class HomePage : CMSBasePage {




        [EditableText("Footer Text (for every page)", 600)]
        public virtual string FooterText { get; set; }
    }
}