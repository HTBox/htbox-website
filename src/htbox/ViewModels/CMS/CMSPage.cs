using System;

using N2;
using N2.Details;

namespace htbox.ViewModels.CMS {
    [PageDefinition("Content Page")]
    [WithEditableName, WithEditableTitle]
    public class CMSPage : CMSBasePage {

        [EditableImageUpload("Template Image", 210, HelpText = "Per Design Guidelines, the image will be responsively resized by device size but shouldn't be larger than 570px wide")]
        public virtual string Image { get; set; }

        [EditableText("Template Image Alt Text", 220)]
        public virtual string ImageAltText { get; set; }

        public bool HasImage {
            get { return !string.IsNullOrWhiteSpace(Image); }
        }
    }
}