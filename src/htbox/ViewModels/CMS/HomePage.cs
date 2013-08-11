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

        [EditableText("First Sub Heading", 200)]
        public virtual string SubHeading1 { get; set; }

        [EditableText("First Sub Body", 210)]
        public virtual string SubBody1 { get; set; }

        [EditableText("Second Sub Heading", 230)]
        public virtual string SubHeading2 { get; set; }

        [EditableText("Second Sub Body", 240)]
        public virtual string SubBody2 { get; set; }

        [EditableText("Third Sub Heading", 260)]
        public virtual string SubHeading3 { get; set; }

        [EditableText("Third Sub Body", 270)]
        public virtual string SubBody3 { get; set; }

        [EditableText("Footer Text (for every page)", 600)]
        public virtual string FooterText { get; set; }
    }
}