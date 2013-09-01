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

        [EditableText("Post Title", 90, HelpText = "Longer form title for the Post")]
        public virtual string PostTitle { get; set; }

        [EditableFreeTextArea("Post Content", 200)]
        public virtual string Text { get; set; }

        [EditableDate("Publish Date", 100)]
        public override DateTime? Published {
            get {
                return base.Published;
            }
            set {
                base.Published = value;
            }
        }

        [EditableImageUpload("Post Image", 300)]
        public virtual string Image { get; set; }

        public bool HasImage {
            get { return !string.IsNullOrWhiteSpace(Image); }
        }

        public Blog Blog {
            get { return Parent as Blog; }
        }
    }
}