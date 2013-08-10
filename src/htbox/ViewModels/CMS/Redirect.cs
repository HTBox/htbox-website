using System;

using N2;
using N2.Details;
using N2.Web.UI.WebControls;

namespace htbox.ViewModels.CMS
{
    [PageDefinition("Redirect",
        Description = "Redirects to another page or external address",
        IconUrl = "~/n2/resources/icons/page_go.png")]
    [WithEditableTitle("Title", 10, Focus = true)]
    public class Redirect : ContentItem 
    {
        public override string Url
        {
            get { return N2.Web.Url.ToAbsolute(RedirectUrl); }
        }

        [Editable("Redirect To", typeof(UrlSelector), "Url", 40, Required = true)]
        public virtual string RedirectUrl { get; set; }

        [EditableCheckBox("301 (Permanent) Redirect?", 100)]
        public virtual bool Redirect301 { get; set; }

        [EditableCheckBox("Visible", 100)]
        public override bool Visible {
            get { return base.Visible; }
            set { base.Visible = value; }
        }
    }
}