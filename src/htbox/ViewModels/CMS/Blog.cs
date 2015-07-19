using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using N2;
using N2.Definitions;
using N2.Integrity;

namespace htbox.ViewModels.CMS {
    [PageDefinition("Blog")]
    [RestrictChildren(typeof(BlogPost))]
    [SortChildren(SortBy.Expression, SortExpression = "Published DESC")]
    public class Blog : CMSBasePage {

        public List<BlogPost> Posts {
            get {
                return new List<BlogPost>(Children.FindNavigatablePages().Cast<BlogPost>());
            }
        }

        public List<BlogPost> RecentPosts {
            get {
                return new List<BlogPost>(Posts.Where(p => p.IsPublished()).Take(10).OrderByDescending(p => p.Published));
            }
        }
    }
}