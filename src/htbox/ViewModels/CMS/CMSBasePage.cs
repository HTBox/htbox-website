using System;

using N2;
using N2.Details;

namespace htbox.ViewModels.CMS {
    [WithEditableName, WithEditableTitle]
    public abstract class CMSBasePage : ContentItem {
        [EditableText("Menu Link", 90, HelpText = "Text entered here is used instead of the Title in Menus and Links.")]
        public virtual string AlternateMenuTitle { get; set; }

        public string MenuLink {
            get {
                if (!String.IsNullOrWhiteSpace(AlternateMenuTitle)) {
                    return AlternateMenuTitle;
                }
                return Title;
            }
        }

        [EditableFreeTextArea("Page Content", 100)]
        public virtual string Text { get; set; }

        [EditableCheckBox("Show In Menus", 110, DefaultValue = true)]
        public override bool Visible {
            get { return base.Visible; }
            set { base.Visible = value; }
        }
    }
}