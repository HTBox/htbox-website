using System;

using N2;

namespace htbox.ViewModels.CMS {
    public class FakePart : ContentItem {

        public override string Url {
            get { return Parent.Url + "/Item?Key=" + Name; }
        }
    }
}