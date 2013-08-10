using System;
using System.Collections.Generic;

using N2.Collections;

namespace htbox.ViewModels.CMS {
    public class FakePartList<TFakePart> : CMSBasePage where TFakePart : FakePart {
        public string RequestedName { get; set; }

        ItemList<TFakePart> _items = null;

        ItemFilter[] BuildItemFilters() {
            var filters = new List<ItemFilter> {new TypeFilter(typeof (TFakePart)), new PublishedFilter()};
            AdjustItemFilters(filters);
            return filters.ToArray();
        }

        protected virtual void AdjustItemFilters(List<ItemFilter> filters) {
        }

        protected virtual string SortExpression {
            get { return null; }
        }

        public IList<TFakePart> Items {
            get {
                if (_items == null) {
                    _items = GetChildren(BuildItemFilters()).Cast<TFakePart>();
                    if (!String.IsNullOrWhiteSpace(SortExpression)) {
                        _items.Sort(SortExpression);
                    }
                }
                return _items;
            }
        }

        TFakePart _requestedItem = null;

        public TFakePart RequestedItem {
            get {
                if (_requestedItem == null && !String.IsNullOrWhiteSpace(RequestedName)) {
                    _requestedItem = ((ItemList<TFakePart>) Items).FindNamed(RequestedName);
                }
                return _requestedItem;
            }
        }
    }
}