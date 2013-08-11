using System;

using N2;
using N2.Details;

namespace htbox.ViewModels.CMS {
    [WithEditableName, WithEditableTitle]
    public abstract class CMSBasePage : ContentItem {
        [EditableText("Page Title", 90, HelpText = "Longer form title for display on the page")]
        public virtual string PageTitle { get; set; }

        [EditableFreeTextArea("Page Content", 100)]
        public virtual string Text { get; set; }

        [EditableCheckBox("Show In Menus", 110, DefaultValue = true)]
        public override bool Visible {
            get { return base.Visible; }
            set { base.Visible = value; }
        }
    }
}