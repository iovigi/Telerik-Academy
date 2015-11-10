using System.Linq;

namespace TradeCompany
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class ArticleStore : ICollection<Article>
    {
        private OrderedMultiDictionary<decimal, Article> Articles;

        public ArticleStore()
        {
            this.Articles = new OrderedMultiDictionary<decimal, Article>(true);
        }

        public int Count
        {
            get { return this.Articles.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public void Add(Article item)
        {
            this.Articles.Add(item.Price, item);
        }

        public void Clear()
        {
            this.Articles.Clear();
        }

        public bool Contains(Article item)
        {
            return this.Articles.Exists(x => x.Key == item.Price && x.Value.Contains(item));
        }

        public void CopyTo(Article[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Article> GetEnumerator()
        {
            return this.Articles.Values.GetEnumerator();
        }

        public bool Remove(Article item)
        {
           return this.Articles.Remove(item.Price, item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerable<Article> Range(decimal startPrice, decimal endPrice)
        {
            return this.Articles.Range(startPrice, true, endPrice, true).Values;
        } 
    }
}
