using System;
using System.Web.Mvc;
using System.ServiceModel.Syndication;
using System.Xml;

using htbox.ViewModels.CMS;

using N2.Web;
using N2.Web.Mvc;
using System.Collections.Generic;

namespace htbox.Controllers.CMS {
    [Controls(typeof(Blog))]
    public class BlogController : ContentController<Blog> {
        public override ActionResult Index() {
            return base.Index();
        }

        public ActionResult Rss() {
            return new RssActionResult(GetFeed());
        }

        public ActionResult Atom() {
            return new AtomActionResult(GetFeed());
        }

        private SyndicationFeed GetFeed() {
            var blog = CurrentItem;

            var feed = new SyndicationFeed() {
                Title = new TextSyndicationContent(blog.PageTitle),
                Description = new TextSyndicationContent(blog.Text, TextSyndicationContentKind.Html),
                BaseUri = new Uri(Request.Url.Scheme + "://" + Request.Url.Authority + blog.Url),
                Items = GetItems(),
            };

            return feed;
        }

        private IEnumerable<SyndicationItem> GetItems() {
            foreach (var p in CurrentItem.RecentPosts) {
                var item = new SyndicationItem(p.Title, p.Text, new Uri(Request.Url.Scheme + "://" + Request.Url.Authority + p.Url), Request.Url.Scheme + "://" + Request.Url.Authority + p.Url, p.Published.Value);

                item.Authors.Add(new SyndicationPerson("", "Humanitarian Toolbox", ""));
                item.PublishDate = p.Published.Value;
                item.Content = new TextSyndicationContent(p.Text, TextSyndicationContentKind.Html);
                yield return item;
            }
        }
    }

    public class AtomActionResult : ActionResult {
        public AtomActionResult(SyndicationFeed feed) {
            Feed = feed;
        }

        public SyndicationFeed Feed { get; set; }
        public override void ExecuteResult(ControllerContext context) {
            context.HttpContext.Response.ContentType = "application/atom+xml";
            var formatter = new Atom10FeedFormatter(Feed);
            using (var writer = XmlWriter.Create(context.HttpContext.Response.Output, new XmlWriterSettings { Indent = true }))
                formatter.WriteTo(writer);
        }
    }

    public class RssActionResult : ActionResult {
        public RssActionResult(SyndicationFeed feed) {
            Feed = feed;
        }

        public SyndicationFeed Feed { get; set; }
        public override void ExecuteResult(ControllerContext context) {
            context.HttpContext.Response.ContentType = "application/rss+xml";
            var formatter = new Rss20FeedFormatter(Feed);
            using (var writer = XmlWriter.Create(context.HttpContext.Response.Output, new XmlWriterSettings { Indent = true }))
                formatter.WriteTo(writer);
        }
    }
}