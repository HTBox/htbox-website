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

        public IList<BlogPost> RecentItems {
            get { return _recentItems ?? (_recentItems = GetRecentItems()); }
        }

        public BlogPost FeatureItem {
            get { return _featureItem ?? (_featureItem = GetFeatureItem()); }
        }

        private BlogPost _featureItem;
        private IList<BlogPost> _recentItems;

        IList<BlogPost> GetRecentItems() {
            var items = N2.Find.Items.Where.Type.Eq(typeof(Blog)).Select();
            if (items.Count < 1)
                throw new Exception("EventList not found.");
            var blog1 = items[0] as Blog;
            var posts = blog1.RecentPosts.Take(5).ToList();

            if (items.Count > 1) {
                var blog2 = items[1] as Blog;
                posts.AddRange(blog2.RecentPosts.Take(5));
            }

            posts.OrderBy(p => p.Published);

            return posts.Take(5).ToList();
        }

        private BlogPost GetFeatureItem() {
            var featureItem = RecentItems.FirstOrDefault(p => !string.IsNullOrWhiteSpace(p.Image));

            if (featureItem == null) {
                featureItem = RecentItems[0];
            }

            return featureItem;
        }
    }
}