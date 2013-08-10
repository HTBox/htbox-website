using System;

using N2;
using N2.Details;

namespace htbox.ViewModels.CMS {
    [WithEditableName, WithEditableTitle]
    public abstract class CMSBasePage : ContentItem {
        
        [EditableCheckBox("Show In Menus", 110, DefaultValue = true)]
        public override bool Visible {
            get { return base.Visible; }
            set { base.Visible = value; }
        }

        [EditableFreeTextArea]
        public virtual string Text { get; set; }
    }
}